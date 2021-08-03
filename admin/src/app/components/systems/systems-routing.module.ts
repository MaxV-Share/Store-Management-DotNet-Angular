import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FunctionsComponent } from './functions/functions.component';
import { PermissionsComponent } from './permissions/permissions.component';
import { RolesComponent } from './roles/roles.component';
import { UsersComponent } from './users/users.component';

const routes: Routes = [
    {
        path: 'functions',
        component: FunctionsComponent
    },
    {
        path: 'permissions',
        component: PermissionsComponent
    },
    {
        path: 'roles',
        component: RolesComponent
    },
    {
        path: 'users',
        component: UsersComponent
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class SystemsRoutingModule {}
