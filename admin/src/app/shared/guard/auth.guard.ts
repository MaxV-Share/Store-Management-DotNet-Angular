import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { CookieConsentService } from '../services';

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private translate: TranslateService, private router: Router, private cookieConsentService: CookieConsentService) {}

    canActivate() {
        let token = this.cookieConsentService.getCookie('token');
        if (token || token != '') {
            return true;
        }

        this.router.navigate(['/login']);
        return false;
    }
}
