import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { BackendUrlEnum } from 'src/app/shared/BackendUrlEnum.constant';
import { GenericUrlGenerator } from 'src/app/shared/GenericUrlGenerator.service';
import { HomeCryptoListModel } from '../model/home-crypto-list.model';

@Injectable({
  providedIn: 'root'
})
export class HomeCryptoListService 
{

  private _uriGenerator: GenericUrlGenerator = new GenericUrlGenerator(BackendUrlEnum.UserTradeHistory);

  constructor(private _http: HttpClient) { }

  public Create(homeCryptoListModel: HomeCryptoListModel): Observable<HomeCryptoListModel[]>
  {
    var HttpURI = this._uriGenerator.GetBasicUrl();

    return this._http.put<HomeCryptoListModel[]>(HttpURI, homeCryptoListModel)
      .pipe(
        take(1),
        map((data: HomeCryptoListModel[]) =>
        {
            return data;
        })
      );
  }

  public GetByUserId(userId: number): Observable<HomeCryptoListModel[]>
  {
      var HttpURI = this._uriGenerator.GetUrlWithParam(userId);

      return this._http.get<HomeCryptoListModel[]>(HttpURI)
        .pipe(
          take(1),
          map((data: HomeCryptoListModel[]) =>
          {
              return data;
          })
        );
    }
}
