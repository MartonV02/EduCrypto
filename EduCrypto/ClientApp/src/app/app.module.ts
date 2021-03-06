import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FlexLayoutModule } from '@angular/flex-layout';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MatNativeDateModule } from '@angular/material/core';
import { MaterialModule } from './material/material.module';
import { MenuSideBarTemplateComponent } from './components/menu-sidebar-template/component/menu-sidebar-template.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { QuizComponent } from './components/quiz/quiz.component';

import { HomeCryptoListComponent } from './components/home-crypto-list/component/home-crypto-list.component';
import { ProfileComponent } from './components/profile/profile.component';
import { JwtAuthorizationInterceptor } from './shared/jwt-authorization.interceptor';
import { PieComponent } from './shared/pie/pie.component';
import { NgApexchartsModule } from "ng-apexcharts";
import {MatSnackBarModule} from '@angular/material/snack-bar';



@NgModule({
  declarations: [
    AppComponent,
    MenuSideBarTemplateComponent,
    LoginComponent,
    RegisterComponent,
    QuizComponent,
    HomeCryptoListComponent,
    ProfileComponent,
    PieComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    MatNativeDateModule,
    ReactiveFormsModule,
    MaterialModule,
    FlexLayoutModule,
    NgApexchartsModule,
    MatSnackBarModule
  ],
  providers:  
  [
    { provide: HTTP_INTERCEPTORS, useClass: JwtAuthorizationInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
