import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ENVIRONMENT, OPTIONS_DEFAULT, OPTIONS_JSON, Product, ProductCreateRequest, ProductUpdateRequest } from '@app/models';
import { TranslateService } from '@ngx-translate/core';
import { BaseService } from './base/base.service';
import { CrudService } from './base/crud.service';

@Injectable({
    providedIn: 'root'
})
export class ProductService extends CrudService<ProductCreateRequest, ProductUpdateRequest, Product, number> {

    constructor(http: HttpClient,
        public translate: TranslateService) {
        super(http, 'products');
    }

    getPaging(pageIndex: any, pageSize: number, searchText: string) {
        return this.http.get(`${this.apiUrl}/filter?pageIndex=${pageIndex}&pageSize=${pageSize}&searchText=${searchText}&langId=${localStorage.getItem('lang')}`, OPTIONS_JSON)
        // .pipe(catchError(this.handleError));
    }

    getAll(searchText: string) {
        return this.http.get(`${ENVIRONMENT.apiUrl}/products?searchText=${searchText}&langId=${localStorage.getItem('lang')}`, OPTIONS_JSON)
        // .pipe(catchError(this.handleError));
    }

    getById(id: any) {
        return this.http.get(`${ENVIRONMENT.apiUrl}/products/${id}`, OPTIONS_JSON)
    }
}
