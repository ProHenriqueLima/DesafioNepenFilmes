import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { VisualizarFilmeComponent } from '../filmes/escolher-filme/visualizar-filme.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { FilmeService } from '../../services/Filmes/filmes.component.service';
import { FilmesBibliotecaVisualizarComponent } from './filmes-biblioteca-visualizar/filmes-biblioteca-visualizar.component';

@Component({
  selector: 'app-filmes-biblioteca',
  standalone: true,
  imports: [MatIconModule,FilmesBibliotecaVisualizarComponent ,CommonModule,FormsModule,VisualizarFilmeComponent,MatButtonModule,MatFormFieldModule,MatInputModule],
  templateUrl: './filmes-biblioteca.component.html',
  styleUrl: './filmes-biblioteca.component.css',
  providers: [FilmeService]
})
export class FilmesBibliotecaComponent {
  Filmes:any;
  visualizar:boolean = false;
  filmeSelecionado:any;
  constructor(private FilmeServices:FilmeService){}
  ngOnInit(){
    this.FilmeServices.listarMeusFilmes().subscribe((res:any) => {this.Filmes=res;console.log(res)})
  }
}
