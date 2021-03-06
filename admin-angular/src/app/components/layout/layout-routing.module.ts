import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './layout.component';

const routes: Routes = [
    {
        path: '',
        component: LayoutComponent,
        children: [
            { path: '', redirectTo: 'dashboard', pathMatch: 'prefix' },
            {
                path: 'dashboard',
                loadChildren: () => import('./dashboard/dashboard.module').then((m) => m.DashboardModule)
            },
            {
                path: 'charts',
                loadChildren: () => import('./charts/charts.module').then((m) => m.ChartsModule)
            },
            {
                path: 'tables',
                loadChildren: () => import('./tables/tables.module').then((m) => m.TablesModule)
            },
            {
                path: 'forms',
                loadChildren: () => import('./form/form.module').then((m) => m.FormModule)
            },
            {
                path: 'bs-element',
                loadChildren: () => import('./bs-element/bs-element.module').then((m) => m.BsElementModule)
            },
            { path: 'grid', loadChildren: () => import('./grid/grid.module').then((m) => m.GridModule) },
            {
                path: 'components',
                loadChildren: () => import('./bs-component/bs-component.module').then((m) => m.BsComponentModule)
            },
            {
                path: 'blank-page',
                loadChildren: () => import('./blank-page/blank-page.module').then((m) => m.BlankPageModule)
            },
            {
                path: 'discounts',
                loadChildren: () => import('@app/components/discount/discount.module').then(m => m.DiscountModule)
            },
            {
                path: 'products',
                loadChildren: () => import('@app/components/product/product.module').then(m => m.ProductModule)
            },
            {
                path: 'categories',
                loadChildren: () => import('@app/components/category/category.module').then(m => m.CategoryModule)
            },
            {
                path: 'orders-manager',
                loadChildren: () => import('@app/components/orders-manager/orders-manager.module').then(m => m.OrdersManagerModule)
            },
            {
                path: 'systems',
                loadChildren: () => import('@app/components/systems/systems.module').then(m => m.SystemsModule)
            },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class LayoutRoutingModule { }
