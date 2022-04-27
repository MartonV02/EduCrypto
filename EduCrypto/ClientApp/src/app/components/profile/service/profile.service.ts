import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { UserTradeHistoryModel } from 'src/app/shared/UserTradeHistoryModel';
import { BackendUrlEnum } from '../../../shared/BackendUrlEnum.constant';
import { GenericUrlGenerator } from '../../../shared/GenericUrlGenerator.service';
import { UserCryptoModel } from '../model/UserCrypto.model';

@Injectable({
  providedIn: 'root'
})
export class ProfileService
{
  private _uriGenerator: GenericUrlGenerator = new GenericUrlGenerator(BackendUrlEnum.UserTradeHistory);
  private _uriGenerator1: GenericUrlGenerator = new GenericUrlGenerator(BackendUrlEnum.UserCrypto);

  constructor(private http: HttpClient) { }

  public GetByUserId(userId: number): Observable<UserTradeHistoryModel[]>
  {

      var HttpURI = this._uriGenerator.GetUrlWithParam(userId);
      return this.http.get<UserTradeHistoryModel[]>(HttpURI)
        .pipe(
          take(1),
          map((data: UserTradeHistoryModel[]) =>
          {
              return data;
          })
        );
  }

  public GetUserCrypto(userId:number): Observable<UserCryptoModel[]>
  {
    var HttpURI = this._uriGenerator1.GetUrlWithParam(userId);
    return this.http.get<UserCryptoModel[]>(HttpURI).pipe(
      take(1),
      map((data: UserCryptoModel[]) => 
      {
        return data;
      })
    );
  }
}
