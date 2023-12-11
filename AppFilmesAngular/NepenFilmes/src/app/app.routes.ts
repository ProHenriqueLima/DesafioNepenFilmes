import { Routes } from '@angular/router';
import { FilmesComponent } from './components/filmes/filmes.component';
import { FilmesIMDBComponent } from './components/filmes-imdb/filmes-imdb.component';

export const routes: Routes = [
    { path: '', component: FilmesComponent }
    ,
    { path: 'FilmesIMDB', component: FilmesIMDBComponent }
];
