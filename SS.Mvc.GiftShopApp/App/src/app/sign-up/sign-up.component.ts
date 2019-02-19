import { Component, OnInit } from '@angular/core';
import { User } from './shared/user.model';
import { NgForm } from '@angular/forms';
import { UserService } from './shared/user.service';
import { ToastrService } from 'ngx-toastr'
import { Router } from '@angular/router';
import { GlobalsService } from '../Core/globals.service';
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  user: User;
  emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";

  constructor(private globals: GlobalsService, private router: Router, private registerService: UserService, private toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?: NgForm) {
    if (form != null)
      form.reset();
    this.registerService.selectedregister = {
      username: '',
      email: '',
      password: '',
      confirmed: 1

    }
  }

  SignUp(name: string, email: string, pwd: string) {
    this.user = new User();
    this.user.username = name;
    this.user.email = email;
    this.user.password = pwd;
    this.user.confirmed = 1;

    console.log(this.registerService.registerUser(this.user).subscribe(data => {
        this.toastr.success('User registration successful');
        this.router.navigate(['/signin'])
      }, (err: HttpErrorResponse) => {
        this.toastr.error(err.message);

      }));
  }

}

