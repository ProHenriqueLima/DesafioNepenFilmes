import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
providedIn: 'root',
})
export class TmdbService {
    constructor(private http: HttpClient) {}
    urlFilmes = "https://api.themoviedb.org/3/movie/";
    key = "?api_key=a7cc1f147de242650c5fd7ff7405c5de";


    listarFilmesMaisRentaveis(){
        const url = this.urlFilmes+"top_rated"+this.key;  
        return this.http.get(url);
    }
}