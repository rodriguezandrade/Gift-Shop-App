import { Injectable } from '@angular/core';
import { Signin } from './signin.model';
import { Headers, RequestOptions, RequestMethod } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';


@Injectable({
  providedIn: 'root'
})
export class SigninService {
  readonly rootUrl = 'http://localhost:54467/api';
  selectedLogin: Signin;
  signin: Signin;
  //isAdmin:boolean= false;
  constructor(private http: HttpClient) { }

  postSigin(pro: Signin) {
    var body = JSON.stringify(pro);
    return this.http.post<Signin>(this.rootUrl + '/Account/login', pro);
  }

}
