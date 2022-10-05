import { Component } from '@angular/core';
import { Group } from "src/interfaces/catalog/group";
import { GroupService } from '../services/group.service';

@Component({
  selector: 'app-card-box',
  templateUrl: './card-box.component.html',
  styleUrls: ['./card-box.component.css']
})
export class CardBoxComponent {

  group : Group | null = null;
  constructor(private groupService : GroupService){
  }

  ngOnInit() {
    this.groupService.getGroup(1, group => this.group = group);
    console.log(this.groupService);
  }

}
