import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { VisualizarFilmeComponent } from '../../filmes/escolher-filme/visualizar-filme.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { FilmeService } from '../../../services/Filmes/filmes.component.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

@Component({
  selector: 'app-filmes-biblioteca-visualizar',
  standalone: true,
  imports: [CommonModule,VisualizarFilmeComponent,MatFormFieldModule,MatInputModule,FormsModule,MatButtonModule],
  templateUrl: './filmes-biblioteca-visualizar.component.html',
  styleUrl: './filmes-biblioteca-visualizar.component.css',
  providers:[FilmeService]
})
export class FilmesBibliotecaVisualizarComponent {
  constructor(private filmeService: FilmeService,private _snackBar: MatSnackBar,private router: Router){};
  @Input() Filme:any;
  @Input() visualizar:any;
  editarFlag:boolean = false;
  NomeDoFilme:any;
  Descricao:any;
  Comentarios:any;

  ngOnInit(){
    this.NomeDoFilme = this.Filme.nome;
    this.Descricao = this.Filme.descricao;
    this.Comentarios = this.Filme.comentario;
  }

  atualizarFilme(){
    var filme = {
      id:this.Filme.id,
      nome:this.NomeDoFilme,
      descricao:this.Descricao,
      comentario:this.Comentarios,
      anoLancamento:this.Filme.anoLancamento,
      banner:this.Filme.banner,
      usernameCriador:"teste"
    }
    this.filmeService.atualizarFilme(filme).subscribe(
      (res: any) => {
        
        console.log(res)
        if(res.id != null && res.id != ""){
          this._snackBar.open("Filme atualizado com sucesso", "fechar");
          this.Filme = filme;
          this.editarFlag = false;
        }
      },
    );
  }
}
