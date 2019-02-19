import { Component } from '@angular/core';
import { GlobalsService } from './Core/globals.service';
import { Signin } from './sign-in/shared/signin.model';
import { IdentityService } from './Core/identity.Service';
import { User } from './sign-up/shared/user.model';
import { LogOutService } from './Core/logOut.Service';
import { Router } from '@angular/router';
import { SigninService } from './sign-in/shared/signin.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'App';
  searchTerm: string;
  isAdmin: boolean = false;
  constructor(
    private _router: Router,
    public globals: GlobalsService,
    private identityService: IdentityService,
    private logOutService: LogOutService) {
  }
  ngOnInit() {
    this.getUser();
  }
  getUser() {
    this.identityService.getUser().subscribe((data: Signin) => {
      this.setUserOptions(data);
    });
  }
  logout() {
    this.logOutService.logOut().subscribe((data: Signin) => {
      this.setUserOptions(data);
      this._router.navigate(['/home'])
    });
  }
  setUserOptions(data: Signin) {
    this.globals.user = data ? data : null;
  }

}
