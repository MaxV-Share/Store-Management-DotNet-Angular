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

    data: any;

    chartOptions: any;
    loadingRevenueDaily: boolean = false;
    subscription: Subscription;

    constructor(private usersServices: UsersService, private revenueService: RevenueService, protected translate: TranslateService,
        protected toastr: ToastrService) {
        super(translate,toastr);
        this.sliders.push(
            {
                imagePath: 'assets/images/slider1.jpg',
                label: 'First slide label',
                text: 'Nulla vitae elit libero, a pharetra augue mollis interdum.'
            },
            {
                imagePath: 'assets/images/slider2.jpg',
                label: 'Second slide label',
                text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.'
            },
            {
                imagePath: 'assets/images/slider3.jpg',
                label: 'Third slide label',
                text: 'Praesent commodo cursus magna, vel scelerisque nisl consectetur.'
            }
        );

        this.alerts.push(
            {
                id: 1,
                type: 'success',
                message: `Lorem ipsum dolor sit amet, consectetur adipisicing elit.
                Voluptates est animi quibusdam praesentium quam, et perspiciatis,
                consectetur velit culpa molestias dignissimos
                voluptatum veritatis quod aliquam! Rerum placeat necessitatibus, vitae dolorum`
            },
            {
                id: 2,
                type: 'warning',
                message: `Lorem ipsum dolor sit amet, consectetur adipisicing elit.
                Voluptates est animi quibusdam praesentium quam, et perspiciatis,
                consectetur velit culpa molestias dignissimos
                voluptatum veritatis quod aliquam! Rerum placeat necessitatibus, vitae dolorum`
            }
        );
        // usersServices.Gets().toPromise()
        //     .then(e => console.log(e)
        //     ).catch(ex => console.log(ex)
        //     )
        this.getRevenueDailyOfMonth();

        this.chartOptions = {
            responsive: true,
            title: {
                display: false,
                text: 'Combo Bar Line Chart'
            },
            tooltips: {
                mode: 'index',
                intersect: true
            }
        };
    }

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
                let labels = res.body.map(e => e.id);
                let data = res.body.map(e => e.totalPrice);
                this.translate.get('Revenue').subscribe((text) => {
                    this.data = {
                        labels: labels,
                        datasets: [
                            {
                                type: 'bar',
                                label: text,
                                backgroundColor: '#66BB66',
                                data: data,
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

    applyLightTheme() {
        this.chartOptions = {
            legend: {
                labels: {
                    fontColor: '#495057'
                }
            },
            scales: {
                xAxes: [{
                    ticks: {
                        fontColor: '#495057'
                    }
                }],
                yAxes: [{
                    ticks: {
                        fontColor: '#495057'
                    }
                }]
            }
        }
    }

    applyDarkTheme() {
        this.chartOptions = {
            legend: {
                labels: {
                    fontColor: '#ebedef'
                }
            },
            scales: {
                xAxes: [{
                    ticks: {
                        fontColor: '#ebedef'
                    },
                    gridLines: {
                        color: 'rgba(255,255,255,0.2)'
                    }
                }],
                yAxes: [{
                    ticks: {
                        fontColor: '#ebedef'
                    },
                    gridLines: {
                        color: 'rgba(255,255,255,0.2)'
                    }
                }]
            }
        };
    }

    ngOnInit() { }

    public closeAlert(alert: any) {
        const index: number = this.alerts.indexOf(alert);
        this.alerts.splice(index, 1);

    }
}
