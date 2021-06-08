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
}
