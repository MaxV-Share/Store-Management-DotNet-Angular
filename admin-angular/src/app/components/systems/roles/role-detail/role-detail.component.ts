import { HttpResponse } from '@angular/common/http';
import { Component, EventEmitter, OnInit } from '@angular/core';
import { BaseComponent } from '@app/components/base';
import { HTTP_STATUS, Role } from '@app/models';
import { RoleService } from '@app/shared/services';
import { TranslateService } from '@ngx-translate/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-role-detail',
    templateUrl: './role-detail.component.html',
    styleUrls: ['./role-detail.component.scss']
})
export class RoleDetailComponent extends BaseComponent implements OnInit {

    constructor(
        public translate: TranslateService,
        public roleService: RoleService,
        protected toastr: ToastrService,
        public bsModalRef: BsModalRef,) {
        super(translate, toastr);
    }
    saved: EventEmitter<any> = new EventEmitter();
    role: Role;
    status: number; // 0: create, 1: update
    ngOnInit() {
        console.log(this.role);
        if(this.role == null){
            this.status = 0;
            this.role = new Role();
        }else{
            this.status = 1;
        }
        console.log(this.role);
    }
    onSave(){
        if(this.status == 0){
            this.roleService.add(this.role).subscribe((res : HttpResponse<any>) =>{

                if (HTTP_STATUS.Ok == res.status || HTTP_STATUS.NoContent == res.status) {
                    this.translate.get('Success').subscribe(e => {
                        this.toastr.success(e)
                    });
                    this.saved.emit("success");
                }
            })
        }else{
            this.roleService.update(this.role.id,this.role).subscribe((res : HttpResponse<any>) =>{
                if (HTTP_STATUS.Ok == res.status || HTTP_STATUS.NoContent == res.status) {
                    this.translate.get('Success').subscribe(e => {
                        this.toastr.success(e)
                    });
                    this.saved.emit("success");
                }
            })
        }
    }
}
