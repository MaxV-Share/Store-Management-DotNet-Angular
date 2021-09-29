import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Bill, BillCreateRequest, BillUpdateRequest, ENVIRONMENT, OPTIONS_JSON } from '@app/models';
import { TranslateService } from '@ngx-translate/core';
import { Observable } from 'rxjs';
import { BaseService } from './base/base.service';
import { CrudService } from './base/crud.service';

@Injectable({
    providedIn: 'root'
})
export class BillService extends CrudService<BillCreateRequest, BillUpdateRequest,Bill,number> {

    constructor(http: HttpClient,
        public translate: TranslateService) {
        super(http,'bills');
    }
    // add(entity: BillCreateRequest) {
    //     return this.http.post(`${this.apiUrl}`, JSON.stringify(entity), OPTIONS_JSON)
    //         .pipe();
    // }
    // update(id: any, entity: Bill) {
    //     return this.http.put(`${this.apiUrl}/${id}`, JSON.stringify(entity), OPTIONS_JSON).pipe();
    //     // .pipe(catchError(this.handleError));
    // }
    // delete(id: any) {
    //     return this.http.delete(`${this.apiUrl}`, OPTIONS_JSON).pipe();
    //     // .pipe(catchError(this.handleError));
    // }
    getPaging(pageIndex: number, pageSize: number, searchText: string) {
        let url = `${this.apiUrl}/filter-paging?pageIndex=${pageIndex}&pageSize=${pageSize}&searchText=${searchText}&langId=${this.translate.currentLang}`;
        return this.http.get(url,OPTIONS_JSON);
        // .pipe(catchError(this.handleError));
    }
    getAll() {
        return this.http.get(`${this.apiUrl}`, OPTIONS_JSON);
        // .pipe(catchError(this.handleError));
    }
    getDetails(billId: any) {
        let url = `${this.apiUrl}/${billId}/details?langId=${this.translate.currentLang}`
        return this.http.get(url, OPTIONS_JSON)
        // .pipe(catchError(this.handleError));
    }

}
