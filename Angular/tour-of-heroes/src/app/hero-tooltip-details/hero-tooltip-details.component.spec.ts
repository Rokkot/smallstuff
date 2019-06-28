import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HeroTooltipDetailsComponent } from './hero-tooltip-details.component';

describe('TooltipDetailsComponent', () => {
  let component: HeroTooltipDetailsComponent;
  let fixture: ComponentFixture<HeroTooltipDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HeroTooltipDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HeroTooltipDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
