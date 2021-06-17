import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TranslateModule } from '@ngx-translate/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OrdersComponent } from './orders.component';
import { OrdersRoutingModule } from './orders-routing.module';
import { LayoutModule } from '@app/layout/layout.module';


@NgModule({
    imports: [
        OrdersRoutingModule,
        CommonModule,
        NgbModule,
        ModalModule.forRoot(),
        TranslateModule,
        FormsModule,
        ReactiveFormsModule,
        LayoutModule,
    ],
    declarations: [OrdersComponent],
    exports: [ReactiveFormsModule, TranslateModule]
})
export class OrdersModule { }
