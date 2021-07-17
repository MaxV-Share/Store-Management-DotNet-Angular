import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { CategoryDetail, CategoryDetailPaging } from '@app/models';
import { BaseComponent } from '@app/models/bases';
import { CategoryService } from '@app/shared/services';
import { GlobalService } from '@app/shared/services/global.service';
import { TranslateService } from '@ngx-translate/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import CategoryDetailComponent from './category-detail/category-detail.component';

@Component({
    selector: 'app-category',
    templateUrl: './category.component.html',
    styleUrls: ['./category.component.scss']
})
export class CategoryComponent extends BaseComponent implements OnInit {

    constructor(private modalService: BsModalService,
        private categoryService: CategoryService,
        public toastr: ToastrService,
        public translate: TranslateService) {
        super(translate,toastr);
    }

    public bsCategoryModalRef: BsModalRef;
    dataSource = new MatTableDataSource<CategoryDetail>();
    txtSearch: string;
    displayedColumns: string[] = ['no', 'name', 'description', 'edit'];
    private subscription = new Subscription();
    totalRow: number;
    pageIndex: number;
    pageSize: number;
    ngOnInit() {
        this.pageIndex = 1;
        this.pageSize = 5;
        this.txtSearch = "";
        this.getPaging(this.pageIndex, this.pageSize, "");
        const buttonEl = document.querySelector("button");
        const handler = e => console.log("clicked", e);
        buttonEl.addEventListener("click", handler);
    }

    createOrUpdate(id: number = null) {

        const initialState = {
            id: id,
        };

        this.bsCategoryModalRef = this.modalService.show(CategoryDetailComponent, {
            initialState: initialState,
            class: 'modal-lg',
            backdrop: 'static'
        });

        this.bsCategoryModalRef.content.saved.subscribe((e) => {
            this.bsCategoryModalRef.hide();
            this.getPaging(this.pageIndex, 5, "");
        });
    }

    getPaging(pageIndex: number, pageSize: number, searchText: string) {
        this.categoryService.getPaging(pageIndex, pageSize, searchText).subscribe((res: HttpResponse<CategoryDetailPaging>) => {
            if(res.status == 200){
                this.dataSource = new MatTableDataSource<CategoryDetail>(res.body.data);
                this.totalRow = res.body.totalRow;
            }else{
                console.log(res);
            }
        })
    }
    onSearch() {

    }
    pageEventHandle(event: PageEvent) {
        this.pageSize = event.pageSize;
        this.pageIndex = event.pageIndex + 1;
        this.getPaging(this.pageIndex, this.pageSize, this.txtSearch);
    }
}
