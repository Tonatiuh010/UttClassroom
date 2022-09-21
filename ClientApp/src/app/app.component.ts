import { Component, OnInit } from '@angular/core';
import { AlumnosService } from './services/alumnos.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit{

  alumnos: any = {};
  constructor(private service: AlumnosService){
  }

  ngOnInit(): void{
    this.service.getAllAlumnos().subscribe(resp => {
      this.alumnos = resp.results;
      console.log(this.alumnos); 
    });
  }

}
