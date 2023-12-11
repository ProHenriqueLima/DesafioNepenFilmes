import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
providedIn: 'root',
})
export class TmdbService {
    constructor(private http: HttpClient) {}
    urlFilmes = "https://api.themoviedb.org/3/movie/";
    urlSearch = "https://api.themoviedb.org/3/search/movie";
    key = "?api_key=a7cc1f147de242650c5fd7ff7405c5de";
    listarFilmesMaisRentaveis(){
        const url = this.urlFilmes+"top_rated"+this.key;  
        return this.http.get(url);
    }

    listarTodosOsFilmes(pesquisa:string){
        if(pesquisa == "" || pesquisa == undefined){
            return this.listarFilmesMaisRentaveis();
        }
        else{
            const url = this.urlSearch+this.key+"&query="+pesquisa;  
            return this.http.get(url);
        }
    }

    urlToBase64(url:any, callback:any) {
        // Use o fetch para obter a imagem a partir da URL
        fetch(url)
            .then(response => response.arrayBuffer())
            .then(buffer => {
                // Converte o ArrayBuffer para uma string base64
                const base64String = btoa(new Uint8Array(buffer).reduce((data, byte) => data + String.fromCharCode(byte), ''));
                // Chame o callback com a string base64
                callback(base64String);
            })
            .catch(error => console.error('Erro ao converter a imagem para base64:', error));
    }
    
    
    
}