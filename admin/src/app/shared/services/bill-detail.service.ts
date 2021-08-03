import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from './base/base.service';
import { CrudService } from './base/crud.service';
import { BillCreateRequest } from '../../models/create-requests/bill-create-request';
import { Bill, BillUpdateRequest } from '@app/models';

@Injectable({
  providedIn: 'root'
})
export class BillDetailService extends CrudService<BillCreateRequest,BillUpdateRequest,Bill, number> {

    constructor(http: HttpClient) {
        super(http,'');
    }

}
