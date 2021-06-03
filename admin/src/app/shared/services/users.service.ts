import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment, User } from '@app/models';
import { catchError, map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class UsersService {

    constructor(private http: HttpClient) { }

    Gets() {
        return this.http.get(`${environment.apiUrl}/api/Users` , { headers: environment._sharedHeaders }).pipe(map((e: any) => {
            return e;
        }));
    }
}
