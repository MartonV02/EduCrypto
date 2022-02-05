import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import { RecaptchaModule } from 'ng-recaptcha';
import {MatProgressBarModule} from '@angular/material/progress-bar';


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
  MatProgressBarModule
];

@NgModule({
  imports: [Material],
  exports: [Material]
})
export class MaterialModule { }
