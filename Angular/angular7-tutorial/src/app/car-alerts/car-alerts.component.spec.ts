import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CarAlertsComponent } from './car-alerts.component';

describe('CarAlertsComponent', () => {
  let component: CarAlertsComponent;
  let fixture: ComponentFixture<CarAlertsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CarAlertsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarAlertsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
