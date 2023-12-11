import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilmesBibliotecaComponent } from './filmes-biblioteca.component';

describe('FilmesBibliotecaComponent', () => {
  let component: FilmesBibliotecaComponent;
  let fixture: ComponentFixture<FilmesBibliotecaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FilmesBibliotecaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FilmesBibliotecaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
