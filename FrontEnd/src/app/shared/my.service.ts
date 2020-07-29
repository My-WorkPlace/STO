import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {map} from 'rxjs/operators';
import {Observable} from 'rxjs';
import * as moment from 'moment';
import { environment } from 'src/environments/environment';

export interface Task2 {
  id?: number
  title: string
  DateTime?: string
}



@Injectable({providedIn: 'root'})
export class MyService {

  constructor(private http: HttpClient) {
  }

  load(date: moment.Moment): Observable<Task2[]> {
    return this.http
      .get<Task2[]>(`${environment.apiUrl}task`)
  }

  create(task: Task2): Observable<Task2> {
    return this.http
      .post<Task2>(`${environment.apiUrl}task/create`, task)
  }

  getAll() {
    return this.http.get<Task2[]>(`${environment.apiUrl}task`);
  }

  remove(task: Task2): Observable<void> {
    return this.http
      .delete<void>(`${environment.apiUrl}task/${task.id}`)
  }

}
