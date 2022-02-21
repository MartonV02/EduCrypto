import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AppComponent } from 'src/app/app.component';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
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
  registerForm: FormGroup = this.fb.group({
    username: ['', [Validators.required, Validators.minLength(3)]],
    password: ['', [Validators.required, Validators.minLength(6)]],
    email: ['', [Validators.required, Validators.email]],
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]],
  })

    onCreateAccount() {
      if (!this.registerForm.valid) {
        return;
      }

      console.log(this.registerForm.value);
    }
  
    resolved(captchaResponse: string) {
      this.key = captchaResponse;
    }
}
