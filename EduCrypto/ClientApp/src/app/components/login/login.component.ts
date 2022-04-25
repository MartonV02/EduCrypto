import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AppComponent } from '../../app.component';
import { UserHandlingModel } from '../../shared/user-handling.model';
import { LoginService } from './service/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  key: string;
  hide = true;

  public captchaColor: boolean;
  public userHandlingModel: UserHandlingModel = new UserHandlingModel();

  private jwtToken: string;

  constructor(
    private fb: FormBuilder,
    private appComp: AppComponent,
    private _loginServe: LoginService) {
    this.key = '';
  }

  ngOnInit(): void {
    if (this.appComp.isDarkRecaptcha) {
      this.captchaColor = true
    }
    else {
      this.captchaColor = false
    }
  }

  loginForm: FormGroup = this.fb.group({
    email: ['', [Validators.required]],
    password: ['', [Validators.required, Validators.minLength(2)]]
  })

  onLogin()
  {
    console.log(!this.loginForm.valid);
    if (this.loginForm.valid) {
      this._loginServe.sendLogIn(this.loginForm.value)
        .subscribe((jwt: string) => {
          this.jwtToken = jwt;
          console.log(jwt);
        })
    }
  }

  resolved(captchaResponse: string) {
    this.key = captchaResponse;
  }
}
