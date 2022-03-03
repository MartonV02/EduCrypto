import { Component, OnInit } from '@angular/core';
import { LegendPosition, Color, colorSets } from '@swimlane/ngx-charts';
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})

export class ProfileComponent implements OnInit {

  constructor() {}

  public Cryptos = [
    {
      name: 'Bitcoin',
      value: '12',
    },
    {
      name: 'Ethereum',
      value: '35',
    },
    {
      name: 'DogeCoin',
      value: '54',
    },
    {
      name: 'XRP',
      value: '110',
    },
    {
      name: 'LiteCoin',
      value: '87',
    },
  ];

  // public view: [number, number] = [400, 200];
  public legendTitle: string = 'Cryptos';
  public legendPosition: LegendPosition = LegendPosition.Below; //right or below;
  public legend: boolean = true;
  customColors = 
  [
    { name: "Bitcoin", value: '#F46197' },
    { name: "Ethereum", value: '#3F88C5' },
    { name: "DogeCoin", value: '#44BBA4' },
    { name: "XRP", value: '#FFD23F' },
    { name: "LiteCoin", value: '#3C91E6' },
  ]
  // public scheme: string | Color = "valami" 


  ngOnInit(): void {
  }
}
