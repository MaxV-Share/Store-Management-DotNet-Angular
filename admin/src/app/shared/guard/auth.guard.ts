import { ResourceLoader } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { AuthenticationService, CookieConsentService } from '@app/shared/services';

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private translate: TranslateService, private router: Router, private cookieConsentService: CookieConsentService, private authenticationService: AuthenticationService) { }

    async canActivate() {
        let token = this.cookieConsentService.getCookie('token');
        let result = false;
        if (token || token != '') {
            await this.authenticationService.ValidateToken().toPromise().then(e => {
                result = true;
            }).catch(() => {
                result = false;
                this.cookieConsentService.deleteCookie('token');
            });
        }
        if (!result)
            this.router.navigate(['/login']);
        return result;


    }
}
