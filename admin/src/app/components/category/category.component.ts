import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import CategoryDetailComponent from './category-detail/category-detail.component';

@Component({
    selector: 'app-category',
    templateUrl: './category.component.html',
    styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {

    constructor(private modalService: BsModalService, private toastr: ToastrService, public translate: TranslateService) { }

    public bsModalRef: BsModalRef;
    ngOnInit() {
    }
    createOrUpdate(id: number = null) {

        const initialState = {
            id: id,
        };

        this.bsModalRef = this.modalService.show(CategoryDetailComponent, {
            initialState: initialState,
            class: 'modal-lg',
            backdrop: 'static'
        });

        this.bsModalRef.content.saved.subscribe((e) => {
            console.log(e);
            this.bsModalRef.hide();
        });
    }

}
