import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map, take } from "rxjs/operators";
import { BackendUrlEnum } from "src/app/shared/BackendUrlEnum.constant";
import { GenericUrlGenerator } from "src/app/shared/GenericUrlGenerator.service";
import { UserHandlingModel } from "src/app/shared/user-handling.model";

@Injectable({
    providedIn: 'root'
  })
  export class LoginService
  {
    private _uriGenerator: GenericUrlGenerator = new GenericUrlGenerator(BackendUrlEnum.Login);

    constructor(private _http: HttpClient) { }

    public sendLogIn(loginData: any): Observable<any>
    {
      var HttpURI = this._uriGenerator.GetBasicUrl();

      return this._http.post<any>(HttpURI, loginData)
        .pipe(
          take(1),
          map((jwtToken: any) =>
          {
              return jwtToken;
          })
        );
    }
  }
