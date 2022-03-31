import { Component, OnInit, ViewChild } from '@angular/core';
import * as apex from 'ng-apexcharts';
import { ProfileService } from 'src/app/components/profile/service/profile.service';

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
  public tradeService: ProfileService;
  public chartOptions: Partial<ChartOptions> | any;
  public data = [23, 45, 34];
  public cryptos = ['Bitcoin', 'Ethereum', 'LiteCoin'];

  ngOnInit(): void {}

  constructor() {
    this.chartOptions = {
      series: this.data,
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
}
