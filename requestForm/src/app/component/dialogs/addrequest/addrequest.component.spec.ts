import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddrequestComponent } from './addrequest.component';

describe('AddrequestComponent', () => {
  let component: AddrequestComponent;
  let fixture: ComponentFixture<AddrequestComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddrequestComponent]
    });
    fixture = TestBed.createComponent(AddrequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
