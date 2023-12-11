import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MeusFilmesComponent } from '../../meus-filmes/meus-filmes.component';

@Component({
  selector: 'app-visualizar-filme',
  standalone:true,
  imports: [MatButtonModule,CommonModule,MeusFilmesComponent],
  templateUrl: './visualizar-filme.component.html',
  styleUrl: './visualizar-filme.component.css'
})
export class VisualizarFilmeComponent {
  @Output() visualizarUnico = new EventEmitter();
  @Input() Filme: any;
  @Input() Tipo: any;
  acaoAdicionarEscolher: string = "escolher";

  ngOnInit(){
      console.log(this.Filme)
  }
  voltarHome(){

    this.visualizarUnico.emit(false);
  }
}
