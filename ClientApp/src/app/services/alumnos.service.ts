import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { BaseService as service } from './base-service.service';
import { C } from '../../constants/C';

@Injectable({
  providedIn: 'root'
})
export class AlumnosService {
  private service : service

  constructor(private http : HttpClient) {
    this.service = new service(C.API_URL, http);
  }

  public getAllAlumnos(): Observable<any>{
    return this.service.getData();
  }
}
