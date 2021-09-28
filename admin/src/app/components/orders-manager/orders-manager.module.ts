import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TranslateModule } from '@ngx-translate/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OrdersManagerComponent } from './orders-manager.component';
import { OrdersManagerRoutingModule } from './orders-manager-routing.module';
import { LayoutModule } from '@app/components/layout/layout.module';
import { OrderManagerDetailsComponent } from './order-manager-details/order-manager-details.component';


@NgModule({
    imports: [
        OrdersManagerRoutingModule,
        CommonModule,
        NgbModule,
        ModalModule.forRoot(),
        TranslateModule,
        FormsModule,
        ReactiveFormsModule,
        LayoutModule,
    ],
    declarations: [OrdersManagerComponent,OrderManagerDetailsComponent],
    exports: [ReactiveFormsModule, TranslateModule]
})
export class OrdersManagerModule { }
