import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';

import { GlobalsService } from './globals.service';

@Injectable({
  providedIn: 'root',
})
export class AutguardService implements CanActivate {
  constructor(private globalService: GlobalsService, private router: Router) { }
  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const url: string = state.url;

    if (this.globalService.user) {

      if (this.globalService.user.role === 'Client') {

      } else if (next.routeConfig && (next.routeConfig.path === 'all')) {
        this.router.navigate(['/home']);
        return false;
      }
    } else {
      if (next.routeConfig && (next.routeConfig.path === 'sale')) {
        this.router.navigate(['/home']);
        return false;
      }
    }
    return true;
  }
}
