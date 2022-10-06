import { Chart } from "angular-highcharts";
import * as H from 'highcharts';

export class ChartFactory {

  static instance = (
    type: string,
    title: string,
    series: H.SeriesOptionsType[],
    xAxis: H.XAxisOptions | undefined = undefined,
    yAxis: H.YAxisOptions | undefined = undefined,
  ) : H.Options  => new ChartFactory(type, title, series, xAxis, yAxis).options as H.Options;

  static instanceBasic = (
    type: string,
    title: string,
    series: H.SeriesOptionsType[]
  ) : H.Options => new ChartFactory(type, title, series).options as H.Options;

  chart : Chart | null = null;
  options : H.Options | null = null;

  private constructor(
    type: string,
    title: string,
    series: H.SeriesOptionsType[],
    xAxis: H.XAxisOptions | undefined = undefined,
    yAxis: H.YAxisOptions | undefined = undefined,
    options: H.Options | null = null,
    chart: Chart | null = null
  ) {

    if (chart != null) {
      this.chart = chart;
    } else if (options != null) {
      this.options = options;
      this.chart = new Chart(options);
    } else {
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
        text: `<div class='text-lg text-center p-2 bg-gray-100 border rounded w-full'> ${props.title} </div>` ,
        useHTML: true,
        style: {
          width: 100,
        }
      },
      series: props.series,
      plotOptions: {
        pie: {
          allowPointSelect: true,
          cursor: 'pointer',
          dataLabels: {
            enabled: true,
            format: '<b>{point.name}</b>: {point.percentage:.2f}%'
          },
          showInLegend: true
        },
        column: {
          allowPointSelect: true,
          cursor: 'pointer',
          dataLabels: {
            enabled: true,
            format: '{point.y}'
          },
          showInLegend: true

        }
      },
    };

    if (props.xAxis ) {
      option.xAxis = props.xAxis;
    }

    if (props.yAxis) {
      option.yAxis = props.yAxis;
    }

    this.options = option;
    this.chart = new Chart(option);
  }

  static setGlobalOptions() {
    H.setOptions({
      "colors": [
        "#E10033",
        "#000000",
        "#767676",
        "#E4E4E4"
      ],
      "chart": {
        "backgroundColor": "#FFFFFF",
        "style": {
          "fontFamily": `ui-sans-serif, system-ui, -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, "Noto Sans", sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji"`,
          "color": "#000000"
        },
        "plotBorderColor": '#dee2e6',
        "plotBorderWidth": 1,
      },
      "title": {
        "align": "center",
        "style": {
          "fontFamily": `ui-sans-serif, system-ui, -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, "Noto Sans", sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji"`,
          "color": "#000000",
          "fontWeight": "bold"
        }
      },
      "subtitle": {
        "align": "center",
        "style": {
          "fontFamily": `ui-sans-serif, system-ui, -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, "Noto Sans", sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji"`,
          "color": "#000000",
          "fontWeight": "bold"
        }
      },
      "xAxis": {
        "lineColor": "#000000",
        "lineWidth": 2,
        "tickColor": "#000000",
        "tickWidth": 2,
        "labels": {
          "style": {
            "color": "black"
          }
        },
        "title": {
          "style": {
            "color": "black"
          }
        }
      },
      "yAxis": {
        "opposite": true,
        "gridLineWidth": 2,
        "gridLineColor": "#F3F3F3",
        "lineColor": "#CEC6B9",
        "minorGridLineColor": "#CEC6B9",
        "labels": {
          "align": "center",
          "style": {
            "color": "black"
          },
          // "x": 0,
          // "y": -2
        },
        "tickLength": 0,
        "tickColor": "#CEC6B9",
        "tickWidth": 1,
        "title": {
          "style": {
            "color": "black"
          }
        }
      },
      "tooltip": {
        "backgroundColor": "#FFFFFF",
        "borderColor": "#76c0c1",
        "style": {
          "color": "#000000"
        }
      },
      "legend": {
        "layout": "horizontal",
        "align": "left",
        "verticalAlign": "top",
        "itemStyle": {
          "color": "#3C3C3C"
        },
        "itemHiddenStyle": {
          "color": "#606063"
        }
      },
      "credits": {
        "style": {
          "color": "#666"
        }
      },
      "drilldown": {
        "activeAxisLabelStyle": {
          "color": "#F0F0F3"
        },
        "activeDataLabelStyle": {
          "color": "#F0F0F3"
        }
      },
      "navigation": {
        "buttonOptions": {
          "theme": {
            "fill": "#505053"
          }
        }
      },
    });
  }

}

export interface customHC {
  type: string;
  title: string;
  xAxis? : H.XAxisOptions;
  yAxis?: H.YAxisOptions;
  series: H.SeriesOptionsType[];
}
