import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
//import { cars } from '../cars';

@Component({
  selector: 'app-car-alerts',
  templateUrl: './car-alerts.component.html',
  styleUrls: ['./car-alerts.component.css']
})

export class CarAlertsComponent implements OnInit {

  @Input() car;

  @Output() notify = new EventEmitter();
  
  constructor() { }

  ngOnInit() {
  }

}