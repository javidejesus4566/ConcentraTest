import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../environments/environment';
import { Product } from '../_models';

@Injectable({ providedIn: 'root' })
export class ProductService {
    private productSubject: BehaviorSubject<Product>;
    public product: Observable<Product>;

    constructor(
        private router: Router,
        private http: HttpClient
    ) {
        this.productSubject = new BehaviorSubject<Product>(JSON.parse(localStorage.getItem('product') || '{}'));
        this.product = this.productSubject.asObservable();
    }

    public get productValue(): Product {
        return this.productSubject.value;
    }

    register(product: Product) {
        return this.http.post(`${environment.apiUrl}/products/register`, product);
    }

    getAll() {
        return this.http.get<Product[]>(`${environment.apiUrl}/products`);
    }

    getById(id: string) {
        return this.http.get<Product>(`${environment.apiUrl}/products/${id}`);
    }

    update(id, params) {
        return this.http.put(`${environment.apiUrl}/products/${id}`, params)
            .pipe(map(x => {
                // update stored product if the logged in products updated their own record
                if (id == this.productValue.id) {
                    // update local storage
                    const product = { ...this.productValue, ...params };
                    localStorage.setItem('product', JSON.stringify(product));

                    // publish updated product to subscribers
                    this.productSubject.next(product);
                }
                return x;
            }));
    }

    delete(id: string) {
        return this.http.delete(`${environment.apiUrl}/products/${id}`)
            .pipe(map(x => {
                return x;
            }));
    }
}