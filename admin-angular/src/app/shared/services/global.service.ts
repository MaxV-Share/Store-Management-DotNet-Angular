import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GlobalService {

    public get currentUserName(): string{
        return sessionStorage.getItem('currentUserName');
    }
    public set currentUserName(value: string){
        sessionStorage.setItem('currentUserName', value);
    }

}
