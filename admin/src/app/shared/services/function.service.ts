import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FunctionCreateRequest, FunctionUpdateRequest, FunctionViewModel, OPTIONS_JSON } from '@app/models';
import { TranslateService } from '@ngx-translate/core';
import { catchError } from 'rxjs/operators';
import { CrudService } from './base/crud.service';

@Injectable({
  providedIn: 'root'
})
export class FunctionService extends CrudService<FunctionCreateRequest, FunctionUpdateRequest, FunctionViewModel, string> {

    constructor(http: HttpClient,
        public translate: TranslateService) {
        super(http, 'functions');
    }
    getTree(){
        let url = `${this.apiUrl}/tree`;
        return this.http.get(url, OPTIONS_JSON).pipe(catchError(this.handleError));
    }
    getTreeNode(){
        let url = `${this.apiUrl}/tree-node`;
        return this.http.get(url, OPTIONS_JSON).pipe(catchError(this.handleError));
    }
    getFunctionsWithoutChildren(textSearch: string = "") {
        let url = `${this.apiUrl}/without-children?textSearch=${textSearch}`;
        return this.http.get(url, OPTIONS_JSON).pipe(catchError(this.handleError));
    }
}
