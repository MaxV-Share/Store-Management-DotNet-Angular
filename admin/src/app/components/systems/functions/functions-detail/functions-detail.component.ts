import { Component, EventEmitter, OnInit } from '@angular/core';
import { BaseComponent } from '@app/components/base';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import * as Models from '@app/models';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-functions-detail',
    templateUrl: './functions-detail.component.html',
    styleUrls: ['./functions-detail.component.scss']
})
export class FunctionsDetailComponent extends BaseComponent implements OnInit {

    constructor(
        public translate: TranslateService,
        protected toastr: ToastrService,
        public bsModalRef: BsModalRef,
        ) {
        super(translate, toastr);
    }

    saved: EventEmitter<any> = new EventEmitter();
    public function: Models.FunctionViewModel;

    ngOnInit() {
        this.function = new Models.FunctionViewModel();
    }
    onSave(){

    }
}
