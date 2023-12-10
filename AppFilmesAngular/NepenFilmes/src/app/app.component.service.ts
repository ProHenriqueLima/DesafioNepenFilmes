import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable({
providedIn: 'root',
})
export class LoginService {
private apiUrl = 'https://localhost:7257/';

constructor(private http: HttpClient) {}
  efetuarLogin(objeto:any): Observable<any> {
    const url = this.apiUrl+"Usuario/Login";  
    return this.http.post(url,objeto);
  }

  efetuarCadastro(objeto:any): Observable<any> {
    const url = this.apiUrl+"Usuario/CadastrarUsuario";
    return this.http.post(url,objeto);
  }

  verificarLogin(): any {
    const url = this.apiUrl+"Usuario/Autenticado";
    const headers = new HttpHeaders().set('Authorization', `Bearer ${localStorage.getItem("Token")}`);
    return this.http.get(url,{ headers }).pipe(
      catchError((error) => {
        return throwError('Erro ao verificar o login.');
      })
    );
  }
}