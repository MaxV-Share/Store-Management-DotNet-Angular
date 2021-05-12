import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
@Component({
    selector: 'app-layout',
    templateUrl: './layout.component.html',
    styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {
    collapedSideBar: boolean;

    constructor(private translate: TranslateService, private http: HttpClient) { }

    ngOnInit() {
        this.translate.use(localStorage.getItem('lang') || navigator.language.substring(0, 2));
        console.log(navigator);
        // this.http.get('http://api.ipify.org/',{responseType: 'text'}).toPromise().then(res => {
        //     console.log(res);
        // }).catch(e => {
        //     console.error(e);
        // })
    };

    getListPosts() {
        
    }
    receiveCollapsed($event) {
        this.collapedSideBar = $event;
    }
}
