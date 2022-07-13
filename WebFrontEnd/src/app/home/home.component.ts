import { Component } from '@angular/core';

import { Product, User } from '@app/_models';
import { AccountService } from '@app/_services';


@Component({ templateUrl: 'home.component.html' })
export class HomeComponent {
    user: User;
    product: Product;

    constructor(private accountService: AccountService) {
        this.user = this.accountService.userValue;
    }


}