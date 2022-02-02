import { Component, OnInit } from '@angular/core';
import { ImportedCryptoModel } from '../model/imported-crypto.model';
import { ImportCryptoCurrenciesService } from '../service/import-crypto-currencies.service';

@Component({
  selector: 'home-crypto-list',
  templateUrl: './home-crypto-list.component.html',
  styleUrls: ['./home-crypto-list.component.scss']
})
export class HomeCryptoListComponent implements OnInit
{
  displayedColumns: string[] = ['id', 'name', 'symbol', 'slug'];
  public entities: ImportedCryptoModel[];
  //public entities = new MatTableDataSource<ImportedCryptoModel[]>();

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
        this.entities = data;
        console.log(this.entities);
      });
  }
}
