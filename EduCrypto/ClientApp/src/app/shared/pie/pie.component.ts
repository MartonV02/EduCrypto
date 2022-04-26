import { Component, OnInit, ViewChild } from '@angular/core';
import * as apex from 'ng-apexcharts';
import { ProfileComponent } from 'src/app/components/profile/profile.component';
import { ProfileService } from 'src/app/components/profile/service/profile.service';
import { UserTradeHistoryModel } from '../UserTradeHistoryModel';

export type ChartOptions = {
  series: apex.ApexNonAxisChartSeries;
  chart: apex.ApexChart;
  responsive: apex.ApexResponsive[];
  labels: any;
  legend: apex.ApexLegend;
  formatLabels: apex.ApexDataLabels;
  dataLabels: apex.ApexDataLabels;
  plotOptions: apex.ApexPlotOptions;
};

@Component({
  selector: 'app-pie',
  templateUrl: './pie.component.html',
  styleUrls: ['./pie.component.scss'],
})
export class PieComponent implements OnInit {
  @ViewChild('chart') chart: PieComponent;
  public tradeService: ProfileComponent;
  public chartOptions: Partial<ChartOptions> | any;
  public data = [23, 45, 34];
  public cryptos = ['Bitcoin', 'Ethereum'];

  ngOnInit(): void {
    this.getHistory();
  }
  public tradeModel : UserTradeHistoryModel[];
  public userId = 3;
  public boughtValue : number[];
  
  

  public getHistory(): void {
    
    this.profileService.GetByUserId(this.userId).subscribe((result)=> 
    {
      this.tradeModel = result;
      this.boughtValue = this.tradeModel.map(x => x.boughtValue);
    });
  }

  constructor(private profileService : ProfileService) {
    this.chartOptions = {
      series: [1,2],
      chart: {
        type: 'donut',
        foreColor: '#50b2c0',
        width: 500,
        
      },
      legend: {
        show: true,
        position: 'left',

      },
      dataLabels: {
        enabled: false,
      },
      plotOptions: {
        pie: {
          donut:{
            size: 80,
            labels: {
              show: true,
              name: {
                show:true,
              },
              total: {
                show:true
              }
            },

          }
        }
      },
      labels: this.cryptos,
      responsive: [
        {
          breakpoint: 100,
          options: {
            chart: {
              width: 200,
            },
          },
        },
      ],
    };
    
  }
  public updateSeries() {
    this.chartOptions.series = [{
        data: this.boughtValue
    }];
  }


}
