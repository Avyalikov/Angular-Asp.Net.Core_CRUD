﻿import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from './product';

@Injectable()
export class DataService {
    private url = "/api/products"

    constructor(private http: HttpClient) {

    }

    getProducts() {
        return this.http.get(this.url);
    }

    getProduct(id: number) {
        return this.http.get(this.url + '/' + id);
    }

    createProduct(product: Product) {
        return this.http.post(this.url, product, { observe: 'response' });
    }
    updateProduct(product: Product) {
        return this.http.put(this.url, product);
    }
    deleteProduct(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}