import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ImportedCryptoModel } from '../model/imported-crypto.model';
import { ImportCryptoCurrenciesService } from '../service/import-crypto-currencies.service';
import { animate, state, style, transition, trigger } from '@angular/animations';
//https://stackblitz.com/run?file=src/app/table-expandable-rows-example.ts -- Extend with that

@Component({
  selector: 'home-crypto-list',
  templateUrl: './home-crypto-list.component.html',
  styleUrls: ['./home-crypto-list.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class HomeCryptoListComponent implements OnInit
{
  @ViewChild(MatPaginator) paginator: MatPaginator;

  public expandedElement: PeriodicElement | null;

  public entities: ImportedCryptoModel[];
  public dataSource: any;

  displayedColumns: string[] =
  [
    'name',
    'symbol',
    'date_added',
    'max_supply',
    'circulating_supply',
    'percent_change_24h',
    'percent_change_30d',
    'percent_change_90d',
    'price',
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

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
  description: string;
}
