import { Component, OnInit, Input } from '@angular/core';
import { Student } from 'src/interfaces/catalog/student';

@Component({
  selector: 'app-card-box',
  templateUrl: './card-box.component.html',
  styleUrls: ['./card-box.component.css']
})
export class CardBoxComponent implements OnInit {
  @Input()
  student : Student | undefined;
  constructor() { }

  ngOnInit(): void {
    this.student
  }

}
