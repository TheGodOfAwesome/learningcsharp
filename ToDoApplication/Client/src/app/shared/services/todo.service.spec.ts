import { TestBed, inject } from '@angular/core/testing';
import { ToDoService } from './todo.service';
import { checkAndUpdateBinding } from '@angular/core/src/view/util';
import { TodolistComponent } from '../../todolist/todolist.component';
import { toDo } from '../../ToDo';

describe('TodoService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ToDoService]
    });
  });

  it('should be created', inject([ToDoService], (service: ToDoService) => {
    expect(service).toBeTruthy();
  }));
});
