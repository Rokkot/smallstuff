import { Component } from '@angular/core';

import { cars } from '../cars';

@Component({
    selector: 'app-cars',
    templateUrl: './cars.component.html',
    styleUrls: ['./cars.component.css']
  })
export class CarListComponent {
  cars = cars;

  share(name) {
    window.alert(this.newMethod(name));
  }

  private newMethod(name): any {
    return 'The \'' + name + '\' car has been shared!';
  }
}