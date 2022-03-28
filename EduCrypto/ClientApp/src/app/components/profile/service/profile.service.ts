import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { BackendUrlEnum } from '../../../shared/BackendUrlEnum.constant';
import { GenericUrlGenerator } from '../../../shared/GenericUrlGenerator.service';

@Injectable({
  providedIn: 'root'
})
export class ImportCryptoCurrenciesService
{
  private _uriGenerator: GenericUrlGenerator = new GenericUrlGenerator(BackendUrlEnum.UserTradeHistory);

  constructor(private http: HttpClient) { }

  public getListOfCryptos(): Observable<ImportedCryptoModel[]>
  {
    var HttpURI = this._uriGenerator.GetBasicUrl();

    return this.http.get<ImportedCryptoModel[]>(HttpURI)
      .pipe(
        take(1),
        map((data: ImportedCryptoModel[]) =>
        {
            return data;
        })
      );
  }
}
