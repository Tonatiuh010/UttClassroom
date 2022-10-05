import { Component, Input, OnInit } from '@angular/core';
import { Chart } from 'angular-highcharts';

@Component({
  selector: 'app-chart-custom',
  templateUrl: './chart.custom.component.html',
})
export class ChartCustomComponent implements OnInit {
  @Input()
  chart : Chart | undefined;

  constructor() {
  }

  ngOnInit(): void {
  }

  initChart(chart: Chart) {
    this.disposeChart();
    this.chart = chart;
  }

  disposeChart() {
    if (this.chart) {
      this.chart.destroy();
    }
  }

}
