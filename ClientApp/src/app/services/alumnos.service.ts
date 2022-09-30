import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AlumnosService {

  private API_ALUMNOS = "https://rickandmortyapi.com/api/character"

  constructor(private http: HttpClient) { }

  public getAllAlumnos(): Observable<any>{
    return this.http.get(this.API_ALUMNOS);
  }
}
