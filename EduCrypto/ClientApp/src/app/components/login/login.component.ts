import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AppComponent } from 'src/app/app.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  key : string;
  hide: boolean = false;
  public captchaColor: boolean;


  constructor(
    private fb: FormBuilder,
    private appComp: AppComponent) {
    this.key = '';
   }

  ngOnInit(): void {
    if(this.appComp.isDarkRecaptcha)
    {
      this.captchaColor= true
    }
    else {
      this.captchaColor = false
    }
  }
  loginForm: FormGroup = this.fb.group({
    username: ['', [Validators.required]],
    password: ['', [Validators.required, Validators.minLength(6)]]
  })

    onLogin() {
      if (!this.loginForm.valid) {
        return;
      }
      
      console.log(this.loginForm.value);
    }
    
    resolved(captchaResponse: string) {
      this.key = captchaResponse;
    }

    // componentDidMount() {
    //   const darkmode = document.querySelector('html').classList.contains('dark');
    //   if (darkmode) {
    //     this.setState({ theme: 'dark' });
    //   } else {
    //     this.setState({ theme: 'light' });
    //   }
    // }

}
