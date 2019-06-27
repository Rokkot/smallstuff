import { Component } from '@angular/core';

import { cars } from '../cars';

@Component({
    selector: 'app-cars',
    templateUrl: './cars.component.html',
    styleUrls: ['./cars.component.css']
  })
export class CarListComponent {
  cars = cars;
  //IsNotifyOn = false;

  share(name) {
    this.displayMessage(this.newMethod(name));
  }

  onNotify(){
    this.displayMessage('You will be notified when the product goes on sale');
   
  }

  onNotify2(car){
       //this.IsNotifyOn = true;
       car.isNotifyOn = !car.isNotifyOn;
  }

  private newMethod(name): any {
    return 'The \'' + name + '\' car has been shared!';
  }

  private displayMessage(message: string){
    window.alert(message);
  }

}