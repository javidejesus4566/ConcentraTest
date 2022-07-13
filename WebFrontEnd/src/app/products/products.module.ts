import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { ProductsRoutingModule } from './products-routing.module';
import { LayoutProductComponent } from './layout-product.component';
import { ListProductComponent } from './list-product.component';
import { AddEditProductComponent } from './addproduct-edit.component';

@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        ProductsRoutingModule
    ],
    declarations: [
        LayoutProductComponent,
        ListProductComponent,
        AddEditProductComponent
    ]
})
export class ProductsModule { }