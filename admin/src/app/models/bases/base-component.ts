import { Injectable } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";
import { ToastrService } from "ngx-toastr";
@Injectable()
export abstract class BaseComponent {
    constructor(
        protected translate: TranslateService,
        protected toastr: ToastrService){

    }

    notifySuccess(message: string)
    {
        this.translate.get('Success').subscribe(e => {
            this.toastr.success(e)
        });
    }

    notifyError(message: string)
    {
        this.translate.get('Success').subscribe(e => {
            this.toastr.error(e)
        });
    }

    notifyWarning(message: string)
    {
        this.translate.get('Success').subscribe(e => {
            this.toastr.warning(e)
        });
    }
}
