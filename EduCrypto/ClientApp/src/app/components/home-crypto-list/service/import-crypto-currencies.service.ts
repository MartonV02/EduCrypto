import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map, take } from "rxjs/operators";
import { BackendUrlEnum } from "../../../shared/BackendUrlEnum.constant";
import { GenericUrlGenerator } from "../../../shared/GenericUrlGenerator.service";
import { ImportedCryptoModel } from "../model/imported-crypto.model";
import { Bac}

//https://github.com/sbuntz/InstantCrypto/blob/main/assets/js/script.js
//https://coursetro.com/posts/code/91/Angular-CryptoCurrency-Tutorial---Display-Exchange-Data-with-an-API
//https://api.coingecko.com/api/v3/coins/markets?vs_currency=aud&order=market_cap_desc&per_page=100
//Using CoinGecko API

@Injectable({
  providedIn: 'root'
})
export class HomeCryptoListService
{
  private _uriGenerator: GenericUrlGenerator = new GenericUrlGenerator(BackendUrlEnum.ImportCrypto);

  constructor(private http: HttpClient) { }

  public getListOfCryptos(): Observable<ImportedCryptoModel>
  {
    var HttpURI = this._uriGenerator.GetBasicUrl();

    return this.http.get<ImportedCryptoModel>(HttpURI)
      .pipe(
        take(1),
        map((data: any) =>
        {
          return data;
        })
      );
  }
}
