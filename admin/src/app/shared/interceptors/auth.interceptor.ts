import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthenticationService, CookieConsentService } from '../services';
@Injectable({
  providedIn: 'root'
})
export class AuthInterceptor implements HttpInterceptor {

  constructor(private authService: AuthenticationService, private cookieConsentService: CookieConsentService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // request = request.clone({
    //   setHeaders: {
    //     Authorization: `Bearer ${this.cookieConsentService.getCookie("token")}`
    //   }
    // });
    return next.handle(request);
  }
}
