import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ChartsModule as Ng2Charts } from 'ng2-charts';
import { PageHeaderModule } from '@app/shared';

import { ChartsRoutingModule } from './charts-routing.module';
import { ChartsComponent } from './charts.component';

@NgModule({
    imports: [CommonModule, Ng2Charts, ChartsRoutingModule, PageHeaderModule],
    declarations: [ChartsComponent]
})
export class ChartsModule {}
