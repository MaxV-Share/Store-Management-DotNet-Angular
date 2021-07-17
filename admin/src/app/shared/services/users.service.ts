import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ENVIRONMENT, OPTIONS_JSON, User } from '@app/models';
import { catchError, map } from 'rxjs/operators';
import { BaseService } from './base/base.service';

@Injectable({
    providedIn: 'root'
})
export class UsersService extends BaseService {

    constructor(public http: HttpClient) {
        super(http);
    }

    Gets() {
        return this.http.get(`${ENVIRONMENT.apiUrl}/api/Users` , OPTIONS_JSON).pipe(map((e: any) => {
            return e;
        }));
    }
}
