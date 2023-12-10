import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { FilmesComponent } from './components/filmes/filmes.component';

export const routes: Routes = [
    { path: '', component: FilmesComponent }
    ,
    { path: '**', redirectTo: '' }
];
