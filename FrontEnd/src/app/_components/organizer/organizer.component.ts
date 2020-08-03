import {Component, OnInit} from '@angular/core';
import {DateService} from '../../shared/date.service';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import { TasksService} from '../../shared/tasks.service';
import {switchMap} from 'rxjs/operators';
import {Observable} from "rxjs";
import {Task,Test2Service} from "../../shared/test2.service";
import {User} from "../../_models";
import {AccountService} from "../../_services";

@Component({
  selector: 'app-organizer',
  templateUrl: './organizer.component.html',
  styleUrls: ['./organizer.component.scss']
})
export class OrganizerComponent implements OnInit {

  form: FormGroup
  tasks: Task[] = []

  constructor(public dateService: DateService,
              private tasksService: Test2Service,
              ) {
  }

  ngOnInit() {
    this.dateService.date.pipe(
      switchMap(value=> this.tasksService.getByDate(value))).subscribe(tasks => {this.tasks = tasks})
    this.form = new FormGroup({
      title: new FormControl('', Validators.required)
    })
  }

  submit() {
    const {title} = this.form.value

    const task: Task = {
      title,
      DateTime: this.dateService.date.value.format('DD-MM-YYYY')
    }
    console.log(task)
    this.tasksService.create(task).subscribe(task => {
      this.tasks.push(task)
      this.form.reset()
    }, err => console.error(err))
  }

  remove(task: Task) {
    this.tasksService.remove(task).subscribe(() => {
      this.tasks = this.tasks.filter(t => t.id !== task.id)
    }, err => console.error(err))
  }

  removeByOBJ(task: Task) {
    this.tasksService.removeByObject(task).subscribe(() => {
      this.tasks = this.tasks.filter(t => t.id !== task.id)
    }, err => console.error(err))
  }

}
