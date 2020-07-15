import { Component, OnInit } from '@angular/core';
import { ILogin } from './login';
import { IUser } from './user';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { LoginService } from './login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  login: ILogin;
  loginForm: FormGroup;
  errorMessage: string;

  constructor(private formBuilder: FormBuilder,
              private loginService: LoginService,
              private router: Router) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.maxLength(20)]],
      lastName: ['', [Validators.required, Validators.maxLength(30)]]
    });
  }

  save(): void {
    if(this.loginForm.valid){
      const body = { ...this.login, ...this.loginForm.value };
      this.loginService.loginUser(body)
        .subscribe({
          next: (user: IUser) => this.saveUserInMemory(user),
          error: err => this.errorMessage = err
        });
    }
  }

  saveUserInMemory(user:IUser): void{
    sessionStorage.setItem('UserInfo', JSON.stringify(user));
    this.router.navigate(['/product']);
  }
}
