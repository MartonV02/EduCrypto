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
}
