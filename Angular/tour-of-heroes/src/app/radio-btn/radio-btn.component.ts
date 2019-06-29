import { Component, OnInit, Input, Output } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { MatRadioChange } from '@angular/material';

@Component({
  selector: 'app-radio-btn',
  templateUrl: './radio-btn.component.html',
  styleUrls: ['./radio-btn.component.css']
})
export class RadioBtnComponent implements OnInit {

  @Input() isCardViewMode:boolean = true;

  viewMode: string;

  //@Output() modeChange: EventEmitter<string> = new EventEmitter<string>();

  @Output() modeChange: EventEmitter<boolean> = new EventEmitter<boolean>();

  // @Input() get mode(){
  //   return this.viewMode;
  // }

  // set mode(val){
  //   this.viewMode=val;
  //   this.alertMsg = val; 
  //   this.modeChange.emit(this.viewMode);
  // }

  
  //@Output() valueChange: EventEmitter<boolean> = new EventEmitter<boolean>();

  

  viewModes: string[] = ['Card View', 'Tooltip View'];

  constructor() { }

  ngOnInit() {
    this.viewMode = (this.isCardViewMode) ? this.viewModes[0] : this.viewModes[1];
  }

  //alertMsg:string = "1234";


  // onValueChanged(mode:string){
  //   this.alertMsg = "onValueChanged";
  //   this.isCardViewMode = (mode==this.viewModes[0]);
  //   this.valueChange.emit(this.isCardViewMode);
  // }

  radioChange(event: MatRadioChange) {
    //this.alertMsg = event.value;
    //this.mode = event.value;
    this.viewMode = event.value;
    this.isCardViewMode = (this.viewMode==this.viewModes[0]);
    this.modeChange.emit(this.isCardViewMode);
  }

  // valueChanged() {
  //   this.valueChange.emit(this.viewMode);
  // }

}
