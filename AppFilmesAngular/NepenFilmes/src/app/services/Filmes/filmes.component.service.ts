import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable({
providedIn: 'root',
})
export class FilmeService {
private apiUrl = 'https://localhost:7257/';

constructor(private http: HttpClient) {}    
  listarMeusFilmes(): any {
    const url = this.apiUrl+"Filme";
    const headers = new HttpHeaders().set('Authorization', `Bearer ${localStorage.getItem("Token")}`);
    return this.http.get(url,{headers});
  }
  adicionarFilme(Filme:any): any {
    const url = this.apiUrl+"Filme";
    const headers = new HttpHeaders().set('Authorization', `Bearer ${localStorage.getItem("Token")}`);
    return this.http.post(url,Filme,{headers});
  }

  atualizarFilme(Filme:any): any {
    const url = this.apiUrl+"Filme";
    const headers = new HttpHeaders().set('Authorization', `Bearer ${localStorage.getItem("Token")}`);
    return this.http.put(url,Filme,{headers});
  }
}