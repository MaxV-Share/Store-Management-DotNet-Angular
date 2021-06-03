import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment, LoginModel } from '@app/models';
import { catchError, map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {

    constructor(private http: HttpClient) {

    }
    Login(entity: LoginModel) {
        return this.http.post(`${environment.apiUrl}/api/Authentication/Login`, JSON.stringify(entity), { headers: environment._sharedHeaders }).pipe(map((e: any) :string =>{
            return e.token;
        }));
    }
    ValidateToken() {
        return this.http.get(`${environment.apiUrl}/api/Authentication/validate-token`, { headers: environment._sharedHeaders }).pipe(map((e)  =>{
            return e;
        }));
    }

}
