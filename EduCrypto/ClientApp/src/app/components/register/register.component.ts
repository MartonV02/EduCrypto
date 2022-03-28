import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AppComponent } from 'src/app/app.component';
import { RegisterModel } from './model/register.model';
import { RegisterService } from './service/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  key : string;
  hide: boolean = false;
  public captchaColor: boolean;
  public registerModel: RegisterModel[] = [];
  form: FormGroup;
  minDate = new Date(1950, 0, 1);
  maxDate = new Date();
  constructor(
    private fb: FormBuilder,
    private appComp: AppComponent,
    private registerService: RegisterService,
    private router: Router) {
    this.key = '';
    this.maxDate.setFullYear(this.maxDate.getFullYear()-18);
   }

  //  this.form = this.fb.group({
  //     username: ['', [Validators.required, Validators.minLength(3)]],
  //     email: ['', [Validators.required, Validators.email]],
  //     fullName: ['', [Validators.required]],
  //     date: ['', [Validators.required]],
  //     Passwords: this.fb.group({
  //       password: ['', [Validators.required, Validators.minLength(6)]],
  //       confirmPassword: ['', [Validators.required]],
  //     }, {validator: this.comparePasswords})
  //   })

  ngOnInit(): void {
    if(this.appComp.isDarkRecaptcha)
    {
      this.captchaColor= true
    }
    else {
      this.captchaColor = false
    }
    this.form = this.fb.group({
      username: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      fullName: ['', [Validators.required]],
      date: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', [Validators.required]],
      // Passwords: this.fb.group({
      //   password: ['', [Validators.required, Validators.minLength(6)]],
      //   confirmPassword: ['', [Validators.required]],
      // }, {validator: this.comparePasswords})
    })
  }

    signUp() {
        const newUser = {
            email: this.form.value.email,
            password: this.form.value.password,
            userName: this.form.value.username,
            fullName: this.form.value.fullName,
            birthDate: this.form.value.date,
        }

        this.registerService.createUser(newUser).subscribe(
          result => {
            console.log(result);
            this.registerModel.push(result);
            this.router.navigateByUrl('/login');
          },
          error => {
            console.log(error);
          }
        )
      
      
    }


    // comparePasswords(fb: FormGroup) {
    //   let confirmPass = fb.get('confirmPassword');

    //   if (confirmPass?.errors == null || 'passwordMismatch' in confirmPass.errors) 
    //   {
    //     if (fb.get('password')?.value != fb.get('confirmPassword')?.value)
    //     {
    //       confirmPass ?.setErrors({ passwordMismatch: true})
    //     }
    //     else
    //     {
    //       confirmPass?.setErrors(null)  
    //     }
    //   }
    // }

    resolved(captchaResponse: string) {
      this.key = captchaResponse;
    }
}
