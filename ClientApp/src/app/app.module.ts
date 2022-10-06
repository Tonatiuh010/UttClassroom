import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CarouselComponent } from './components/carousel/carousel.component';
import { HeaderComponent } from './components/header/header.component';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetch-data/fetch-data.component';
import { CardBoxComponent } from './components/card-box/card-box.component';
import { AlumnoComponent } from "./components/alumno/alumno.component";
import { ChartModule } from 'angular-highcharts';
import { ChartFactory } from 'src/classes/chart.factory';

@NgModule({
  declarations: [
    CarouselComponent,
    HeaderComponent,
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent,
    CardBoxComponent,
    AlumnoComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ChartModule,
    RouterModule.forRoot([
      { path: 'group', component: HomeComponent, pathMatch: 'full' },
      { path: 'alumno/:id', component: AlumnoComponent },
      { path: "**", redirectTo: '/group'}
      // { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor() {
    ChartFactory.setGlobalOptions();
  }

}
