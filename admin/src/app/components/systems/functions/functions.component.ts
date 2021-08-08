import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { BaseComponent } from '@app/components/base';
import * as Models from "@app/models"
import { TranslateService } from '@ngx-translate/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { FunctionsDetailComponent } from './functions-detail/functions-detail.component';
import { TreeNode } from 'primeng/api';
import { FunctionService } from '@app/shared/services/function.service';
import { HttpResponse } from '@angular/common/http';
import { FunctionViewModel, HTTP_STATUS } from '@app/models';

@Component({
    selector: 'app-function',
    templateUrl: './functions.component.html',
    styleUrls: ['./functions.component.scss']
})
export class FunctionsComponent extends BaseComponent implements OnInit {

    constructor(
        protected toastr: ToastrService,
        protected translate: TranslateService,
        private functionService: FunctionService,
        private modalService: BsModalService,) {
        super(translate, toastr);
    }

    treeFunctions: TreeNode[];

    functions: Models.FunctionViewModel[];
    displayedColumns: string[] = ['no', 'function-name', 'url', 'sort-order', 'parent-id', 'icon', 'edit'];
    dataSource = new MatTableDataSource<Models.FunctionViewModel>();
    txtSearch: string = "";
    public bsModalRef: BsModalRef;
    cols: any[];
    showMenu: any = '';

    ngOnInit() {
        this.cols = [
            { field: 'name', header: 'Name' },
            { field: 'icon', header: 'Icon' },
            { field: 'url', header: 'Url' }
        ];
        this.loadFunction();
    }

    onSearch() {

    }

    addExpandClass(a) {
        this.showMenu = this.showMenu == a ? '' : a;
        console.log(this.showMenu);
    }

    createOrUpdate(entity: FunctionViewModel) {

        const initialState = {
            functionId: entity?.id,
        };

        this.bsModalRef = this.modalService.show(FunctionsDetailComponent, {
            initialState: initialState,
            class: 'modal-lg',
            backdrop: 'static'
        });

        this.bsModalRef.content.saved.subscribe((e) => {
            this.bsModalRef.hide();
            this.loadFunction();
        });
    }
    edit(any) {
        console.log(any);

    }
    loadFunction() {
        this.functionService.getTree().subscribe((res: HttpResponse<any>) => {
            this.treeFunctions = <TreeNode[]>res.body;
            console.log(this.treeFunctions);
        })
    }
    delete(functionId) {
        this.functionService.delete(functionId).subscribe((res: HttpResponse<any>) => {
            if (HTTP_STATUS.Ok == res.status || HTTP_STATUS.NoContent == res.status) {
                this.translate.get('Success').subscribe(e => {
                    this.toastr.success(e)
                });
            }
            this.loadFunction();
        });
    }
}
