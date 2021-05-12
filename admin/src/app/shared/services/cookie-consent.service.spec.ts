/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CookieConsentService } from './cookie-consent.service';

describe('Service: CookieConsent', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CookieConsentService]
    });
  });

  it('should ...', inject([CookieConsentService], (service: CookieConsentService) => {
    expect(service).toBeTruthy();
  }));
});
