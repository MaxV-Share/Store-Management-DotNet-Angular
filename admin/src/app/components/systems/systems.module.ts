import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { TranslateModule } from "@ngx-translate/core";
import { ModalModule } from "ngx-bootstrap/modal";
import { SystemsRoutingModule } from "./systems-routing.module";
import { LayoutModule } from '@app/components/layout/layout.module';
import { FunctionsComponent } from "./functions/functions.component";
import { UsersComponent } from "./users/users.component";
import { PermissionsComponent } from "./permissions/permissions.component";
import { RolesComponent } from "./roles/roles.component";
import { FunctionsDetailComponent } from "./functions/functions-detail/functions-detail.component";
import { TreeTableModule } from "primeng-lts";
import { RoleDetailComponent } from "./roles/role-detail/role-detail.component";

@NgModule({
    imports: [
        SystemsRoutingModule,
        CommonModule,
        NgbModule,
        ModalModule.forRoot(),
        TranslateModule,
        FormsModule,
        LayoutModule,
        ReactiveFormsModule,
        TreeTableModule,
    ],
    declarations: [FunctionsComponent,UsersComponent,PermissionsComponent,RolesComponent, FunctionsDetailComponent, RoleDetailComponent],
    exports: [ReactiveFormsModule,TranslateModule]
})
export class SystemsModule { }
