import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { CarouselComponent } from './carousel/carousel.component';
import { HeaderComponent } from './header/header.component';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CardBoxComponent } from './card-box/card-box.component';
import { AlumnoComponent } from "./alumno/alumno.component";

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
    RouterModule.forRoot([
      { path: 'calificaciones', component: HomeComponent, pathMatch: 'full' },
      { path: 'alumno', component: AlumnoComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
