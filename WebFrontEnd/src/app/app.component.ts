import { Component } from '@angular/core';

import { AccountService } from './_services';
//import { ProductService } from '../app/_services'
import { User } from './_models';
import { Product } from './_models';

@Component({ selector: 'app', templateUrl: 'app.component.html' })
export class AppComponent {
    user: User;
    product: Product;

    constructor(private accountService: AccountService) {
        this.accountService.user.subscribe(x => this.user = x);
     //   this.productService.product.subscribe(x => this.product = x);
    }

    logout() {
        this.accountService.logout();
    }
}