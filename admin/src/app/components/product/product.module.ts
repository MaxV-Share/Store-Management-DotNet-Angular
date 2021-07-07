import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TranslateModule } from '@ngx-translate/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LayoutModule } from '@app/layout/layout.module';
import { ProductComponent } from './product.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductRoutingModule } from './product-routing.module';

@NgModule({
    imports: [
        ProductRoutingModule,
        CommonModule,
        NgbModule,
        ModalModule.forRoot(),
        TranslateModule,
        FormsModule,
        LayoutModule,
        ReactiveFormsModule,
    ],
    declarations: [ProductComponent, ProductDetailComponent],
    exports: [ReactiveFormsModule,TranslateModule]
})
export class ProductModule { }
