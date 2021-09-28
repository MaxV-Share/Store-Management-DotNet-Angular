import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';
import {ChartModule} from 'primeng/chart';

const routes: Routes = [
    {
        path: '',
        component: DashboardComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes),ChartModule],
    exports: [RouterModule,ChartModule]
})
export class DashboardRoutingModule {}
