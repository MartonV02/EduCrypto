import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { UserTradeHistoryModel } from 'src/app/shared/UserTradeHistoryModel';
import { BackendUrlEnum } from '../../../shared/BackendUrlEnum.constant';
import { GenericUrlGenerator } from '../../../shared/GenericUrlGenerator.service';

@Injectable({
  providedIn: 'root'
})
export class ProfileService
{
  private _uriGenerator: GenericUrlGenerator = new GenericUrlGenerator(BackendUrlEnum.UserTradeHistory);
  public auth_token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImNzb21iaUBnbWFpbC5jb20iLCJ1c2VySWQiOiIzIiwiZXhwIjoxNjUwMDM2OTA5LCJpc3MiOiJ0cmFkZXIiLCJhdWQiOiJmZWRlcmF0aW9uIn0.tEjctaEXmbrsiS7S4FRznAE5RtCKpNaVB3Mtatk30YU";

  constructor(private http: HttpClient) { }

  public GetByUserId(userId: number): Observable<UserTradeHistoryModel[]>
  {

      var HttpURI = this._uriGenerator.GetUrlWithParam(userId);
      const headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.auth_token}`
      })
      return this.http.get<UserTradeHistoryModel[]>(HttpURI, {"headers": headers})
        .pipe(
          take(1),
          map((data: UserTradeHistoryModel[]) =>
          {
              return data;
          })
        );
    }
}
