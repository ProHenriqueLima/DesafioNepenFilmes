import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualizarFilmeComponent } from './visualizar-filme.component';

describe('VisualizarFilmeComponent', () => {
  let component: VisualizarFilmeComponent;
  let fixture: ComponentFixture<VisualizarFilmeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VisualizarFilmeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VisualizarFilmeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
