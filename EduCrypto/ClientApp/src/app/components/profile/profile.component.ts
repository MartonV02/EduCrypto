import { Component, OnInit } from '@angular/core';
import { UserTradeHistoryModel } from 'src/app/shared/UserTradeHistoryModel';
import { ProfileService } from './service/profile.service';
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})

export class ProfileComponent implements OnInit {

  public tradeModel : UserTradeHistoryModel[];
  public userId = 3;
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
      console.log(this.tradeModel);
    });
  }
}
