import { Component, EventEmitter, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Lang, Category, langs, CategoryDetail, CategoryCr } from '@app/models';
import { CategoryService } from '@app/shared/services';
import { Subscription } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-category-detail',
    templateUrl: './category-detail.component.html',
    styleUrls: ['./category-detail.component.scss']
})
export default class CategoryDetailComponent implements OnInit {

    constructor(private modalService: NgbModal,
        public bsModalRef: BsModalRef,
        private categoryService: CategoryService,
        private toastr: ToastrService,
        public translate: TranslateService) {

    }
    langs: Lang[];
    public id: number;
    saved: EventEmitter<any> = new EventEmitter();
    entity: any;
    private subscription = new Subscription();

    ngOnInit() {
        this.langs = langs;
        if (this.entity == null) {
            let objCreate: CategoryCr = {
                details: [
                    {
                        langId: 'vi',
                        name: '',
                        description: '1',
                    },
                    {
                        langId: 'en',
                        name: '',
                        description: '2',
                    }
                ]
            }
            this.entity = objCreate;
        }
    }

    onSave() {
        this.toastr.success('Success');
        // this.subscription.add(this.categoryService.add(this.entity)
        //     .subscribe(() => {
        //         this.saved.emit("success");
        //         console.log("success")
        //         // setTimeout(() => { this.blockedPanel = false; this.btnDisabled = false; }, 1000);
        //     }, err => {
        //         // this.notificationService.showError(MessageConstants.DEFAULT_ERROR_MSG);
        //         // console.log(error);
        //         // setTimeout(() => { this.blockedPanel = false; this.btnDisabled = false; }, 1000);
        //         console.error(err)
        //     }));
        // this.saved.emit("Saved");
        // console.log(this.entity);
    }
    changeTab(index: number) {
        // console.log(this.langs[index].id);
        // this.translate.use(this.langs[index].id);

    }

}
