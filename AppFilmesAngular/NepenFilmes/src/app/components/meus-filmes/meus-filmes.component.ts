import { Component, Input } from '@angular/core';
import { FilmeService } from '../../services/Filmes/filmes.component.service';
import { CommonModule } from '@angular/common';
import { VisualizarFilmeComponent } from '../filmes/escolher-filme/visualizar-filme.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

@Component({
  selector: 'app-meus-filmes',
  standalone: true,
  imports: [CommonModule,VisualizarFilmeComponent,MatFormFieldModule,MatInputModule,FormsModule,MatButtonModule ],
  templateUrl: './meus-filmes.component.html',
  styleUrl: './meus-filmes.component.css',
  providers: [FilmeService]
})
export class MeusFilmesComponent {
  constructor(private filmeService: FilmeService,private _snackBar: MatSnackBar,private router: Router) {}
  @Input() filmeSelecionado:any;
  NomeDoFilme:any;
  Descricao:any;
  Comentarios:any;
  ngOnInit() {
    this.NomeDoFilme = this.filmeSelecionado.title;
    this.Descricao = this.filmeSelecionado.overview;
    console.log(this.filmeSelecionado);
    
  }

  adicionarFilme(){
      var filme = {
        id:0,
        nome:this.NomeDoFilme,
        descricao:this.Descricao,
        comentario:this.Comentarios,
        anoLancamento:this.filmeSelecionado.release_date,
        banner:this.filmeSelecionado.poster_path,
        usernameCriador:""
      }
      this.filmeService.adicionarFilme(filme).subscribe(
        (res: any) => {
          if(res?.id != null){
            this.router.navigate(['/']);
          }
          console.log(res)
        },
        (error: { error: any; }) => {
          // Lógica de tratamento de erro no login
          
          error = error.error;
          if (error.error) {
            // Exibição da mensagem de erro em um snackbar
            this._snackBar.open(error.error, "fechar");
          }
        }
      );
  }
}
