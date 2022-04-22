import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { UserTradeHistoryModel } from 'src/app/shared/UserTradeHistoryModel';
import { ProfileService } from './service/profile.service';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})

export class ProfileComponent implements OnInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;

  public tradeModel : UserTradeHistoryModel[];
  public userId = 3;
  public boughtValue : number[];
  public dataSource: any;
  ngOnInit(): void {
    this.getHistory();
  }

  constructor(
    private profileService : ProfileService
  ) {}


  public getHistory(): void {
    
    this.profileService.GetByUserId(this.userId).subscribe((result)=> 
    {
      this.tradeModel = result;
      this.boughtValue = this.tradeModel.map(x => x.boughtValue);
      this.dataSource = new MatTableDataSource<UserTradeHistoryModel>(this.tradeModel);
      this.dataSource.paginator = this.paginator;
      console.log(this.tradeModel);
      console.log(this.boughtValue);
    });
  }

  displayedColumns: string[] =
  [
    'boughtCryptoSymbol',
    'boughtValue',
    'tradeDate',
  ];
}
