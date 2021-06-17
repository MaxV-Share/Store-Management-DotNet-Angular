import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@app/models';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

    private _sharedHeaders = new HttpHeaders();
    constructor(private http: HttpClient) {
        this._sharedHeaders = environment._sharedHeaders;
    }
    add(formData: FormData){
        return this.http.post(`${environment.apiUrl}/api/products`, formData, {
            reportProgress: true,
            observe: 'events'
        })
        .pipe();
    }
    getPaging(pageIndex:number, pageSize: number, langId:string, searchText: string) {
        return this.http.get(`${environment.apiUrl}/api/products/filter?pageIndex=${pageIndex}&pageSize=${pageSize}&searchText=${searchText}&langId=${langId}`, { headers: this._sharedHeaders })
            // .pipe(catchError(this.handleError));
    }

    getAll(langId: string) {
        return this.http.get(`${environment.apiUrl}/api/products?langId=${langId}`, { headers: this._sharedHeaders })
            // .pipe(catchError(this.handleError));
    }
}
