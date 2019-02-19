import { Injectable } from '@angular/core';
import { Signin } from '../sign-in/shared/signin.model';
import { CanActivate, ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class GlobalsService {
  user: Signin;

  isAdmin() {
    return this.user ? this.user.role == "admin" : false;
  }

}

