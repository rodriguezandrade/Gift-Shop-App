import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { User } from './user.model';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  readonly rootUrl = 'http://localhost:54467';
  selectedregister: User;
  productList: User[];
  Ctrl_User: User;
  constructor(private http: Http) { }

  registerUser(user: User) {

    var body = JSON.stringify(user);
    return this.http.post(this.rootUrl + '/api/Account/user', user);

  }

}
