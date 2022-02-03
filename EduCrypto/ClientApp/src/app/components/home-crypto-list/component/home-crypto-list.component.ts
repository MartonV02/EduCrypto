import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ImportedCryptoModel } from '../model/imported-crypto.model';
import { ImportCryptoCurrenciesService } from '../service/import-crypto-currencies.service';

@Component({
  selector: 'home-crypto-list',
  templateUrl: './home-crypto-list.component.html',
  styleUrls: ['./home-crypto-list.component.scss']
})
export class HomeCryptoListComponent implements OnInit
{
  @ViewChild(MatPaginator) paginator: MatPaginator;

  public entities: ImportedCryptoModel[];
  public dataSource: any;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  displayedColumns: string[] =
  [
    'id',
    'name',
    'symbol',
    'date_added',
    'circulating_supply',
    'percent_change_1h',
    'percent_change_24h',
    'percent_change_7d',
    'percent_change_30d',
    'percent_change_90d',
    'market_cap_dominance',
  ];

  constructor(private _importCryptoCurrenciesService: ImportCryptoCurrenciesService) { }

  ngOnInit(): void
  {
    this.getList();
    this.dataSource = new MatTableDataSource<ImportedCryptoModel>(this.entities);
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
