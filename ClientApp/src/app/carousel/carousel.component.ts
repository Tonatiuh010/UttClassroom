import { Component } from '@angular/core';
import { C } from 'src/constants/C';
import { Student } from 'src/interfaces/catalog/student';
import { StudentService } from '../services/student.service';

@Component({
  selector: 'carousel-component',
  templateUrl: './carousel.component.html'
})
export class CarouselComponent {
  apiImage: string = C.API_URL + 'student/image/';
  students: Student[] | undefined;

  constructor(private service : StudentService) {
  }

  ngOnInit() {
    this.service.getStudents(students => {
      this.students = students;
    })
  }
}
