import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { SigninService } from './shared/signin.service'
import { Signin } from './shared/signin.model';
import { HttpErrorResponse } from '@angular/common/http';
import { GlobalsService } from '../Core/globals.service';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  signin: Signin;
  constructor(private signinService: SigninService, private toastr: ToastrService, private globals:GlobalsService, private router:Router) { }
  ngOnInit() {
  }
  
  SignIn(usr: string, pwd: string) {
    this.signin = new Signin( );
    this.signin.userName = usr;
    this.signin.password = pwd;
    this.signin.remember = 1;
    this.signinService.postSigin(this.signin).subscribe((data: Signin) => {
      this.toastr.success("Login Success!!", "Welcome! " + data.userName);
      this.globals.user = data;
      this.router.navigate(['/home']);
    }, (err: HttpErrorResponse) => this.toastr.error(err.message));
  }

} 