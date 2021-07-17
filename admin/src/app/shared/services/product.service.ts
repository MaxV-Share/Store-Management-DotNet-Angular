import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ENVIRONMENT, OPTIONS_DEFAULT, OPTIONS_JSON } from '@app/models';
import { TranslateService } from '@ngx-translate/core';
import { BaseService } from './base/base.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService extends BaseService{

    constructor(http: HttpClient,
        public translate: TranslateService) {
        super(http);
    }

    add(formData: FormData){
        return this.http.post(`${ENVIRONMENT.apiUrl}/api/products`, formData, OPTIONS_DEFAULT)
        .pipe();
    }

    update(id?: number, formData?: FormData){
        return this.http.put(`${ENVIRONMENT.apiUrl}/api/products/${id}`, formData, OPTIONS_DEFAULT)
        .pipe();
    }

    getPaging(pageIndex:number, pageSize: number, searchText: string) {
        return this.http.get(`${ENVIRONMENT.apiUrl}/api/products/filter?pageIndex=${pageIndex}&pageSize=${pageSize}&searchText=${searchText}&langId=${localStorage.getItem('lang')}`, OPTIONS_JSON)
            // .pipe(catchError(this.handleError));
    }

    getAll(searchText: string) {
        return this.http.get(`${ENVIRONMENT.apiUrl}/api/products?searchText=${searchText}&langId=${localStorage.getItem('lang')}`, OPTIONS_JSON)
            // .pipe(catchError(this.handleError));
    }

    getById(id: number){
        return this.http.get(`${ENVIRONMENT.apiUrl}/api/products/${id}`, OPTIONS_JSON)
    }
}
