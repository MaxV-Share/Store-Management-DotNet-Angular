import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ENVIRONMENT, OPTIONS_JSON } from '@app/models';
import { BaseService } from './base/base.service';

@Injectable({
    providedIn: 'root'
})
export class RevenueService extends BaseService {

    constructor(http: HttpClient) {
        super(http, 'revenues');
    }
    getRevenueDailyOfMonth(year: number,month: number){
        let url = `${this.apiUrl}/daily-of-month?year=${year}&month=${month}`;

        return this.http.get(url, OPTIONS_JSON);
    }
    getRevenueMonthlyOfYear(year: number){
        let url = `${this.apiUrl}/monthly-of-year?year=${year}`;

        return this.http.get(url, OPTIONS_JSON);
    }
}
