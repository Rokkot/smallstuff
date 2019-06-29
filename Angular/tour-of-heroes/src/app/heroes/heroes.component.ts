import { Component, OnInit, Input} from '@angular/core';
import { Hero } from '../hero';
import { HEROES } from '../mock-heroes';

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.css']
})
export class HeroesComponent implements OnInit {

  heroes = HEROES;
  selectedHero: Hero;
  isBtnClicked: boolean = false;

  @Input() useCardView: boolean=false;
  
  constructor() { }

  ngOnInit() {
  }

  onClick(hero: Hero){
    this.selectedHero = hero;
    this.isBtnClicked = true;
  }

  onMouseEnter(hero: Hero){
    this.selectedHero = hero;
  }

  onMouseLeave(hero: Hero){
    if( this.isBtnClicked == false)
      this.selectedHero = null;
  }
}
