import { Injectable } from "@angular/core";
import { UserHandlingModel } from "src/app/shared/user-handling.model";
import { loginModel } from "../model/login.model";

@Injectable({
    providedIn: 'root'
  })
  export class LoginService
  {
    public sendLogIn(loginData: UserHandlingModel): string
    {
      
    }
    
  }