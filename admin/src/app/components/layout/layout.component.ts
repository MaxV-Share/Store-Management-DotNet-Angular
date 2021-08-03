import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { mapper } from '@app/models';
import { autoMapperProfile } from '@app/shared/infrastructures/auto-mapper';
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
        mapper.addProfile(autoMapperProfile)
        if(localStorage.getItem('lang') == null){
            localStorage.setItem('lang', navigator.language.substring(0, 2));
        }
        this.translate.use(localStorage.getItem('lang'));
    };

    getListPosts() {

    }
    receiveCollapsed($event) {
        this.collapedSideBar = $event;
    }
}
