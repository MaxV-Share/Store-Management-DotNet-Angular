import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { TranslateModule } from '@ngx-translate/core';
import { HeaderComponent } from './header/header.component';
import { SidebarComponent } from './sidebar/sidebar.component';

import { LayoutRoutingModule } from './layout-routing.module';
import { LayoutComponent } from './layout.component';
import LocalizedNumericInputDirective from '../shared/directives/localized-numeric-input.directive';
import { MyCurrencyPipe } from '../shared/directives/my-currency-pipe.pipe';
import { ReactiveFormsModule } from '@angular/forms';
import { FileUploadModule } from 'primeng-lts';

@NgModule({
    imports: [CommonModule, LayoutRoutingModule, TranslateModule, NgbDropdownModule,ReactiveFormsModule,FileUploadModule ],
    declarations: [LayoutComponent, SidebarComponent, HeaderComponent, LocalizedNumericInputDirective, MyCurrencyPipe],
    exports: [LocalizedNumericInputDirective, MyCurrencyPipe,ReactiveFormsModule,FileUploadModule],
    providers: [MyCurrencyPipe]
})
export class LayoutModule { }
