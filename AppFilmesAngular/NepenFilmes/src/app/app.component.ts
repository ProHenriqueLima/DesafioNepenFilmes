import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatGridListModule} from '@angular/material/grid-list';
import { LoginComponent } from './components/login/login.component';
import { HttpClientModule } from '@angular/common/http';
import {
  MatDialogContent,
} from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { LoginService } from './app.component.service';


@Component({
  selector: 'app-root',
  imports: [CommonModule,MatGridListModule,MatDialogContent, RouterOutlet,HttpClientModule,MatButtonModule,MatToolbarModule, MatIconModule,LoginComponent, HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers: [LoginService] 
})
export class AppComponent {
  constructor(private _snackBar: MatSnackBar,private loginService: LoginService) {  }
  title = 'NepenFilmes';
  situacaoLogin = "";
  nomeUsuario : any;
  cadastroOuLogin= "Login";
  resultadoAutenticacao: any;

  ngOnInit() {
    this.loginService.verificarLogin().subscribe(
      (res:any) => {
        // Lógica de sucesso
        this.resultadoAutenticacao = res;
        this.nomeUsuario = localStorage.getItem("UsuarioNome");
        this.situacaoLogin= "Logado";
      },
      (error:any) => {
        this.situacaoLogin= "Deslogado";
      }
    )
    
  }

  eftuarLogout(){
    localStorage.removeItem("Token");
    localStorage.removeItem("UsuarioNome");
    this.ngOnInit();
    this._snackBar.open("Usuario Deslogado", "fechar");


  }
}
