import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HofDetailsComponent } from './hof-details.component';

describe('HofDetailsComponent', () => {
  let component: HofDetailsComponent;
  let fixture: ComponentFixture<HofDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HofDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HofDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
