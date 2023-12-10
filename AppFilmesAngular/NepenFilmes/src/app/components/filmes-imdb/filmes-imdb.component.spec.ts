import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilmesIMDBComponent } from './filmes-imdb.component';

describe('FilmesIMDBComponent', () => {
  let component: FilmesIMDBComponent;
  let fixture: ComponentFixture<FilmesIMDBComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FilmesIMDBComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FilmesIMDBComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
