import { Component, OnInit } from '@angular/core';
import { toDo } from '../toDo';
import { ToDoService } from '../shared/services/todo.service'

@Component({
  selector: 'app-todos',
  templateUrl: './todos.component.html',
  styleUrls: ['./todos.component.css'],
  providers: [ToDoService]
})
export class TodosComponent implements OnInit {
  toDos: Array<any>;

  constructor(private toDoService: ToDoService) { }

  ngOnInit() {
    console.log("Loading List...");
    this.toDoService
    .getAll()
    .subscribe(
      data => {
            this.toDos = data;
     },
     error => console.log(error)
    )
  }

}
