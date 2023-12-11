import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MeusFilmesComponent } from './meus-filmes.component';

describe('MeusFilmesComponent', () => {
  let component: MeusFilmesComponent;
  let fixture: ComponentFixture<MeusFilmesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MeusFilmesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MeusFilmesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
