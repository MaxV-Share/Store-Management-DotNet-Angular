import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category,   CategoryCreateRequest , environment } from '@app/models';

@Injectable({
    providedIn: 'root'
})
export class CategoryService {

    private _sharedHeaders = new HttpHeaders();
    constructor(private http: HttpClient) {
        this._sharedHeaders = environment._sharedHeaders;
    }
    add(entity: CategoryCreateRequest) {
        return this.http.post(`${environment.apiUrl}/api/categories`, JSON.stringify(entity), { headers: this._sharedHeaders })
            .pipe();
    }

    update(id: number, entity: Category) {
        return this.http.put(`${environment.apiUrl}/api/roles/${id}`, JSON.stringify(entity), { headers: this._sharedHeaders })
            // .pipe(catchError(this.handleError));
    }

    getPaging(pageIndex:number, pageSize: number, langId:string, searchText: string) {
        return this.http.get(`${environment.apiUrl}/api/categories/filter?pageIndex=${pageIndex}&pageSize=${pageSize}&searchText=${searchText}&langId=${langId}`, { headers: this._sharedHeaders })
            // .pipe(catchError(this.handleError));
    }
    
    getAll(langId: string) {
        return this.http.get(`${environment.apiUrl}/api/categories?langId=${langId}`, { headers: this._sharedHeaders })
            // .pipe(catchError(this.handleError));
    }
    getById(id:number,langId: string) {
        return this.http.get(`${environment.apiUrl}/api/categories/${id}?langId=${langId}`, { headers: this._sharedHeaders })
            // .pipe(catchError(this.handleError));
    }

}
