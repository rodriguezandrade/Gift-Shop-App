import { Injectable } from '@angular/core';
import { Signin } from '../sign-in/shared/signin.model';
import {CanActivate,ActivatedRouteSnapshot,Router, RouterStateSnapshot}from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { User } from '../sign-up/shared/user.model';
@Injectable({
  providedIn: 'root'
})
export class LogOutService  {
  constructor(private http: HttpClient) { }
  readonly rootUrl = 'http://localhost:54467/api';
  logOut() {
    var body = JSON.stringify(Signin);
    return this.http.post<Signin>(this.rootUrl + '/Account/Logout',Signin);
  }
  }
 
