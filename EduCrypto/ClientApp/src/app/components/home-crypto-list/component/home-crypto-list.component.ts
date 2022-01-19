import { Component } from "@angular/core";

@Component({
  selector: 'app-home-crypto-list',
  templateUrl: './home-crypto-list.component.html',
  styleUrls: ['./home-crypto-list.component.scss']
})
export class HomeCryptoListComponent
{
  private _queryURL = `https://api.coingecko.com/api/v3/coins/markets?vs_currency=aud&order=market_cap_desc&per_page=100&page=1&ids=${coinID}`;
  //https://www.youtube.com/watch?v=2xOgkCT7MOQ
  constructor()
  {
  }

  getListOfCryptos(): any
  {

  }
}
