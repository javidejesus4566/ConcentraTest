import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LayoutProductComponent } from './layout-product.component';
import { ListProductComponent } from './list-product.component';
import { AddEditProductComponent } from './addproduct-edit.component';

const routes: Routes = [
    {
        path: '', component: LayoutProductComponent,
        children: [
            { path: '', component: ListProductComponent },
            { path: 'add', component: AddEditProductComponent },
            { path: 'edit/:id', component: AddEditProductComponent }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ProductsRoutingModule { }