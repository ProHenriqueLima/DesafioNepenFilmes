import { Component } from '@angular/core';
import { TmdbService } from '../../services/TMDB/tmdb.component.service';
import { HttpClient } from '@angular/common/http';
import { MatGridListModule } from '@angular/material/grid-list';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-filmes',
  standalone: true,
  imports: [MatGridListModule,CommonModule,MatButtonModule],
  templateUrl: './filmes.component.html',
  styleUrl: './filmes.component.css',
  providers: [TmdbService]
})
export class FilmesComponent {
  constructor(private TmdbService: TmdbService) {}
  FilmesMaisRentaveis :any;
  PaginaExibicaoMaisRentaveis = [0,5];
  MinhaBibliotecaDeFilme : any;
  ngOnInit() {
    this.TmdbService.listarFilmesMaisRentaveis().subscribe((res:any) => {this.FilmesMaisRentaveis=res.results;console.log(this.FilmesMaisRentaveis)})
  }
} 
