import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ENVIRONMENT, OPTIONS_JSON } from '@app/models';
import { BaseService } from './base/base.service';

@Injectable({
    providedIn: 'root'
})
export class RevenueService extends BaseService {

    constructor(http: HttpClient) {
        super(http);
    }
    getRevenueDailyOfMonth(year: number,month: number){
        let url = `${ENVIRONMENT.apiUrl}/api/revenues/daily-of-month?year=${year}&month=${month}`;

        return this.http.get(url, OPTIONS_JSON);
    }
}
