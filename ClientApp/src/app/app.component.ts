import { Component, OnInit } from '@angular/core';
import { AlumnosService as serv } from './services/alumnos.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  constructor(private s : serv) {
    let x = s.getAllAlumnos();
    x.forEach(l => console.log(l))
    x.subscribe(str => console.log(str));
  }
}
