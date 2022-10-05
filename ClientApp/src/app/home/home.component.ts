import { Component } from '@angular/core';
import { Chart } from 'angular-highcharts';
import { Group } from 'src/interfaces/catalog/group';
import { GroupService } from '../services/group.service';
import { Asset } from "src/interfaces/catalog/asset";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  chart : Chart | undefined;
  group : Group | null = null;
  constructor(private groupService : GroupService){
  }
//REMPLAZAR POR ESTUDIANTE
  ngOnInit() {
    this.groupService.getGroup(1, group => this.group = group);
    this.init();
  }

  init() {
    let chart = new Chart({
      chart: {
        type: 'line'
      },
      title: {
        text: 'Linechart'
      },
      credits: {
        enabled: false
      },
      series: [{
        name: 'Line 1',
        type: 'line',
        data: [1, 2, 3]
      }]
    });
    this.chart = chart;
  }

}
