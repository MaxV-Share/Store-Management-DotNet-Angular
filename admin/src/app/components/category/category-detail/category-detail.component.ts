import { Component, EventEmitter, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Lang, Category, LANGS, CategoryDetail, CategoryCreateRequest } from '@app/models';
import { CategoryService } from '@app/shared/services';
import { Subscription } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { HttpResponse } from '@angular/common/http';
import { BaseComponent } from '@app/models/bases';

@Component({
    selector: 'app-category-detail',
    templateUrl: './category-detail.component.html',
    styleUrls: ['./category-detail.component.scss']
})
export default class CategoryDetailComponent extends BaseComponent implements OnInit {

    constructor(private modalService: NgbModal,
        public bsModalRef: BsModalRef,
        private categoryService: CategoryService,
        public toastr: ToastrService,
        public translate: TranslateService) {
        super(translate,toastr);
    }
    langs: Lang[];
    public id: number;
    saved: EventEmitter<any> = new EventEmitter();
    public entity: any;
    private subscription = new Subscription();

    ngOnInit() {
        this.langs = LANGS;
        let objCreate: CategoryCreateRequest = {
            details: [
                {
                    langId: 'vi',
                    name: '',
                    description: '',
                },
                {
                    langId: 'en',
                    name: '',
                    description: '',
                }
            ]
        }
        this.entity = objCreate;
        if (this.id != null) {
            this.subscription.add(this.categoryService.getById(this.id).subscribe((res: HttpResponse<any> ) => {
                if(res.status == 200){
                    this.entity = res.body;
                }
            },err => {
                console.error(err);
                this.notifyError("Error");
            }))
        }

    }

    onSave() {
        if (this.id == null) {
            this.add();
        } else {
            this.update(this.id);
        }
    }

    add() {
        this.subscription.add(this.categoryService.add(this.entity)
            .subscribe(() => {
                this.toastr.success('Success');
                this.saved.emit("success");
                console.log("success");
                // setTimeout(() => { this.blockedPanel = false; this.btnDisabled = false; }, 1000);
            }, err => {
                // this.notificationService.showError(MessageConstants.DEFAULT_ERROR_MSG);
                // console.log(error);
                // setTimeout(() => { this.blockedPanel = false; this.btnDisabled = false; }, 1000);
                console.error(err)
            }));
    }

    update(id: number) {
        this.subscription.add(this.categoryService.update(id, this.entity)
            .subscribe(() => {
                this.toastr.success('Success');
                this.saved.emit("success");
                console.log("success")
                // setTimeout(() => { this.blockedPanel = false; this.btnDisabled = false; }, 1000);
            }, err => {
                // this.notificationService.showError(MessageConstants.DEFAULT_ERROR_MSG);
                // console.log(error);
                // setTimeout(() => { this.blockedPanel = false; this.btnDisabled = false; }, 1000);
                console.error(err)
            }));
    }

    changeTab(index: number) {
        // console.log(this.langs[index].id);
        // this.translate.use(this.langs[index].id);
    }
}
