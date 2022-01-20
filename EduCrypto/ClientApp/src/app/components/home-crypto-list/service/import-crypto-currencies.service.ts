import { HttpClient } from "@angular/common/http";
import { Component, Injectable } from "@angular/core";
import { Observable } from "rxjs";

//https://github.com/sbuntz/InstantCrypto/blob/main/assets/js/script.js
//https://coursetro.com/posts/code/91/Angular-CryptoCurrency-Tutorial---Display-Exchange-Data-with-an-API
//https://api.coingecko.com/api/v3/coins/markets?vs_currency=aud&order=market_cap_desc&per_page=100
//Using CoinGecko API

@Injectable({
  providedIn: 'root'
})
export class HomeCryptoListService {
  private _http;

  constructor(private http: HttpClient) {
    this._http = http;
  }

  public getListOfCryptos(): Observable<> {
    this._http.get("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest",
      {
        headers:
        {
          'X-CMC_PRO_API_KEY': 'a32bf73f-f24a-4484-8d59-220e19acd17d',
        }
      })
  }
}
