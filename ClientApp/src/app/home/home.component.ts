import { Component } from '@angular/core';
import { Chart } from 'angular-highcharts';
import { Group } from 'src/interfaces/catalog/group';
import { GroupService } from '../services/group.service';
import { ChartFactory as cFact } from 'src/classes/chart.factory';
import { ItemDisjunction, ItemStat } from 'src/interfaces/catalog/item';
import { LaborData, PersonalInformation, ScholarlyData } from 'src/interfaces/catalog/group.stats';
import * as H from 'highcharts';
import { Eng, Grades, Tsu } from 'src/interfaces/catalog/grades';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  chart : Chart | undefined;
  gradesChart : Chart | undefined;
  group : Group | null = null;
  index: number = 0;
  private chartSets : H.Options[] | undefined;

  constructor(private groupService : GroupService){
  }

  ngOnInit() {
    this.groupService.getGroup(1, group => {
      this.group = group;
      this.init();
    });
  }

  init() {
    /* Labor Data */
    let laborData : LaborData = this.group?.stats?.labor_data as LaborData;
    let workStats : ItemDisjunction = laborData.work;
    let workReason : ItemStat[] = laborData.workReason;
    let isWorkStudy : ItemDisjunction = laborData.workStudy;

    /* Personal Information */
    let personalInfo : PersonalInformation = this.group?.stats?.personal_information as PersonalInformation;
    let familyIncome : ItemStat[] = personalInfo.family_income;
    let genre : ItemStat[] = personalInfo.genre;
    let marital: ItemStat[] = personalInfo.marital;
    let livesWith : ItemStat[] = personalInfo.lives_with;

    /* Scholarly Data */
    let scholarlyData : ScholarlyData = this.group?.stats?.scholarlyData as ScholarlyData;
    let scholarly : ItemStat[] = scholarlyData.scholarly;
    let scholarlyType : ItemStat[] = scholarlyData.scholarlyType;

    /* Grades */
    let grades : Grades = this.group?.grades as Grades;


    let chartsSets : H.Options[] = [
      cFact.instanceBasic(
        'pie',
        'Estudiantes Trabajando',
        [
          {
            type: 'pie',
            name: "Trabajan",
            data: [
              {name: "Si", y: workStats.yes },
              {name: "No", y:  workStats.no },
            ]
          }
        ]
      ),
      cFact.instance(
        'column',
        'Razón Trabaja',
        [
          {
            type: 'column',
            name: "Razón",
            colorByPoint: true,
            data: workReason.map( x => ({ name: x.Name, y: x.Value }) )
          }
        ],
        {
          type: 'category'
        },
        {
          title: {
            text: 'Alumnos'
          }
        },
      ),
      cFact.instance(
        'pie',
        'Trabajando Relacionado a Estudios',
        [
          {
            type: 'pie',
            name: "Relacionado",
            data: [
              {name: "Si", y: isWorkStudy.yes },
              {name: "No", y: isWorkStudy.no },
            ]
          }
        ]
      ),
      cFact.instance(
        'column',
        'Apoyo Economico',
        [
          {
            type: 'column',
            name: "Apoyo",
            colorByPoint: true,
            data: familyIncome.map( x => ({ name: x.Name, y: x.Value }) )
          }
        ],
        {
          type: 'category'
        },
        {
          title: {
            text: 'Alumnos'
          }
        },
      ),
      cFact.instance(
        'pie',
        'Género',
        [
          {
            type: 'pie',
            name: "Género",
            colorByPoint: true,
            data: genre.map( x => ({ name: x.Name, y: x.Value }) )
          }
        ],
      ),
      cFact.instance(
        'pie',
        'Estado Civil',
        [
          {
            type: 'pie',
            name: "Estado",
            colorByPoint: true,
            data: marital.map( x => ({ name: x.Name, y: x.Value }) )
          }
        ],
      ),
      cFact.instance(
        'column',
        'Vivienda',
        [
          {
            type: 'column',
            name: "Vive Con",
            colorByPoint: true,
            data: livesWith.map( x => ({ name: x.Name, y: x.Value }) )
          }
        ],
        {
          categories: livesWith.map( x => x.Name )
        }
      ),
      cFact.instance(
        'column',
        'Escuelas Egreso',
        [
          {
            type: 'column',
            name: "Escuela",
            colorByPoint: true,
            data: scholarly.map( x => ({ name: x.Name, y: x.Value }) )
          }
        ],
        {
          type: 'category'
        },
        {
          title: {
            text: 'Escuelas'
          }
        },
      ),
    ];

    this.chartSets = chartsSets;
    this.setGrades(grades);
    this.setChart(this.index);

  }

  next () {
    let temp: number = this.index + 1;

    if (this.chartSets) {
      if (temp > this.chartSets?.length - 1) {
        temp = 0;
      }

      this.index = temp;
      this.setChart(this.index)
    }

  }

  prev() {
    let temp: number = this.index - 1;

    if (this.chartSets) {
      if (temp < 0) {
        temp = this.chartSets.length - 1;
      }

      this.index = temp;
      this.setChart(this.index)
    }
  }

  setChart(i: number) {

    if(this.chart) {
      this.chart.destroy();
    }

    if (this.chartSets) {
      this.chart = new Chart(this.chartSets[ i ]);
    }
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
