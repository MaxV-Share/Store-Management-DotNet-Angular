import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrdersManagerComponent } from './orders-manager.component';

const routes: Routes = [
    {
        path: '',
        component: OrdersManagerComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class OrdersManagerRoutingModule {}
