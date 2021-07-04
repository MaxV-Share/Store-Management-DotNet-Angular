import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ENVIRONMENT, LoginModel } from '@app/models';
import { catchError, map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {

    constructor(private http: HttpClient) {

    }
    Login(entity: LoginModel) {
        return this.http.post(`${ENVIRONMENT.apiUrl}/api/Authentication/Login`, JSON.stringify(entity), { headers: ENVIRONMENT._sharedHeaders }).pipe(map((e: any) :string =>{
            return e.token;
        }));
    }
    ValidateToken() {
        return this.http.get(`${ENVIRONMENT.apiUrl}/api/Authentication/validate-token`, { headers: ENVIRONMENT._sharedHeaders, responseType: 'text' }).pipe(map((e)  =>{
            return e;
        }));
    }

}
