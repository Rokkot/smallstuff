import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CarListComponent } from './cars/cars.component';
import { CarAlertsComponent } from './car-alerts/car-alerts.component';
import { CarDetailsComponent } from './car-details/car-details.component';
import { PopoverModule } from 'ngx-smart-popover';

@NgModule({
  declarations: [
    AppComponent,
    CarListComponent,
    CarAlertsComponent,
    CarDetailsComponent,
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    PopoverModule,
    RouterModule.forRoot([
      { path: '', component: CarListComponent },
      { path: 'cars/:carId', component: CarDetailsComponent },
    ]),
    AppRoutingModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent],
  exports: [CarAlertsComponent]

})

export class AppModule { }