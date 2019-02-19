import { Injectable } from '@angular/core';
import { Category } from './category.model';
import { HttpHeaders, HttpErrorResponse, HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

export const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'my-auth-token'
  })
};

@Injectable({
  providedIn: 'root'
})

export class CategoryService {
  readonly rootUrl = 'http://localhost:54467/api/Category';

  constructor(private http: HttpClient) { }

  post(pro: Category) {
    return this.http.post<Category>(this.rootUrl + '/add  ', pro, httpOptions).pipe(
      catchError(this.handleError)
    );

  }

  put(id: number, pro: Category): Observable<Category> {
    return this.http.put<Category>(this.rootUrl + '/update/ ' + id, pro, httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  get(): Observable<Category[]> {
    return this.http.get<Category[]>(this.rootUrl + '/getAll').pipe(
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
