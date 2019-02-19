import { Injectable } from '@angular/core';
import { Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { ProductDetailComponent } from '../../comp-products/product-detail/product-detail.component'
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';


import { sale } from './sale.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SaleService {
  readonly rootUrl = 'http://localhost:54467';

  selectedSale: sale;
  saleList: sale[];
  addSale: sale;
  constructor(private http: HttpClient) { }

  postSale(sale: sale) {
    return this.http.post(this.rootUrl + '/api/sales', sale);
  }

  putSale(id, pro) {
    return this.http.put(this.rootUrl + '/api/CartItems/ ' + id, pro);
  }

  getSale(): Observable<sale[]> {
    return this.http.get<sale[]>(this.rootUrl + '/api/sales/Getsales');
  }

  deleteSale(id: number) {
    return this.http.delete(this.rootUrl + '/api/Sales/' + id);

  }



}
