import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { TranslateService } from '@ngx-translate/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { ProductDetail } from '../../models';
import { ProductDetailComponent } from './product-detail/product-detail.component';

@Component({
    selector: 'app-product',
    templateUrl: './product.component.html',
    styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {

    constructor(private modalService: BsModalService, private toastr: ToastrService, private translate: TranslateService) { }

    displayedColumns: string[] = ['no', 'name', 'weight', 'edit'];
    dataSource = new MatTableDataSource<ProductDetail>();
    txtSearch: string;
    public bsModalRef: BsModalRef;
    ngOnInit() {
        //this.createOrUpdate();
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
    
    private getDataPaging(event: PageEvent) {
        // var data: Discount[] = [];
        // let indexTo = event.pageIndex * event.pageSize + event.pageSize;
        // let indexFrom = event.pageIndex * event.pageSize;
        // for (let i = 0; i < ELEMENT_DATA.length; i++) {
        //     if (i < indexFrom)
        //         continue;
        //     if (i >= indexTo)
        //         break;
        //     data.push(ELEMENT_DATA[i]);
        // }
        // this.dataSource = new MatTableDataSource<Discount>(data);
    }

    private pageEventHandle(event?: PageEvent) {
        this.getDataPaging(event);
        return event;
    }

}
