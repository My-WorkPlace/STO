import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {map} from 'rxjs/operators';
import {Observable} from 'rxjs';
import * as moment from 'moment';
import { environment } from 'src/environments/environment';
import {User} from "../_models";
import {AccountService} from "../_services";

export interface Task {
  id?: string
  title: string
  DateTime?: string
  ScheduleOwner?:User
}

@Injectable({providedIn: 'root'})
export class Test2Service {
    user:User;
                constructor(private http: HttpClient,
                private accountService: AccountService) {
                  this.user = this.accountService.userValue;

  }

  load(date: moment.Moment): Observable<Task[]> {
      console.log(date.format('DD-MM-YYYY'))
        return this.http
      .get<Task[]>(`${environment.apiUrl}/task`)
      .pipe(map(tasks => {
        if (!tasks) {
          return []
        }
        return Object.keys(tasks).map(key => ({...tasks[key], id: key}))
      }))
  }

  getByDate(date:moment.Moment):Observable<Task[]>{
      const task:Task = new class implements Task {
        DateTime: string;
        id: string;
        title: string;
      }
      task.DateTime = date.format('DD-MM-YYYY')
    return this.http
      .post<Task>(`${environment.apiUrl}/task/GetByDate`,task)
      .pipe(map(tasks => {
        if (!tasks) {
          return []
        }
        return Object.keys(tasks).map(key => ({...tasks[key], id: key}))
      }))
  }

  create(task: Task): Observable<Task> {
      console.log("postUrl : "+`${environment.apiUrl}/task/create`)
      console.log(task)
    task.ScheduleOwner = this.user;
    return this.http
      .post<Task>(`${environment.apiUrl}/task/create`, task)
      .pipe(map(res => {
        return {...task}
      }))
  }

  getAll() {
    return this.http.get<Task[]>(`${environment.apiUrl}/task`);
  }

  remove(task: Task): Observable<void> {
    return this.http
      .delete<void>(`${environment.apiUrl}/task/${task.id}`)
  }

  removeByObject(task:Task)
  {
    console.log(task)
    const res:Task = new class implements Task {
      DateTime: string;
      id: string;
      title: string;
    }
    res.DateTime = task.DateTime
    res.title = task.title
    return this.http.post<Task>(`${environment.apiUrl}/task/DeleteObj`,res)
  }

}
