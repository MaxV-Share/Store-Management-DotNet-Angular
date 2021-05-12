import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment, LoginModel } from '../models';
import { catchError, map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {

    private _sharedHeaders = new HttpHeaders({'Content-Type': 'application/json'});
    constructor(private http: HttpClient) {

    }
    Login(entity: LoginModel) {
        return this.http.post(`${environment.apiUrl}/api/Authentication/Login`, JSON.stringify(entity), { headers: this._sharedHeaders }).pipe(map((e: any) :string =>{
            return e.token;
        }));
    }

}
