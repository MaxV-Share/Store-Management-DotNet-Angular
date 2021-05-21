import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DiscountComponent } from './discount.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DiscountRoutingModule } from './discount-routing.module';
import {MatButtonModule} from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';

@NgModule({
  imports: [
    CommonModule, DiscountRoutingModule,NgbModule,MatButtonModule,MatTableModule
  ],
  declarations: [DiscountComponent]
})
export class DiscountModule { }
