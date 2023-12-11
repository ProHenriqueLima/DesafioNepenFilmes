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
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone:true,
  imports: [CommonModule,MatCardModule,MatButtonModule,MatFormFieldModule,MatInputModule,MatIconModule,HttpClientModule,FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  providers: [LoginService]
})
export class LoginComponent {
  constructor(private loginService: LoginService,private _snackBar: MatSnackBar,private router: Router) {}

  @Output() inicializarApp = new EventEmitter();
  cadastroOuLogin = "Login";
  hidePassword = true;
  error="";
  Username : any;
  Senha : any;
  Nome : any;

  ngOnInit() {
    
    
  }

  // Método para efetuar o login do usuário
  efetuarLogin() {
    if (this.verificarSenhaUsername(this.Username, this.Senha)) {
      // Construção do objeto de usuário
      var user = {
        id: 0,
        username: this.Username,
        nome: "padrao", 
        password: this.Senha,
        ativo: 1,
        cargo: "padrao"
      };

      // Chamada do serviço para efetuar o login
      this.loginService.efetuarLogin(user).subscribe(
        (res) => {
          // Lógica de sucesso no login
          if (res.token != null && res.token != "") {
            // Armazenamento do token e nome do usuário no armazenamento local
            localStorage.setItem("Token", res.token);
            localStorage.setItem("UsuarioNome", res.adm.nome);
            // Emissão do evento para inicializar o aplicativo
            this.inicializarApp.emit();
            // Exibição de uma notificação de sucesso
            this._snackBar.open("Conectado com sucesso", "fechar");
            // Verificação do login após o sucesso
            this.loginService.verificarLogin().subscribe((res: any) => {
              console.log(res);
            });
          }
        },
        (error) => {
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

  // Método para efetuar o cadastro do usuário
  efetuarCadastro() {
    if (this.verificarSenhaUsernameNome(this.Username, this.Senha, this.Nome)) {
      // Construção do objeto de usuário para cadastro
      var user = {
        id: 0,
        username: this.Username,
        nome: this.Nome,
        password: this.Senha,
        ativo: 1,
        cargo: "usuario" // Está fixo como "usuario", talvez precise ser ajustado
      };

      // Chamada do serviço para efetuar o cadastro
      this.loginService.efetuarCadastro(user).subscribe(
        (res) => {
          // Lógica de sucesso no cadastro
          console.log(res);
          if (res.message == 'Usuário cadastrado com sucesso !') {
            // Exibição de uma notificação de sucesso
            this._snackBar.open("Cadastrado com sucesso, efetue o login.", "fechar");
            this.cadastroOuLogin = "Login";
          } else {
            console.log(res.errors)
            // Exibição da mensagem de erro em um snackbar
            this._snackBar.open("Erro no cadastro. Verifique os dados e tente novamente.", "fechar");
          }
        },
        (error) => {
          // Lógica de tratamento de erro no cadastro
          console.error("Erro no cadastro:", error);
      
          let errorMessage = error.error.error;
          if(errorMessage == null){
            errorMessage = "Erro no cadastro. Verifique os dados e tente novamente.";
          }
      
          if (error && error.errors && error.errors.Nome) {
            errorMessage = error.errors.Nome;
          }
      
          // Exibição da mensagem de erro em um snackbar
          this._snackBar.open(errorMessage, "fechar");
        }
      );
    }
  }

  // Método para verificar se o nome de usuário e a senha são válidos
  verificarSenhaUsername(Username: string, Senha: string): boolean {
    if (Username == null || Username == "" || Senha == null || Senha == "") {
      // Exibição de uma mensagem de erro se os campos estiverem vazios
      this._snackBar.open("Os campos não podem ficar vazios", "fechar");
      return false;
    }
    return true;
  }

  // Método para verificar se o nome de usuário, a senha e o nome são válidos
  verificarSenhaUsernameNome(Username: string, Senha: string, Nome: string): boolean {
    if (Username == null || Username == "" || Senha == null || Senha == "" || Nome == null || Nome == "") {
      // Exibição de uma mensagem de erro se os campos estiverem vazios
      this._snackBar.open("Os campos não podem ficar vazios", "fechar");
      return false;
    }
    if(Nome.length <= 3){
      this._snackBar.open("O campo Nome precisa ter mais de 3 caracteres", "fechar");
      return false;
    }
    if(Username.length <= 3){
      this._snackBar.open("O campo Username precisa ter mais de 3 caracteres", "fechar");
      return false;
    }
    if(Senha.length <= 3){
      this._snackBar.open("O campo Senha precisa ter mais de 3 caracteres", "fechar");
      return false;
    }
    return true;
  }
}