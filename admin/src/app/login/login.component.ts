import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { routerTransition } from '../router.animations';
import { TranslateService } from '@ngx-translate/core';
import { LoginModel } from '../models';
import { AuthenticationService, CookieConsentService } from '../shared/services';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss'],
    animations: [routerTransition()]
})
export class LoginComponent implements OnInit {
    constructor(private translate: TranslateService, public router: Router, private auth: AuthenticationService, private cookieConsent: CookieConsentService) { }
    loginModel: LoginModel;

    ngOnInit() {
        this.translate.use(localStorage.getItem('lang') || navigator.language.substring(0, 2));
        this.loginModel = new LoginModel();
    }

    async onLogin() {
        console.log(this.loginModel);
        let token = "";
        await this.auth.Login(this.loginModel).toPromise().then((response) => {
            this.cookieConsent.setCookie("token", response,1);
            token = response;
        }, ex => { 
            console.error(ex);
         });
        if (token || token != '')
        this.router.navigate(['/']);
        //localStorage.setItem('isLoggedin', token);
    }
}
