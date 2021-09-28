import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { NgbAlertModule, NgbCarouselModule } from '@ng-bootstrap/ng-bootstrap';
import { StatModule } from '@app/shared';
import { ChatComponent, NotificationComponent, TimelineComponent } from './components';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { AccordionModule } from 'primeng-lts';
import { LoadingComponent } from '@app/components/loading/loading.component';

@NgModule({
    imports: [CommonModule, NgbCarouselModule, NgbAlertModule, DashboardRoutingModule, StatModule,AccordionModule],
    declarations: [DashboardComponent, TimelineComponent, NotificationComponent, ChatComponent,LoadingComponent]
})
export class DashboardModule {}
