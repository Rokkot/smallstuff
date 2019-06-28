import { Component, OnInit, Input } from '@angular/core';
import { Hero } from '../hero';

@Component({
  selector: 'app-hero-tooltip-details',
  templateUrl: './hero-tooltip-details.component.html',
  styleUrls: ['./hero-tooltip-details.component.css']
})
export class HeroTooltipDetailsComponent implements OnInit {

  @Input() hero: Hero;

  constructor() { }

  ngOnInit() {
  }
}
