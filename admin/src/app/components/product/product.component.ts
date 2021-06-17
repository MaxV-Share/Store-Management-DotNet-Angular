import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { TranslateService } from '@ngx-translate/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { environment, ProductDetail } from '@app/models';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductService } from '@app/shared/services/product.service';
import { ProductDetailPaging } from '@app/models/paging/product-detail-paging';

@Component({
    selector: 'app-product',
    templateUrl: './product.component.html',
    styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {

    constructor(private modalService: BsModalService,
        private toastr: ToastrService,
        private productService: ProductService,
        public translate: TranslateService) { }

    displayedColumns: string[] = ['no', 'name','image-url', 'description', 'edit'];
    dataSource = new MatTableDataSource<ProductDetail>();
    txtSearch: string;
    public bsModalRef: BsModalRef;
    totalRow: number;
    pageIndex: number;
    pageSize: number;
    environment: any;
    ngOnInit() {
        this.environment = environment
        this.pageIndex = 1;
        this.pageSize = 5;
        this.txtSearch = "";
        this.getPaging(this.pageIndex, this.pageSize, this.translate.currentLang, "");
    }
    onSearch(){

    }
    createOrUpdate(productId: number = null){

        const initialState = {
            productId: productId,
        };

        this.bsModalRef = this.modalService.show(ProductDetailComponent, {
            initialState: initialState,
            class: 'modal-lg',
            backdrop: 'static'
        });

        this.bsModalRef.content.saved.subscribe((e) => {
            console.log(e);
            this.bsModalRef.hide();
        });
    }

    getPaging(pageIndex: number, pageSize: number, langId: string, searchText: string) {
        //this.subscription.add(
        this.productService.getPaging(pageIndex, pageSize, langId, searchText).subscribe((res: ProductDetailPaging) => {
            this.dataSource = new MatTableDataSource<ProductDetail>(res.data);
            console.log(res.data);

            this.totalRow = res.totalRow;
        })//)
    }

    pageEventHandle(event: PageEvent) {
        this.pageSize = event.pageSize;
        this.pageIndex = event.pageIndex + 1;
        this.getPaging(this.pageIndex, this.pageSize, this.translate.currentLang, this.txtSearch);
    }

}
