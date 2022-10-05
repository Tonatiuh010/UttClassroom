import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { BaseService as service } from "./base.service";
import { HtmlParser } from "@angular/compiler";
import { Asset } from "src/interfaces/catalog/asset";
import { dataBody } from "src/interfaces/catalog/dataBody";
import { C } from "src/constants/C";
import { Group } from "src/interfaces/catalog/group";

@Injectable({
  providedIn: 'root'
})

export class AssetService {
  private service : service;
  private urlExtension : string = "catalog";

  constructor(private http : HttpClient) {
    this.service = new service(C.API_URL, http);
  }

  public getAssets(cb: (d: Asset[]) => void) {
    this.service.getDataBody(
      this.urlExtension,
      res => cb(res.data as Asset[])
    );
  }

  public getAsset(id: number, cb:(d: Asset) => void){
    this.service.getDataBody(
      this.concatUrl('asset/' + id.toString()),
      res => cb(res.data as Asset)
    )
  }

  public getAssetStudent(studentId: number, cb: (d: Asset) => void) {
    this.service.getDataBody(
      this.concatUrl("asset/" + studentId),
      res => cb(res.data as Asset)
    );
  }

  private concatUrl(ext: string) : string {
    return this.urlExtension + "/" + ext;
  }


}
