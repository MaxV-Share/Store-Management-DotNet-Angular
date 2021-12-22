import { Injectable } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";
import { ToastrService } from "ngx-toastr";
@Injectable()
export abstract class BaseComponent {
    constructor(
        protected translate: TranslateService,
        protected toastr: ToastrService){

    }

    notifySuccess(message: string = 'Success')
    {
        this.translate.get(message).subscribe(e => {
            this.toastr.success(e)
        });
    }

    notifyError(message: string = 'Error')
    {
        this.translate.get(message).subscribe(e => {
            this.toastr.error(e)
        });
    }

    notifyWarning(message: string = 'Warning')
    {
        this.translate.get(message).subscribe(e => {
            this.toastr.warning(e)
        });
    }
}
