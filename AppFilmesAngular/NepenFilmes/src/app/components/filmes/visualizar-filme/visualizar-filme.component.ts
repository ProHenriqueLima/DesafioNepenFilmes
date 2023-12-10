import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-visualizar-filme',
  standalone: true,
  imports: [MatButtonModule,CommonModule],
  templateUrl: './visualizar-filme.component.html',
  styleUrl: './visualizar-filme.component.css'
})
export class VisualizarFilmeComponent {
  @Output() visualizarUnico = new EventEmitter();
  @Input() Filme: any;
  @Input() Tipo: any;

  ngOnInit(){
      console.log(this.Filme)
  }
  voltarHome(){

    this.visualizarUnico.emit(false);
  }
}
