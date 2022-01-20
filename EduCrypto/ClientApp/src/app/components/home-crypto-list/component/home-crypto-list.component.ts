import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { Observable } from "rxjs";

@Component({
  selector: 'app-home-crypto-list',
  templateUrl: './home-crypto-list.component.html',
  styleUrls: ['./home-crypto-list.component.scss']
})
export class HomeCryptoListComponent
{
  //private _queryURL = `https://api.coingecko.com/api/v3/coins/markets?vs_currency=aud&order=market_cap_desc&per_page=100&page=1&ids=${coinID}`; - can be an alternative
  //https://www.youtube.com/watch?v=2xOgkCT7MOQ
  //https://www.youtube.com/watch?v=292A8yq2U2A - option A 10k request free - every 5 min in a month
  //https://algotrading101.com/learn/coingecko-api-guide/

  private _http;
  private _queryURL = "https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest";

  constructor(private http: HttpClient)
  {
    this._http = http;
  }

  public getListOfCryptos(): Observable<>
  {
    this._http.get( this._queryURL,
      {
        headers:
        {
          'X-CMC_PRO_API_KEY': 'a32bf73f-f24a-4484-8d59-220e19acd17d',
        }
      })
  }
}
