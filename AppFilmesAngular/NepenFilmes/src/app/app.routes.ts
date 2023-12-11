import { Routes } from '@angular/router';
import { FilmesComponent } from './components/filmes/filmes.component';
import { FilmesIMDBComponent } from './components/filmes-imdb/filmes-imdb.component';
import { MeusFilmesComponent } from './components/meus-filmes/meus-filmes.component';
import { FilmesBibliotecaComponent } from './components/filmes-biblioteca/filmes-biblioteca.component';

export const routes: Routes = [
    { path: '', component: FilmesComponent }
    ,
    { path: 'FilmesIMDB', component: FilmesIMDBComponent }
    ,
    { path: 'AdicionarFilme', component: MeusFilmesComponent },
    { path: 'MeusFilmes', component: FilmesBibliotecaComponent }

];
