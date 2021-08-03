import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '@app/components/base';
import { Revenue } from '@app/models';
import { RevenueService, UsersService } from '@app/shared/services';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { delay } from 'rxjs/operators';
import { routerTransition } from '../../../router.animations';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss'],
    animations: [routerTransition()]
})
export class DashboardComponent extends BaseComponent implements OnInit {
    public alerts: Array<any> = [];
    public sliders: Array<any> = [];

    dataDaily: any;
    dataMonthly: any;
    chartOptions: any;
    loadingRevenueDaily: boolean = false;
    loadingRevenueMonth: boolean = false;
    subscription: Subscription;

    constructor(private usersServices: UsersService,
        private revenueService: RevenueService,
        protected translate: TranslateService,
        protected toastr: ToastrService) {
        super(translate,toastr);
        // usersServices.Gets().toPromise()
        //     .then(e => console.log(e)
        //     ).catch(ex => console.log(ex)
        //     )
        this.getRevenueDailyOfMonth();
        this.getRevenueMonthlyOfYear();
        this.chartOptions = {
            responsive: true,
            title: {
                display: false,
                text: 'Combo Bar Chart'
            },
            tooltips: {
                mode: 'index',
                intersect: true
            }
        };
    }

    ngOnInit() { }

    async testLoading(){
        this.loadingRevenueDaily = true;
        await new Promise( resolve => setTimeout(resolve, 1000) );
        this.loadingRevenueDaily = false;
    }

    getRevenueDailyOfMonth() {
        this.loadingRevenueDaily = true;
        this.revenueService.getRevenueDailyOfMonth(2021, 7).subscribe((res: HttpResponse<Revenue[]>) => {
            if(res.status == 200){
                console.log(res);
                let labels = [" "].concat(res.body.map(e => e.id));
                let datas = [0].concat(res.body.map(e => e.totalPrice));
                console.log
                this.translate.get('Revenue').subscribe((text) => {
                    this.dataDaily = {
                        labels: labels,
                        datasets: [
                            {
                                type: 'bar',
                                label: text,
                                backgroundColor: '#66BB66',
                                data: datas,
                                borderColor: '#007bff',
                                borderWidth: 2
                            },
                        ]
                    };
                });
            }

            this.loadingRevenueDaily = false;
        })
    }

    getRevenueMonthlyOfYear() {
        this.loadingRevenueMonth = true;
        this.revenueService.getRevenueMonthlyOfYear(2021).subscribe((res: HttpResponse<Revenue[]>) => {
            if(res.status == 200){
                let labels = [" "].concat(res.body.map(e => e.id));
                let datas = [0].concat(res.body.map(e => e.totalPrice));
                this.translate.get('Revenue').subscribe((text) => {
                    this.dataMonthly = {
                        labels: labels,
                        datasets: [
                            {
                                type: 'bar',
                                label: text,
                                backgroundColor: '#66BB66',
                                data: datas,
                                borderColor: '#007bff',
                                borderWidth: 2
                            },
                        ]
                    };
                });
            }

            this.loadingRevenueMonth = false;
        })
    }


    public closeAlert(alert: any) {
        const index: number = this.alerts.indexOf(alert);
        this.alerts.splice(index, 1);
    }
}
