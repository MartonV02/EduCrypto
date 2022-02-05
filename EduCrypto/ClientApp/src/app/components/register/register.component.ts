import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  key : string;
  hide: boolean = false;
  constructor(private fb: FormBuilder) {
    this.key = '';
   }

  ngOnInit(): void {}
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
