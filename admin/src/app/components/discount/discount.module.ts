import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DiscountComponent } from './discount.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DiscountRoutingModule } from './discount-routing.module';
import { DiscountDetailComponent } from './discount-detail/discount-detail.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TranslateModule } from '@ngx-translate/core';
import { FormsModule } from '@angular/forms';
import { LayoutModule } from '@app/components/layout/layout.module';

@NgModule({
    imports: [
        CommonModule,
        DiscountRoutingModule,
        NgbModule,
        ModalModule.forRoot(),
        TranslateModule,
        FormsModule,
        LayoutModule,
    ],
    declarations: [DiscountComponent,DiscountDetailComponent],
    exports: [TranslateModule],
})
export class DiscountModule { }
