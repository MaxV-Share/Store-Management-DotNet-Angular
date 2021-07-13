import { Component, EventEmitter, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Bill, BillCreateRequest, BillDetailCreateRequest, ProductDetail } from '@app/models';
import { BillDetail } from '@app/models/bills/bill-detail';
import { BillService } from '@app/shared/services';
import { GlobalService } from '@app/shared/services/global.service';
import { ProductService } from '@app/shared/services/product.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { of } from 'rxjs';
import { debounceTime, delay, finalize, map, startWith, switchMap, tap } from 'rxjs/operators';

@Component({
    selector: 'app-order-manager-details',
    templateUrl: './order-manager-details.component.html',
    styleUrls: ['./order-manager-details.component.scss']
})
export class OrderManagerDetailsComponent implements OnInit {
    isLoadingAutocompleteProduct: boolean;
    saved: EventEmitter<any> = new EventEmitter();
    displayedColumns: string[] = ['no', 'product-code', 'product-name', 'quantity', 'price', 'total-price', 'edit'];
    public entity: any;
    dataSourceBillDetail = new MatTableDataSource<BillDetail>();
    ctrProduct = new FormControl();
    products: ProductDetail[];
    filteredOptions: any;
    totalRow: number;
    pageIndex: number;
    pageSize: number;
    bill: any;
    billDetail: any = [];
    get paymentAmount(): number {
        let value = this.totalPrice - (this.bill.discountPrice + 0)
        if (value < 0) {
            value = 0;
            this.bill.discountPrice = this.totalPrice;
        }

        return value + 0;
    }
    set paymentAmount(value) {
    }

    get totalPrice() {
        return this.billDetail.reduce((value, cur) => value + cur.quantity * cur.price, 0)
    }
    set totalPrice(value) {
    }

    constructor(private modalService: NgbModal,
        public bsModalRef: BsModalRef,
        public globalService: GlobalService,
        public billService: BillService,
        private productService: ProductService,
        public translate: TranslateService) { }


    ngOnInit() {
        this.bill = new Bill();
        if (this.entity != null) {
            this.billService.getDetails(this.entity.id).subscribe((res: BillDetail[]) => {
                this.billDetail = res;
                this.dataSourceBillDetail = new MatTableDataSource<BillDetail>(this.billDetail);
                console.log(res);
            });
        } else {
            this.dataSourceBillDetail = new MatTableDataSource<BillDetail>(this.billDetail);
        }
        this.getProduct();
        this.ctrProduct.valueChanges
            .pipe(
                debounceTime(500),
                tap(() => {
                    //   this.errorMsg = "";
                    //   this.filteredMovies = [];
                    this.isLoadingAutocompleteProduct = true;
                }), switchMap(searchValue => {
                    this.isLoadingAutocompleteProduct = true;
                    return this.productService.getAll(searchValue).pipe(
                        delay(100),
                        finalize(() => {
                            this.isLoadingAutocompleteProduct = false
                        }))
                })
            )
            .subscribe((data: ProductDetail[]) => {
                this.isLoadingAutocompleteProduct = true;
                this.products = data;
                this.filteredOptions = of(data);
            });
    }

    validMaxInput(event, maxValue) {
        if (event > maxValue) {
            this.bill.discountPrice = maxValue;
        } else if (event < 0) {
            this.bill.discountPrice = 0;
        } else {
            this.bill.discountPrice = event;
        }
    }

    onSave() {
        // this.saved.emit("Saved");
        // this.entity.ProductId = this.ctrProduct.value.ProductId;
        // //console.log(this.ctrProduct.value);

        // const formData = this.utilitiesService.ToFormData(this.entity);

        // formData.append('file', this.uploadedFiles[0], this.uploadedFiles[0].name);
        // this.productService.add(formData).subscribe(() => {
        //     //this.log
        // });
        if (this.entity == null) {

            let billCreateRequest : BillCreateRequest = {
                billDetails: this.billDetail,
                totalPrice: this.totalPrice,
                discountPrice: this.bill.discountPrice,
                paymentAmount: this.totalPrice - this.bill.discountPrice,
                userPaymentUserName: this.globalService.currentUserName,
                customerPhoneNumber: this.bill.customerPhoneNumber
            }
            this.billService.add(billCreateRequest).subscribe(e => {

            });
        } else {
            let billUpdateRequest : Bill  = {
                id: this.entity.id,
                billDetails: this.billDetail,
                totalPrice: this.totalPrice,
                paymentAmount: this.totalPrice - this.bill.discountPrice,
                userPaymentUserName: this.globalService.currentUserName,
                customerPhoneNumber: this.bill.customerPhoneNumber
            }
            this.billService.update(this.entity.id, billUpdateRequest).subscribe(e => {

            });
        }
    }

    displayFn(object: ProductDetail): string {
        return object && object.name ? object.name : '';
    }

    getProduct() {
        this.productService.getAll('').subscribe((res: ProductDetail[]) => {
            this.products = res;
            this.filteredOptions = this.ctrProduct.valueChanges
                .pipe(
                    startWith(''),
                    map(value => typeof value === 'string' ? value : value.name),
                    map(name => this.products.slice())
                );
        })
    }

    addProduct() {
        //console.log(this.ctrProduct.value);
        const product: ProductDetail = this.ctrProduct.value;

        let object = this.billDetail.find(e => e.productId == product.productId);
        if (object != null) {
            object.quantity++;
        } else {
            this.billDetail.push({ productId: product.productId, price: product.price, discountPrice: null, quantity: 1, product: product });
        }
        // if(checkExist  0){
        //     return;
        // }

        this.dataSourceBillDetail = new MatTableDataSource<BillDetailCreateRequest>(this.billDetail);
    }

    deleteProduct(object: BillDetailCreateRequest) {
        this.billDetail = this.billDetail.filter(e => e.productId != object.productId)
        this.dataSourceBillDetail = new MatTableDataSource<BillDetailCreateRequest>(this.billDetail);
    }

    pageEventHandle(event: PageEvent) {
        this.pageSize = event.pageSize;
        this.pageIndex = event.pageIndex + 1;
        // this.getPaging(this.pageIndex, this.pageSize, this.translate.currentLang, this.txtSearch);
    }
}
