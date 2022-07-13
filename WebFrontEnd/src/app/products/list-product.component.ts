import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { ProductService } from '@app/_services/product.service';

@Component({ templateUrl: 'list-product.component.html' })
export class ListProductComponent implements OnInit {
    products = null;

    constructor(private productService: ProductService) {}

    ngOnInit() {
        this.productService.getAll()
            .pipe(first())
            .subscribe(products => this.products = products);
    }

    deleteProduct(id: string) {
        const product = this.products.find(x => x.id === id);
        product.isDeleting = true;
        this.productService.delete(id)
            .pipe(first())
            .subscribe(() => this.products = this.products.filter(x => x.id !== id));
    }
}