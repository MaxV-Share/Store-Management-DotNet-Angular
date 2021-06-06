import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category, CategoryCr, environment } from '@app/models';

@Injectable({
    providedIn: 'root'
})
export class CategoryService {

    private _sharedHeaders = new HttpHeaders();
    constructor(private http: HttpClient) {
        this._sharedHeaders = environment._sharedHeaders;
    }
    add(entity: CategoryCr) {
        return this.http.post(`${environment.apiUrl}/api/Categories`, JSON.stringify(entity), { headers: this._sharedHeaders })
            .pipe();
    }

    update(id: string, entity: Category) {
        return this.http.put(`${environment.apiUrl}/api/roles/${id}`, JSON.stringify(entity), { headers: this._sharedHeaders })
            // .pipe(catchError(this.handleError));
    }

}
