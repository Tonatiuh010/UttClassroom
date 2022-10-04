import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { BaseService as service } from './base.service';
import { C } from '../../constants/C';
import { Student } from 'src/interfaces/catalog/student';
import { dataBody } from 'src/interfaces/catalog/dataBody';
import { Group } from 'src/interfaces/catalog/group';

@Injectable({
  providedIn: 'root'
})
export class GroupService {
  private service : service;
  private urlExtension : string = "group";

  constructor(private http : HttpClient) {
    this.service = new service(C.API_URL, http);
  }

  public getGroups(cb: (d: Group[]) => void) {
    this.service.getDataBody(
      this.urlExtension,
      res => cb(res.data as Group[])
    );
  }

  public getGroup( id: number, cb: (d: Group) => void ) {
    this.service.getDataBody(
      this.concatUrl(id.toString()),
      res => cb(res.data as Group)
    );
  }

  public getGroupStudent(studentId: number, cb: (d: Group) => void) {
    this.service.getDataBody(
      this.concatUrl("student/" + studentId),
      res => cb(res.data as Group)
    );
  }

  private concatUrl(ext: string) : string {
    return this.urlExtension + "/" + ext;
  }

}
