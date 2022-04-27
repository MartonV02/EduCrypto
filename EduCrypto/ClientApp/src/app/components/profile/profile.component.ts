import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { UserTradeHistoryModel } from 'src/app/shared/UserTradeHistoryModel';
import { ProfileService } from './service/profile.service';
import { MatPaginator } from '@angular/material/paginator';
import { LoginComponent } from '../login/login.component';
import { LoginService } from '../login/service/login.service';
import { UserCryptoModel } from './model/UserCrypto.model';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})

export class ProfileComponent implements OnInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;

  public tradeModel : UserTradeHistoryModel[];
  public userId:number;
  public boughtValue : number[];
  public dataSource: any;
  public userCrypto : UserCryptoModel[];
  public allCrypto: number[] =[];
  public boughtCryptos: any[];
  public balance: number[];
  ngOnInit(): void {
    this.userId = this.login.provideActualUserId;
    // console.log(this.userId)
    this.getHistory();
    this.getUserData();
  }

  constructor(
    private profileService : ProfileService,
    private login : LoginService
  ) {}


  public getHistory(): void {
    
    this.profileService.GetByUserId(this.userId).subscribe((result)=> 
    {
      this.tradeModel = result;
      this.boughtValue = this.tradeModel.map(x => x.boughtValue);
      this.balance = this.tradeModel.map(x=> x.userHandlingModel.moneyDollar);
      console.log(this.balance);
      Math.round(this.balance[0]);
      // console.log(this.boughtValue);
      this.dataSource = new MatTableDataSource<UserTradeHistoryModel>(this.tradeModel);
      this.dataSource.paginator = this.paginator;
    });
  }

  public getUserData(): void {
    this.profileService.GetUserCrypto(this.userId).subscribe((result)=>
    {
      this.userCrypto = result;
      console.log(this.userCrypto);
      // this.userCrypto.forEach(x=> this.allCrypto.push(x.cryptoValue));
      this.allCrypto = this.userCrypto.map(x=> x.cryptoValue);
      this.boughtCryptos = this.userCrypto.map(x=> x.cryptoSymbol);
      console.log(this.allCrypto);
      console.log(this.boughtCryptos);
    })
  }

  displayedColumns: string[] =
  [
    'boughtCryptoSymbol',
    'boughtValue',
    'tradeDate',
  ];

  displayedColumns2: string[] =
  [
    'cryptoSymbol',
    'boughtValue',
  ];
}
