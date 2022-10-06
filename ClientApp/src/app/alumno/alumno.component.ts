import * as H from 'highcharts';
import { Component, Input } from '@angular/core';
import { Asset } from "src/interfaces/catalog/asset";
import { AssetService } from '../services/assetFull.service';
import { FullCatalog } from "src/interfaces/catalog/full.catalog";
import { Student } from 'src/interfaces/catalog/student';
import { StudentService } from '../services/student.service';
import { C } from 'src/constants/C';
import { ActivatedRoute, Router } from '@angular/router';
import { Eng, Grades, Tsu } from 'src/interfaces/catalog/grades';
import { ChartFactory as cFact } from 'src/classes/chart.factory';
import { Chart } from 'angular-highcharts';

@Component({
  selector: 'app-alumno',
  templateUrl: './alumno.component.html',
})
export class AlumnoComponent {
  student : Student | undefined;
  asset: Asset[] | undefined;
  imgStudent : string = '';
  gradesChart : Chart | undefined;
  constructor(
    private studentService : StudentService,
    private assetService : AssetService,
    private _Activatedroute:ActivatedRoute,
    private _router:Router,
  ) {}

  ngOnInit() {

    this._Activatedroute.paramMap.subscribe(params => {
      let id = +(params.get('id') as string);
      this.studentService.getStudent( id , student => {
        this.student = student;
        this.imgStudent = C.API_URL + 'student/image/' + id.toString();
        this.setGrades(this.student.stats as Grades);
      });
    });

    this.assetService.getAssets(asset => {
      this.asset = asset;
    });
  }

  setGrades(grades: Grades) {

    let tsu : Tsu = grades.tsu;
    let eng : Eng = grades.eng;

    let options : H.Options = cFact.instance(
      'line',
      'Calificaciones',
      [
        {
          type: 'line',
          name: "Promedios",
          selected: false,
          lineWidth: 0,
          enableMouseTracking: false,
          marker: {
            // fillColor: '#FFFFFF',
            // lineWidth: 2,
            // lineColor: undefined,
            radius: 6
          },
          dataLabels: {
            enabled: true,
            y: -20,
            shape: 'callout',
            backgroundColor: 'rgba(0, 0, 0, 0.75)',
            borderColor: '#dee2e6',
            //borderWidth: 1,
            shadow: true,
            style: {
              color: 'white',
              fontWeight: 'bold',
              fontSize: '10pt'
            }
          },
          data:  [
            ...tsu.tsuGrades.map( (x, i) => ([`Q${i + 1}`, +x.toFixed(2)]) ),
            ...eng.engGrades.map( (x, i) => ([`Q${i + 7}`,  +x.toFixed(2)]) )
          ]
        }
      ],
      {
        categories: [1, 2, 3, 4, 5, 6, 7, 8].map(x => `Q${x}`),
        title: {
          text: 'Quatrimestres'
        }
      },
      {
        title: {
          text: 'Promedios'
        },
        max: 10,
      }
    )

    this.gradesChart = new Chart(options);

  }

}
