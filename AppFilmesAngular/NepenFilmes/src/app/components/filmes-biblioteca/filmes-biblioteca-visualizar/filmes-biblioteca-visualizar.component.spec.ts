import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilmesBibliotecaVisualizarComponent } from './filmes-biblioteca-visualizar.component';

describe('FilmesBibliotecaVisualizarComponent', () => {
  let component: FilmesBibliotecaVisualizarComponent;
  let fixture: ComponentFixture<FilmesBibliotecaVisualizarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FilmesBibliotecaVisualizarComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FilmesBibliotecaVisualizarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
