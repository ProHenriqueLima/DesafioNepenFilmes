import { Component, EventEmitter, Input, Output } from '@angular/core';
import {MatCardModule} from '@angular/material/card';
import {MatSnackBar} from '@angular/material/snack-bar';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { LoginService } from '../../app.component.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule,MatCardModule,MatButtonModule,MatFormFieldModule,MatInputModule,MatIconModule,HttpClientModule,FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  providers: [LoginService]
})
export class LoginComponent {
  constructor(private loginService: LoginService,private _snackBar: MatSnackBar) {}

  @Output() inicializarApp = new EventEmitter();
  cadastroOuLogin = "Login";
  hidePassword = true;
  error="";
  Username : any;
  Senha : any;
  Nome : any;

  ngOnInit() {
    
    
  }

  efetuarLogin(){
    if(this.verificarSenhaUsername(this.Username,this.Senha) == true){
      var user = {
        id: 0,
        username: this.Username,
        nome: "string",
        password: this.Senha,
        ativo: 1,
        cargo: "string"
      };
      this.loginService.efetuarLogin(user).subscribe((res) => {
        if(res.token != null && res.token != ""){
          localStorage.setItem("Token",res.token);
          localStorage.setItem("UsuarioNome",res.adm.nome);
          this.inicializarApp.emit();
          this._snackBar.open("Conectado com sucesso", "fechar");
          this.loginService.verificarLogin().subscribe((res:any)=> {console.log(res)});
        }
      },
      (error)=>{
        error = error.error;
        if(error.error){
          this._snackBar.open(error.error, "fechar");
        }
      });
    } 
  }

  efetuarCadastro(){
    if(this.verificarSenhaUsernameNome(this.Username,this.Senha,this.Nome) == true ){
      var user = {
        id: 0,
        username: this.Username,
        nome: this.Nome,
        password: this.Senha,
        ativo: 1,
        cargo: "usuario"
      };
      this.loginService.efetuarCadastro(user).subscribe((res) => {
        console.log(res);
        if(res.token != null && res.token != ""){
          this._snackBar.open("Cadastrado com sucesso, efetue o login.", "fechar");
        }
      },
      (error)=>{
        error = error.error;
        if(error.error){
          this._snackBar.open(error.error, "fechar");
        }
      });
    } 
  }

  verificarSenhaUsername(Username:string,Senha:string) : boolean{
    if(Username == null || Username == "" || Senha == null || Senha == ""){
      this._snackBar.open("Os campos não podem ficar vazios", "fechar");
      return false;
    }
    return true;

  }
  
  verificarSenhaUsernameNome(Username:string,Senha:string,Nome:string) : boolean{
    if(Username == null || Username == "" || Senha == null || Senha == "" || Nome == null || Nome == ""){
      this._snackBar.open("Os campos não podem ficar vazios", "fechar");
      return false;
    }
    return true;

  }

}
