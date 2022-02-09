import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ImportedCryptoModel } from '../model/imported-crypto.model';
import { ImportCryptoCurrenciesService } from '../service/import-crypto-currencies.service';

@Component({
  selector: 'home-crypto-list',
  templateUrl: './home-crypto-list.component.html',
  styleUrls: ['./home-crypto-list.component.scss']
})
export class HomeCryptoListComponent implements OnInit, AfterViewInit
{
  @ViewChild(MatPaginator) paginator: MatPaginator;

  public entities: ImportedCryptoModel[];
  public dataSource: any;

  ngAfterViewInit()
  {
  }

  displayedColumns: string[] =
  [
    'name',
    'symbol',
    //'date_added',
    //'percent_change_1h',
    //'percent_change_24h',
    'price'
    //'percent_change_7d',
    //'percent_change_30d',
    //'percent_change_90d',
    //'market_cap_dominance',
  ];

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
        this.dataSource = new MatTableDataSource<ImportedCryptoModel>(this.entities);
        this.dataSource.paginator = this.paginator;
      });
  }
}
