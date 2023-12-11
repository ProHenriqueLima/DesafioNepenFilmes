import { Component } from '@angular/core';
import { TmdbService } from '../../services/TMDB/tmdb.component.service';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { VisualizarFilmeComponent } from '../filmes/escolher-filme/visualizar-filme.component';

@Component({
  selector: 'app-filmes-imdb',
  standalone:true,
  imports: [MatIconModule,CommonModule,FormsModule,VisualizarFilmeComponent,MatButtonModule,MatFormFieldModule,MatInputModule],
  templateUrl: './filmes-imdb.component.html',
  styleUrl: './filmes-imdb.component.css',
  providers: [TmdbService]
})
export class FilmesIMDBComponent {
  constructor(private TmdbService: TmdbService) {}
  Filmes:any;
  VisualizarFilme = false;
  FilmeSelecionado:any;
  TipoFilmeSelecionado:any;
  pesquisa:any;
  imagem64:any;
  
  ngOnInit() {
    // const imageUrl = 'https://image.tmdb.org/t/p/w500//8VG8fDNiy50H4FedGwdSVUPoaJe.jpg';
    // this.TmdbService.urlToBase64(imageUrl, (i: any)=>{
    //   this.imagem64 =i;
    // });
    // Chamada do serviço para listar todos os filmes
    this.TmdbService.listarTodosOsFilmes("").subscribe(
      (res: any) => {
        this.Filmes = res.results;
        console.log(this.Filmes);
      }
    );
  }

  // Método para pesquisar filmes com base em um termo
  pesquisarFilmes() {
    this.TmdbService.listarTodosOsFilmes(this.pesquisa).subscribe(
      (res: any) => {
        this.Filmes = res.results;
        console.log(this.pesquisa);
      }
    );
  }

  // Método para visualizar detalhes de um filme
  visualizarFilme(item: any, tipo: any) {
    this.FilmeSelecionado = item;
    this.TipoFilmeSelecionado = tipo;
    this.VisualizarFilme = true;
  }

  // Método para voltar à lista de filmes
  voltarHome() {
    this.VisualizarFilme = false;
  }
}