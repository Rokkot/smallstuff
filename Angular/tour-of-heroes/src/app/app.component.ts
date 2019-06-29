import { Component, Input } from '@angular/core';
import { RadioBtnComponent } from './radio-btn/radio-btn.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Tour of Heroes'

  useCardView: boolean = false;
  // useCardView2: boolean = false;
  // vMode: string;

  onVeiewChanged(isCView: boolean) {
    this.useCardView = isCView;
  }

  onViewModeChanged(mode: boolean) {
    this.useCardView = mode;
  }
}
