import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map, take } from "rxjs/operators";
import { ImportedCryptoModel } from "../model/imported-crypto.model";

//https://github.com/sbuntz/InstantCrypto/blob/main/assets/js/script.js
//https://coursetro.com/posts/code/91/Angular-CryptoCurrency-Tutorial---Display-Exchange-Data-with-an-API
//https://api.coingecko.com/api/v3/coins/markets?vs_currency=aud&order=market_cap_desc&per_page=100
//Using CoinGecko API

@Injectable({
  providedIn: 'root'
})
export class HomeCryptoListService
{
  constructor(private http: HttpClient) { }

  public getListOfCryptos(): Observable<any>
  {
    return this.http.get<any>("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest",
      {
        headers:
        {
          'Access-Control-Allow-Origin': '*',
          'X-CMC_PRO_API_KEY': 'a32bf73f-f24a-4484-8d59-220e19acd17d',
        }
      })
      .pipe(
        take(1),
        map((data: any) =>
        {
          return data;
        })
      );
  }
}
