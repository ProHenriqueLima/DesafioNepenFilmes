import { Component } from '@angular/core';
import { TmdbService } from '../../services/TMDB/tmdb.component.service';
import { MatGridListModule } from '@angular/material/grid-list';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { VisualizarFilmeComponent } from './escolher-filme/visualizar-filme.component';
import { FilmeService } from '../../services/Filmes/filmes.component.service';


@Component({
  selector: 'app-filmes',
  standalone:true,
  imports: [MatGridListModule,MatIconModule,CommonModule,MatButtonModule,VisualizarFilmeComponent],
  templateUrl: './filmes.component.html',
  styleUrl: './filmes.component.css',
  providers: [TmdbService,FilmeService]
})
export class FilmesComponent {
  constructor(private TmdbService: TmdbService,private FilmeService: FilmeService) {}
  FilmesMaisRentaveis :any;
  PaginaExibicaoMaisRentaveis = [0,5];
  MinhaBibliotecaDeFilme : any = [];
  VisualizarFilme = false;
  FilmeSelecionado:any;
  TipoFilmeSelecionado:any;
  ngOnInit() {
    this.TmdbService.listarFilmesMaisRentaveis().subscribe((res:any) => {this.FilmesMaisRentaveis=res.results;console.log(this.FilmesMaisRentaveis)})
    this.FilmeService.listarMeusFilmes().subscribe((res:any) => {this.MinhaBibliotecaDeFilme=res;console.log(res)})
  }
  visualizarFilme(item:any,tipo:any){
    this.FilmeSelecionado = item;
    this.TipoFilmeSelecionado = tipo;
    this.VisualizarFilme = true;

  }
  voltarHome(){
    this.VisualizarFilme = false;
  }
} 
