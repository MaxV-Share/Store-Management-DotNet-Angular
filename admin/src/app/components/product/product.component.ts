import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { TranslateService } from '@ngx-translate/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { ENVIRONMENT, ProductDetail } from '@app/models';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductService } from '@app/shared/services/product.service';
import { ProductDetailPaging } from '@app/models/view-models/paging/product-detail-paging';
import { HttpResponse } from '@angular/common/http';
import { BaseComponent } from '@app/components/base';

@Component({
    selector: 'app-product',
    templateUrl: './product.component.html',
    styleUrls: ['./product.component.scss']
})
export class ProductComponent extends BaseComponent implements OnInit {

    constructor(
        toastr: ToastrService,
        translate: TranslateService,
        private modalService: BsModalService,
        private productService: ProductService,) {
        super(translate, toastr);
    }

    displayedColumns: string[] = ['no', 'image', 'product-code', 'product-name', 'price', 'description', 'edit'];
    dataSource = new MatTableDataSource<ProductDetail>();
    txtSearch: string;
    public bsModalRef: BsModalRef;
    totalRow: number;
    pageIndex: number;
    pageSize: number;
    ENVIRONMENT: any;
    ngOnInit() {
        this.ENVIRONMENT = ENVIRONMENT
        this.pageIndex = 1;
        this.pageSize = 5;
        this.txtSearch = "";
        this.getPaging(this.pageIndex, this.pageSize, "");


    }
    onSearch() {

    }
    createOrUpdate(productId: number = null) {
        const initialState = {
            productId: productId,
        };

        this.bsModalRef = this.modalService.show(ProductDetailComponent, {
            initialState: initialState,
            class: 'modal-lg',
            backdrop: 'static'
        });

        this.bsModalRef.content.saved.subscribe((e) => {
            this.bsModalRef.hide();
            this.getPaging(this.pageIndex, this.pageSize, "");
        });
    }

    getPaging(pageIndex: number, pageSize: number, searchText: string) {
        this.productService.getPaging(pageIndex, pageSize, searchText).subscribe((res: HttpResponse<ProductDetailPaging>) => {
            if (res.status == 200) {
                this.dataSource = new MatTableDataSource<ProductDetail>(res.body.data);
                this.totalRow = res.body.totalRow;
            }
        })
    }

    pageEventHandle(event: PageEvent) {
        this.pageSize = event.pageSize;
        this.pageIndex = event.pageIndex + 1;
        this.getPaging(this.pageIndex, this.pageSize, this.txtSearch);
    }
}
