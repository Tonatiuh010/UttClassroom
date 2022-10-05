import { Chart } from "angular-highcharts";
import * as H from 'highcharts';

export class ChartFactory {

  chart : Chart | null = null;

  private constructor(
    type: string,
    title: string,
    xAxis: H.XAxisOptions,
    yAxis: H.YAxisOptions,
    series: H.SeriesOptionsType[],
    options: H.Options | null = null,
    chart: Chart | null = null
  ) {

    if (chart != null)
      this.chart = chart;
    else if (options != null)
      this.chart = new Chart(options);
    else {
      this.setProps({
        type: type,
        series: series,
        title: title,
        xAxis: xAxis,
        yAxis: yAxis
      });
    }

  }

  setProps(props: customHC) {
    let option : H.Options = {
      chart: {
        type: props.type
      },
      title: {
        text: props.title
      },
      xAxis: props.xAxis,
      yAxis: props.yAxis,
      series: props.series
    };

    this.chart = new Chart(option);
  }

}

interface customHC {
  type: string;
  title: string;
  xAxis : H.XAxisOptions;
  yAxis: H.YAxisOptions;
  series: H.SeriesOptionsType[];
}
