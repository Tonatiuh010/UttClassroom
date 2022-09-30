import { Injectable, Type } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { HtmlParser } from '@angular/compiler';
import { dataBody } from 'src/interfaces/catalog/dataBody';
import { C } from 'src/constants/C';

export class BaseService {
  url : string;
  constructor(url : string, private http: HttpClient ) {
    this.url = url;
  }

  public getDataBody(urlExtension: string = '', cb: (d: dataBody) => void) {
    // let result : dataBody = {
    //   data : null,
    //   message: 'COMPLETE',
    //   status : 'OK'
    // };

    try {
      let obs = this.http.get<dataBody>(this.url + urlExtension);

      this.responseBlock(
        obs,
        cb,
        () => {
          throw 'Error reading response.';
        }
      );

      //return result;
    } catch {
      throw 'Exception getting data body.';
    }
  }

  public getData<Type>(urlExtension: string = '') : Observable<Type> {
    return this.fetchBlock(() => this.http.get<Type>(this.url + urlExtension));
  }

  private fetchBlock<Type>(callback: () => Observable<Type>) : Observable<Type> {
    try {
      return callback();
    } catch {
      throw 'Error on callback.';
    }
  }

  private responseBlock(response: Observable<dataBody>, onComplete: (d: dataBody) => void, onError: (err: any) => void) {
    let ref = this;

    response.subscribe({
      next(d: dataBody) {

        if(ref.isValidResponse(d))
          onComplete(d);
        else
          onError('Error from request');
      },
      error(err) {
        onError(err);
      },
    });

  }

  public isValidResponse(data: dataBody) : boolean {
    return data.status == C.keyword.OK && data.message == C.keyword.COMPLETE;
  }

}
