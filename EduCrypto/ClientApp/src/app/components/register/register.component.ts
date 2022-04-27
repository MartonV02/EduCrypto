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
  hide= true;
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

  ngOnInit(): void {
    if(this.appComp.isDarkRecaptcha)
    {
      this.captchaColor= true
    }
    else {
      this.captchaColor = false
    }
    this.form = this.fb.group({
      username: ['', [Validators.required, Validators.minLength(4)]],
      email: ['', [Validators.required, Validators.email]],
      fullName: ['', [Validators.required]],
      date: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(2)]],
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

      console.log(newUser);

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
    resolved(captchaResponse: string) {
      this.key = captchaResponse;
    }
}
