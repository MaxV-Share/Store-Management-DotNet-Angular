import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category,   CategoryCreateRequest , ENVIRONMENT, OPTIONS_JSON } from '@app/models';
import { TranslateService } from '@ngx-translate/core';
import { BaseService } from './base/base.service';
import { IBaseService } from './interface';

@Injectable({
    providedIn: 'root'
})
export class CategoryService extends BaseService implements IBaseService<CategoryCreateRequest,Category> {

    constructor(http: HttpClient,
        public translate: TranslateService) {
        super(http);
    }

    add(entity: CategoryCreateRequest) {
        return this.http.post(`${ENVIRONMENT.apiUrl}/api/categories`, JSON.stringify(entity), OPTIONS_JSON)
            .pipe();
    }

    update(id: number, entity: Category) {
        return this.http.put(`${ENVIRONMENT.apiUrl}/api/categories/${id}`, JSON.stringify(entity), OPTIONS_JSON)
            // .pipe(catchError(this.handleError));
    }

    getPaging(pageIndex:number, pageSize: number, searchText: string) {
        return this.http.get(`${ENVIRONMENT.apiUrl}/api/categories/filter?pageIndex=${pageIndex}&pageSize=${pageSize}&searchText=${searchText}&langId=${localStorage.getItem('lang')}`, OPTIONS_JSON)
            // .pipe(catchError(this.handleError));
    }

    getAll(searchText: string = '') {
        return this.http.get(`${ENVIRONMENT.apiUrl}/api/categories?searchText=${searchText}&langId=${localStorage.getItem('lang')}`, OPTIONS_JSON)
            // .pipe(catchError(this.handleError));
    }

    getById(id:number) {
        return this.http.get(`${ENVIRONMENT.apiUrl}/api/categories/${id}?langId=${this.translate.currentLang}`, OPTIONS_JSON)
            // .pipe(catchError(this.handleError));
    }
}
