import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CarListComponent } from './cars/cars.component';
import { CarAlertsComponent } from './car-alerts/car-alerts.component';

@NgModule({
  declarations: [
    AppComponent,
    CarListComponent,
    CarAlertsComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: CarListComponent }
    ]),
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  exports: [CarAlertsComponent]
})
export class AppModule { }
