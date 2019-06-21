import { Component } from '@angular/core';

import { cars } from '../cars';

@Component({
    selector: 'app-cars',
    templateUrl: './cars.component.html',
    styleUrls: ['./cars.component.css']
  })
export class CarListComponent {
  cars = cars;

  share() {
    window.alert(this.newMethod());
  }

  private newMethod(): any {
    return 'The car has been shared!';
  }
}