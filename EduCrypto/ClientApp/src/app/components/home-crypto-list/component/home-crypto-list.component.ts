import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ImportedCryptoModel } from '../model/imported-crypto.model';
import { ImportCryptoCurrenciesService } from '../service/import-crypto-currencies.service';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { HomeCryptoListModel } from '../model/home-crypto-list.model';
import { LoginService } from '../../login/service/login.service';
import { HomeCryptoListService } from '../service/home-crypto-list.service';

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
  buyPanelOpenState = false;
  sellPanelOpenState = false;

  public entities: ImportedCryptoModel[];
  public dataSource: any;
  public userLoggedIn: boolean;

  public transactionModel: HomeCryptoListModel = new HomeCryptoListModel();

  displayedColumns: string[] =
  [
    'name',
    'symbol',
    'date_added',
    'max_supply',
    'circulating_supply',
    'percent_Change24h',
    'percent_Change30d',
    'percent_Change90d',
    'actual_USD_Price',
  ];


  constructor(
    private _importCryptoCurrenciesService: ImportCryptoCurrenciesService,
    private _homeCryptoListService: HomeCryptoListService,
    private _loginService: LoginService) { }

  ngOnInit(): void
  {
    this.getList();
    this.userLoggedIn = this._loginService.isUserLoggedIn();
  }

  public createBuyTransaction(symbol: string): void
  {
    this.transactionModel.boughtCryptoSymbol = symbol;
    this.transactionModel.userHandlingModelId = this._loginService.provideActualUserId;
    console.log(this.transactionModel.spentValue);

    this._homeCryptoListService.Create(this.transactionModel).subscribe
    (
      result => { },
      error =>
      {
        console.log(error)
      }
    );

    console.log(this.transactionModel.boughtCryptoSymbol);
  }

  public createSellTransaction(symbol: string): void
  {
    this.transactionModel.spentCryptoSymbol = symbol;
    this.transactionModel.userHandlingModelId = this._loginService.provideActualUserId;
    console.log(this.transactionModel.boughtValue);

    this._homeCryptoListService.Create(this.transactionModel).subscribe
    (
      result => { },
      error =>
      {
        console.log(error)
      }
    );

    console.log(this.transactionModel.boughtCryptoSymbol);
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
