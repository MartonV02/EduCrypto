import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { LoginService } from "../components/login/service/login.service";


@Injectable()
export class JwtAuthorizationInterceptor implements HttpInterceptor
{
  constructor(private loginService: LoginService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>>
  {
    const requestRoute = req.url;
    const disabledRouteForInterceptor: Array<string> = ["api/ImportCrypto", "api/Login", "api/UserHandling"];

    if (disabledRouteForInterceptor.indexOf(requestRoute) == -1)
    {
      const actualUserModel = this.loginService.responseModelToInterceptor;
      const isLoggedIn = actualUserModel.token;

      if (isLoggedIn)
      {
        req = req.clone({
          setHeaders: { Authorization: `Bearer ${actualUserModel.token}` }
        });
      }
    }

    return next.handle(req);
  }
}
