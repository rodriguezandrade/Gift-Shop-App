import { Injectable } from '@angular/core';
import { Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { throwError } from 'rxjs';
import { HttpHeaders, HttpClient, HttpErrorResponse } from '@angular/common/http';

import { Products, ProductsDto } from './products.model';
import { catchError } from 'rxjs/operators';

export const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'my-auth-token'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  readonly rootUrl = 'http://localhost:54467/api/Products';

  selectedProduct: Products;
  productList: Products[];
  productFilter: Products[];
  manProduct: Products;
  constructor(private http: HttpClient) { }

  post(pro: Products) {
    return this.http.post<Products>(this.rootUrl + '/add  ', pro, httpOptions).pipe(
      catchError(this.handleError)
    );

  }

  put(id: number, pro: Products): Observable<Products> {
    return this.http.put<Products>(this.rootUrl + '/update/ ' + id, pro, httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  get(): Observable<ProductsDto[]> {
    return this.http.get<ProductsDto[]>(this.rootUrl + '/getAll').pipe(
      catchError(this.handleError)
    );
  }

  delete(id: number) {
    return this.http.delete<void>(this.rootUrl + '/delete/' + id).pipe(
      catchError(this.handleError)
    );
  }


  private handleError(err: HttpErrorResponse) {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
