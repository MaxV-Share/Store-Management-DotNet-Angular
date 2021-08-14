import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '@app/components/base';
import { HTTP_STATUS } from '@app/models';
import { Role } from '@app/models/view-models';
import { RoleService } from '@app/shared/services';
import { TranslateService } from '@ngx-translate/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { RoleDetailComponent } from './role-detail/role-detail.component';

@Component({
    selector: 'app-roles',
    templateUrl: './roles.component.html',
    styleUrls: ['./roles.component.scss']
})
export class RolesComponent extends BaseComponent implements OnInit {

    constructor(
        protected toastr: ToastrService,
        public roleService: RoleService,
        protected translate: TranslateService,
        private modalService: BsModalService,) {
        super(translate, toastr);

    }

    cols: any[];
    roles: Observable<Role[]>;
    showMenu: any = '';
    public bsModalRef: BsModalRef;

    ngOnInit() {
        this.cols = [
            { field: 'name', header: 'Name' },
        ];
        this.loadRole();

    }
    loadRole() {
        this.roles = this.roleService.getAll().pipe(map((res: HttpResponse<Role[]>) => {
            console.log(res);
            if (HTTP_STATUS.Ok == res.status || HTTP_STATUS.NoContent == res.status) {
                return res.body;
            }
            return []
        }))
    }
    createOrUpdate(entity: Role) {

        const initialState = {
            role: entity == null ? null : Object.assign({}, entity),
        };

        this.bsModalRef = this.modalService.show(RoleDetailComponent, {
            initialState: initialState,
            class: 'modal-lg',
            backdrop: 'static'
        });
        this.bsModalRef.content.saved.subscribe((e) => {
            this.bsModalRef.hide();
            this.loadRole();
        });
    }
    delete(id) {
        this.roleService.delete(id).subscribe((res: HttpResponse<any>) => {
            if (HTTP_STATUS.Ok == res.status) {
                this.translate.get('Success').subscribe(e => {
                    this.toastr.success(e)
                });
                this.loadRole();
            }
        })
    }

}
