import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class DiscountsService {

    constructor(private http: HttpClient) {

    }
    getAllPaging(filter, pageIndex, pageSize) {
        // return this.http.get<Pagination<User>>(`${environment.apiUrl}/api/users/filter?pageIndex=${pageIndex}&pageSize=${pageSize}&filter=${filter}`, { headers: this._sharedHeaders })
        //     .pipe(map((response: Pagination<User>) => {
        //         return response;
        //     }), catchError(this.handleError));
    }

}
