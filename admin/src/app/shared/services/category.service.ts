import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category, CategoryCreateRequest, CategoryUpdateRequest, ENVIRONMENT, OPTIONS_JSON } from '@app/models';
import { TranslateService } from '@ngx-translate/core';
import { BaseService } from './base/base.service';
import { CrudService } from './base/crud.service';

@Injectable({
    providedIn: 'root'
})
export class CategoryService extends CrudService<CategoryCreateRequest, CategoryUpdateRequest, Category, number> {

    constructor(http: HttpClient,
        public translate: TranslateService) {
        super(http, 'categories');
    }

    getAll(searchText: string = '') {
        return this.http.get(`${ENVIRONMENT.apiUrl}/${this.controllerName}/filter?searchText=${searchText}&langId=${localStorage.getItem('lang')}`, OPTIONS_JSON)
        // .pipe(catchError(this.handleError));
    }

    getById(id: number) {
        return this.http.get(`${ENVIRONMENT.apiUrl}/${this.controllerName}/${id}?langId=${this.translate.currentLang}`, OPTIONS_JSON)
        // .pipe(catchError(this.handleError));
    }
}
