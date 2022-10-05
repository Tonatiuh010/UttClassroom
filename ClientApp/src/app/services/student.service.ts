import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { BaseService as service } from './base.service';
import { C } from '../../constants/C';
import { Student } from 'src/interfaces/catalog/student';
import { dataBody } from 'src/interfaces/catalog/dataBody';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private service : service;
  private urlExtension : string = "student";

  constructor(private http : HttpClient) {
    this.service = new service(C.API_URL, http);
  }

  public getStudents(cb: (d: Student[]) => void ) {
    this.service.getDataBody(
      this.urlExtension,
      res => cb(res.data as Student[])
    );
  }

  public getStudentsGroup(groupId: number, cb: (d: Student[] ) => void )  {
    this.service.getDataBody(
      this.concatUrl("group/" + groupId.toString()),
      res => res.data as Student[]
    );
  }

  public getStudent( id: number, cb:(d: Student) => void ) {
    this.service.getDataBody(
      this.concatUrl(id.toString()),
      res => cb(res.data as Student)
    );
  }

  private concatUrl(ext: string) : string {
    return this.urlExtension + "/" + ext;
  }

}
