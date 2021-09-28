import { Component, EventEmitter, OnInit } from '@angular/core';
import { BaseComponent } from '@app/components/base';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import * as Models from '@app/models';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FunctionService } from '@app/shared/services';
import { FunctionViewModel } from '@app/models';
import { HttpResponse } from '@angular/common/http';
import { FormControl } from '@angular/forms';
import { debounceTime, delay, finalize, switchMap, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';

@Component({
    selector: 'app-functions-detail',
    templateUrl: './functions-detail.component.html',
    styleUrls: ['./functions-detail.component.scss']
})
export class FunctionsDetailComponent extends BaseComponent implements OnInit {

    constructor(
        private functionService: FunctionService,
        public translate: TranslateService,
        protected toastr: ToastrService,
        public bsModalRef: BsModalRef,
    ) {
        super(translate, toastr);
    }

    saved: EventEmitter<any> = new EventEmitter();
    public function: Models.FunctionViewModel;
    public functionId: any;
    cbFunctions: FunctionViewModel[];
    ctrFunction = new FormControl();
    isLoadingAutocompleteFunction: boolean;
    filteredOptions: Observable<FunctionViewModel[]>;
    ngOnInit() {
        this.ctrFunction.valueChanges
            .pipe(
                debounceTime(500),
                tap(() => {
                    this.isLoadingAutocompleteFunction = true;
                }), switchMap(searchValue => {
                    this.isLoadingAutocompleteFunction = true;
                    return this.functionService.getFunctionsWithoutChildren(searchValue).pipe(
                        delay(100),
                        finalize(() => {
                            this.isLoadingAutocompleteFunction = false
                        }))
                }))
            .subscribe((res: HttpResponse<FunctionViewModel[]>) => {
                if (res.status == 200) {

                    this.isLoadingAutocompleteFunction = true;
                    console.log(this.isLoadingAutocompleteFunction);
                    this.cbFunctions = res.body;
                    this.filteredOptions = of(res.body.filter(e => e.id != this.functionId));
                }
            });
        this.function = new Models.FunctionViewModel();
        if (this.functionId != null) {
            this.functionService.getById(this.functionId).subscribe((res: HttpResponse<FunctionViewModel>) => {
                if (res.status == 200) {
                    this.function = res.body
                }
                this.getFunctionsWithoutChildren();
            });
        } else {
            this.getFunctionsWithoutChildren();
        }
    }

    displayFn(functionViewModel: FunctionViewModel): string {
        return functionViewModel && functionViewModel.name ? functionViewModel.name : '';
    }

    getFunctionsWithoutChildren() {
        this.functionService.getFunctionsWithoutChildren().subscribe((res: HttpResponse<FunctionViewModel[]>) => {
            if (res.status == 200) {
                this.ctrFunction.setValue(res.body.find(e => e.id == this.function.parentId));
                this.filteredOptions = of(res.body.filter(e => e.id != this.functionId));
            }
        });
    }
    onSave() {
        this.function.parentId = this.ctrFunction.value.id;
        if (this.function.id == null) {
            this.functionService.add(this.function).subscribe((res: HttpResponse<FunctionViewModel>) => {
                if (res.status == 200) {
                    this.translate.get('Success').subscribe(e => {
                        this.toastr.success(e)
                    });
                    this.saved.emit("success");
                }

            })

        }else{
            this.functionService.update(this.function.id, this.function).subscribe((res: HttpResponse<FunctionViewModel>) => {
                if (res.status == 200) {
                    this.translate.get('Success').subscribe(e => {
                        this.toastr.success(e)
                    });
                    this.saved.emit("success");
                }
            })
        }
    }
}
