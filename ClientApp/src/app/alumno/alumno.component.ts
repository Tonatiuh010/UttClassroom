import { Component } from '@angular/core';
import { Asset } from "src/interfaces/catalog/asset";
import { AssetService } from '../services/assetFull.service';
import { FullCatalog } from "src/interfaces/catalog/full.catalog";
import { Student } from 'src/interfaces/catalog/student';
import { StudentService } from '../services/student.service';

@Component({
  selector: 'app-alumno',
  templateUrl: './alumno.component.html',
})
export class AlumnoComponent {

  student : Student | null = null;
  asset: Asset | null = null;
  constructor(
    private studentService : StudentService,
    private assetService : AssetService) {

  }
  ngOnInit() {
    this.studentService.getStudent(1, student => this.student = student);
    this.assetService.getAsset(1, asset => this.asset = asset);
    //this.assetService.getAsset(asset => this.asset = asset);
  }

}
