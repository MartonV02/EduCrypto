import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map, take } from "rxjs/operators";
import { BackendUrlEnum } from "../../../shared/BackendUrlEnum.constant";
import { GenericUrlGenerator } from "../../../shared/GenericUrlGenerator.service";
import { LoginResponseModel } from "../model/login.model";

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private _uriGenerator: GenericUrlGenerator = new GenericUrlGenerator(BackendUrlEnum.Login);
  private currentUserModel: LoginResponseModel;

  constructor(private _http: HttpClient) { }

  public sendLogIn(loginData: any): Observable<any> {
    var HttpURI = this._uriGenerator.GetBasicUrl();

    return this._http.post<any>(HttpURI, loginData)
      .pipe(
        take(1),
        map((responseData: LoginResponseModel) =>
        {
          this.currentUserModel = responseData;

          return responseData;
        })
      );
  }

  public isUserLoggedIn(): boolean
  {
    if(this.currentUserModel.userId != 0)
      return true;
    
    return false
  }

  public get responseModelToInterceptor(): LoginResponseModel
  {
    return this.currentUserModel;
  }

  public get provideActualUserId(): number
  {
    return this.currentUserModel.userId;
  }
}
