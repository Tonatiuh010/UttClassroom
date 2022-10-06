import { Component, OnInit, Input } from '@angular/core';
import { C } from 'src/constants/C';
import { Student } from 'src/interfaces/catalog/student';

@Component({
  selector: 'app-card-box',
  templateUrl: './card-box.component.html',
})
export class CardBoxComponent implements OnInit {
  @Input()
  student : Student | undefined;
  imgStudent : string = C.API_URL + 'student/image/';
  constructor() { }

  ngOnInit(): void {
    this.imgStudent += this.student?.id.toString();
  }

}
