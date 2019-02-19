import { Injectable } from '@angular/core';
import { Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { ProductDetailComponent } from '../../comp-products/product-detail/product-detail.component'
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';


import { cartItem } from './cartItem.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CartitemService {
  readonly rootUrl = 'http://localhost:54467';

  selectedCartItem: cartItem;
  cartList: cartItem[];
  addCart: cartItem;
  constructor(private http: HttpClient) { }

  postCartItem(cart: cartItem) {
    return this.http.post(this.rootUrl + '/api/CartItems', cart);
  }

  putCartItem(id, pro) {
    return this.http.put(this.rootUrl + '/api/CartItems/ ' + id, pro);
  }

  getCartItem(): Observable<cartItem[]> {
    return this.http.get<cartItem[]>(this.rootUrl + '/api/cartItems/GetCartItem');
  }

  checkout() {
    return this.http.post(this.rootUrl + '/api/sales/chekout', {});

  }



}
