import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  hide: boolean = false;
  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {}
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
  

}
