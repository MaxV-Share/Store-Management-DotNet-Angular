import { HttpResponse } from '@angular/common/http';
import { Component, EventEmitter, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BaseComponent } from '@app/components/base';
import { Bill, BillCreateRequest, BillDetailCreateRequest, BillUpdateRequest, mapper, ProductDetail } from '@app/models';
import { BillDetail } from '@app/models/view-models/bill-detail';
import { BillService } from '@app/shared/services';
import { GlobalService } from '@app/shared/services/global.service';
import { ProductService } from '@app/shared/services/product.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { of } from 'rxjs';
import { debounceTime, delay, finalize, map, startWith, switchMap, tap } from 'rxjs/operators';

@Component({
    selector: 'app-order-manager-details',
    templateUrl: './order-manager-details.component.html',
    styleUrls: ['./order-manager-details.component.scss']
})
export class OrderManagerDetailsComponent extends BaseComponent implements OnInit {
    isLoadingAutocompleteProduct: boolean;
    saved: EventEmitter<any> = new EventEmitter();
    displayedColumns: string[] = ['no', 'product-code', 'product-name', 'quantity', 'price', 'total-price', 'edit'];
    dataSourceBillDetail = new MatTableDataSource<BillDetail>();
    ctrProduct = new FormControl();
    products: ProductDetail[];
    filteredOptions: any;
    totalRow: number;
    pageIndex: number;
    pageSize: number;
    public bill: Bill;
    billDetail: any = [];
    get paymentAmount(): number {
        let value = (this.totalPrice > 0 ? this.totalPrice : this.bill.totalPrice || 0) - (this.bill.discountPrice + 0)
        if (value < 0) {
            value = 0;
            this.bill.discountPrice = this.totalPrice;
        }

        return value || 0;
    }
    set paymentAmount(value) {
    }

    get totalPrice() {
        console.log(this.billDetail);

        return this.billDetail.reduce((value, cur) => value + cur.quantity * cur.price, 0)
    }
    set totalPrice(value) {
    }

    constructor(private modalService: NgbModal,
        public bsModalRef: BsModalRef,
        public globalService: GlobalService,
        public billService: BillService,
        private productService: ProductService,
        public translate: TranslateService,
        toastr: ToastrService) {

        super(translate, toastr);
    }


    ngOnInit() {
        console.log(this.bill);

        if(this.bill == null)
            this.bill = {
                discountPrice: 0,
                totalPrice: 0 ,
                userPaymentUserName: this.globalService.currentUserName,
                billDetails: []
            };
        if (this.bill.id != null) {
            this.billService.getDetails(this.bill.id).subscribe((res: HttpResponse<BillDetail[]>) => {
                if (res.status == 200) {
                    this.billDetail = res.body;
                    this.dataSourceBillDetail = new MatTableDataSource<BillDetail>(this.billDetail);
                }
            });
        } else {
            this.dataSourceBillDetail = new MatTableDataSource<BillDetail>(this.billDetail);
        }
        //if(this.bill.discountPrice == null) this.bill.discountPrice = 0;
        console.log(this.bill);

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
                    return this.productService.getFilter(searchValue).pipe(
                        delay(100),
                        finalize(() => {
                            this.isLoadingAutocompleteProduct = false
                        }))
                })
            )
            .subscribe((res: HttpResponse<ProductDetail[]>) => {
                if (res.status == 200) {
                    this.isLoadingAutocompleteProduct = true;
                    this.products = res.body;
                    this.filteredOptions = of(res.body);
                }
            });
    }

    onSave() {
        if (this.bill.id == null) {
            let billCreateRequest: BillCreateRequest = {
                billDetails: this.billDetail,
                totalPrice: this.totalPrice,
                discountPrice: this.bill.discountPrice,
                paymentAmount: this.paymentAmount,
                userPaymentUserName: this.bill.userPaymentUserName,
                customerPhoneNumber: this.bill.customerPhoneNumber,
                customerFullName: this.bill.customerFullName,
                customerAddress: this.bill.customerAddress,
            }
            this.billService.add(billCreateRequest).subscribe((res: HttpResponse<any>) => {
                if (res.status == 200) {
                    this.notifySuccess('Success');
                    this.saved.emit("success");
                }
            });
        } else {
            // let billUpdateRequest: Bill = {
            //     id: this.bill.id,
            //     billDetails: this.billDetail,
            //     totalPrice: this.totalPrice || 0,
            //     discountPrice: this.bill.discountPrice || 0,
            //     paymentAmount: this.paymentAmount,
            //     userPaymentUserName: this.globalService.currentUserName,
            //     customerPhoneNumber: this.bill.customerPhoneNumber,
            //     customerFullName: this.bill.customerFullName,
            //     customerAddress: this.bill.customerAddress,
            // }
            let billUpdateRequest = mapper.map(this.bill,BillUpdateRequest,Bill);
            billUpdateRequest.billDetails = this.billDetail;
            billUpdateRequest.totalPrice = this.totalPrice;
            billUpdateRequest.paymentAmount = this.paymentAmount;
            this.billService.update(this.bill.id, billUpdateRequest).subscribe((res: HttpResponse<any>) => {
                if (res.status == 200) {
                    this.notifySuccess('Success');
                    this.saved.emit("success");
                }
            });
        }
    }

    displayFn(object: ProductDetail): string {
        return object && object.name ? object.name : '';
    }

    getProduct() {
        this.productService.getFilter('').subscribe((res: HttpResponse<ProductDetail[]>) => {
            if (res.status == 200) {
                this.products = res.body;
                this.filteredOptions = this.ctrProduct.valueChanges
                    .pipe(
                        startWith(''),
                        map(value => typeof value === 'string' ? value : value.name),
                        map(name => this.products.slice())
                    );
            }
        })
    }

    addProduct() {
        const product: ProductDetail = this.ctrProduct.value;

        let object = this.billDetail.find(e => e.productId == product.productId);
        if (object != null) {
            object.quantity++;
        } else {
            this.billDetail.push({ productId: product.productId, price: product.price, discountPrice: null, quantity: 1, product: product });
        }

        this.dataSourceBillDetail = new MatTableDataSource<BillDetailCreateRequest>(this.billDetail);
    }

    print() {

    }

    deleteProduct(object: BillDetailCreateRequest) {
        this.billDetail = this.billDetail.filter(e => e.productId != object.productId)
        this.dataSourceBillDetail = new MatTableDataSource<BillDetailCreateRequest>(this.billDetail);
    }

    pageEventHandle(event: PageEvent) {
        this.pageSize = event.pageSize;
        this.pageIndex = event.pageIndex + 1;
    }

    createRange(number) {
        var items: number[] = [];
        for (var i = 1; i <= number; i++) {
            items.push(i);
        }
        return items;
    }
}
