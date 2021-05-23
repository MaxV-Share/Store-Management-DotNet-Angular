import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoryComponent } from './category.component';
import { StatModule } from '../../shared';
import { NgbAlertModule, NgbCarouselModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CategoryRoutingModule } from './category-routing.module';

@NgModule({
  imports: [
    CommonModule, NgbCarouselModule, NgbAlertModule, StatModule,CategoryRoutingModule,NgbModule
  ],
  declarations: [CategoryComponent]
})
export class CategoryModule { }
