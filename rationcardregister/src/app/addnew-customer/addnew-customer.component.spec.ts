import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddnewCustomerComponent } from './addnew-customer.component';

describe('AddnewCustomerComponent', () => {
  let component: AddnewCustomerComponent;
  let fixture: ComponentFixture<AddnewCustomerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddnewCustomerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddnewCustomerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
