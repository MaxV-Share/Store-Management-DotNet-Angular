import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ENVIRONMENT } from '@app/models';
import { throwError } from 'rxjs';
export abstract class BaseService {

    public apiUrl: string;

    constructor(public http: HttpClient, public controllerName: string) {
        this.apiUrl = `${ENVIRONMENT.apiUrl}/${controllerName}`;
    }
    public handleError(error: any) {

        const applicationError = error.headers.get('Application-Error');

        // either application-error in header or model error in body
        if (applicationError) {
            return throwError(applicationError);
        }

        let modelStateErrors = '';

        // for now just concatenate the error descriptions, alternative we could simply pass the entire error response upstream
        for (const key in error.error) {
            if (error.error[key]) { modelStateErrors += error.error[key].description + '\n'; }
        }

        modelStateErrors = modelStateErrors = '' ? null : modelStateErrors;
        return throwError(modelStateErrors || 'Server error');
    }
}

