import { Component, OnInit } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {

  public movies: Movie[];
  
  public GET_ALL_URL: string = 'https://localhost:44341/api/movies';

  constructor(private http: HttpClient) { }

  /* Get list of tasks from the server */
  getMovie(): void {
    this.http.get<Movie[]>(this.GET_ALL_URL)
      .subscribe(movie => this.movies = movie);
  }

  ngOnInit() {
    this.getMovie();
  }
}

interface Movie {
  title: string,
  description: string,
  gender: string,
  duration: string,
  release: Date,
  director: string,
  added: Date,
  rating: string,
  watched: boolean,
  comments: any[]
}
