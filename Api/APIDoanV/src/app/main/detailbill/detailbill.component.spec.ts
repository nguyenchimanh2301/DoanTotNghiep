import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailbillComponent } from './detailbill.component';

describe('DetailbillComponent', () => {
  let component: DetailbillComponent;
  let fixture: ComponentFixture<DetailbillComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailbillComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailbillComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
