import { HttpClient, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseCreateRequest, BaseUpdateRequest, BaseViewModel, OPTIONS_DEFAULT, OPTIONS_JSON } from '@app/models';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { BaseService } from './base.service';


export abstract class CrudService<TCreateRequest extends BaseCreateRequest, TUpdateRequest extends BaseUpdateRequest, TView extends BaseViewModel, TKey> extends BaseService
{

    constructor(http: HttpClient, public controllerName: string) {
        super(http, controllerName);
    }

    add(entity: FormData | TCreateRequest) {
        let data : FormData | TCreateRequest | string = entity;
        let options = OPTIONS_DEFAULT;
        if (!(entity instanceof FormData)){
            console.log();

            data = JSON.stringify(entity);
            options = OPTIONS_JSON;
        }
        console.log(options)
        return this.http.post(`${this.apiUrl}`, data, options).pipe();
    }

    update(id: TKey, entity: FormData | TUpdateRequest) {
        let data: FormData | TUpdateRequest | string = entity;
        let options = OPTIONS_DEFAULT;
        if (!(entity instanceof FormData)){
            data = JSON.stringify(entity);
            options = OPTIONS_JSON;
        }
        let url = `${this.apiUrl}/${id}`;

        return this.http.put(url, data, options).pipe();
    }

    getPaging(pageIndex: number, pageSize: number, searchText: string) {
        let url = `${this.apiUrl}/filter?pageIndex=${pageIndex}&pageSize=${pageSize}&searchText=${searchText}&langId=${localStorage.getItem('lang')}`;

        return this.http.get(url, OPTIONS_JSON).pipe(catchError(this.handleError));
    }

    getById(id: TKey) {
        let url = `${this.apiUrl}/${id}&langId=${localStorage.getItem('lang')}`;

        return this.http.get(url, OPTIONS_JSON).pipe(catchError(this.handleError));
    }

    delete(id: TKey) {
        let url = `${this.apiUrl}/${id}`;

        return this.http.delete(url, OPTIONS_JSON).pipe(catchError(this.handleError));
    }


}
