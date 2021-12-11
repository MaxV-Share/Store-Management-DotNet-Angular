import { Injectable } from '@angular/core';
import { Role, RoleCreateRequest, RoleUpdateRequest } from '@app/models';
import { CrudService } from './base/crud.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RoleService extends CrudService<RoleCreateRequest,RoleUpdateRequest,Role,string> {

    constructor(http: HttpClient) {
        super(http, 'roles');
    }

}
