import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { ImportedCryptoModel } from '../model/imported-crypto.model';
import { ImportCryptoCurrenciesService } from '../service/import-crypto-currencies.service';

@Component({
  selector: 'home-crypto-list',
  templateUrl: './home-crypto-list.component.html',
  styleUrls: ['./home-crypto-list.component.scss']
})
export class HomeCryptoListComponent implements OnInit {

  //private _queryURL = `https://api.coingecko.com/api/v3/coins/markets?vs_currency=aud&order=market_cap_desc&per_page=100&page=1&ids=${coinID}`; - can be an alternative
  //https://www.youtube.com/watch?v=2xOgkCT7MOQ
  //https://www.youtube.com/watch?v=292A8yq2U2A - option A 10k request free - every 5 min in a month
  //https://algotrading101.com/learn/coingecko-api-guide/

  displayedColumns: string[] = ['id', 'name', 'symbol', 'slug'];
  public entity: ImportedCryptoModel[];
  //public entity: Observable<ImportedCryptoModel[]>;

  constructor(private _importCryptoCurrenciesService: ImportCryptoCurrenciesService) { }

  ngOnInit(): void
  {
    this.getList();
  }

  private getList(): void
  {
    this._importCryptoCurrenciesService.getListOfCryptos()
      .subscribe((data: ImportedCryptoModel[]) =>
      {
        this.entity = data;
        console.log(this.entity);
      });
  }
}
