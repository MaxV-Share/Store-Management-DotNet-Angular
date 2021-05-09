import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { routerTransition } from '../router.animations';
import { TranslateService } from '@ngx-translate/core';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss'],
    animations: [routerTransition()]
})
export class LoginComponent implements OnInit {
    constructor(private translate: TranslateService,public router: Router) {}

    ngOnInit() {
        this.translate.use(localStorage.getItem('lang') || navigator.language.substring(0,2));
        
    }

    onLoggedin() {
        localStorage.setItem('isLoggedin', 'true');
    }
}
