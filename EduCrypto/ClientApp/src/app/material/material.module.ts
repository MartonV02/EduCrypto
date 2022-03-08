import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import { RecaptchaModule } from 'ng-recaptcha';
import {MatProgressBarModule} from '@angular/material/progress-bar';

import { MatIconModule } from '@angular/material/icon';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import {MatDatepickerModule} from '@angular/material/datepicker';

const Material = [
  CommonModule,
  MatSidenavModule,
  MatToolbarModule,
  MatButtonModule,
  MatIconModule,
  MatDividerModule,
  MatCardModule,
  MatInputModule,
  ReactiveFormsModule,
  MatFormFieldModule,
  MatSlideToggleModule,
  RecaptchaModule,
  MatProgressBarModule,
  MatTableModule,
  MatPaginatorModule,
  MatDatepickerModule
];

@NgModule({
  imports: [Material],
  exports: [Material]
})
export class MaterialModule { }
