import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatSidenavModule } from '@angular/material/sidenav';

const Material = [
  CommonModule,
  MatSidenavModule,
];

@NgModule({
  imports: [Material],
  exports: [Material]
})
export class MaterialModule { }
