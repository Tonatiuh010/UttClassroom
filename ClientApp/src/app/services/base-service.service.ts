import { Injectable, Type } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { HtmlParser } from '@angular/compiler';

// @Injectable({
//   providedIn: 'root'
// })
export class BaseService {
  url : string;
  constructor(url : string, private http: HttpClient ) {
    this.url = url;
  }

  public getData<Type>(urlExtension: string = '') : Observable<Type> {
    return this.fetchBlock(() => this.http.get<Type>(this.url + urlExtension));
  }

  private fetchBlock<Type>(callback: () => Observable<Type>) : Observable<Type> {
    try {
      return callback();
    } catch {
      throw 'Error on callback';
    }
  }
}
