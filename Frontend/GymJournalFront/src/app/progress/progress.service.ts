import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TraininigProgress } from './model/training-progress.model';
import { Observable } from 'rxjs';
import { environment } from 'src/env/enviroment';

@Injectable({
  providedIn: 'root'
})
export class ProgressService {

  constructor(private http: HttpClient) { }


  getWeeklyProgress(year: number, month: number): Observable<TraininigProgress[]>{
    console.log("year: " + year + ", month: " + month);

    const params = new HttpParams()
    .set('year', year.toString())
    .set('month', month.toString());
    return this.http.get<TraininigProgress[]>(`${environment.apiHost}trainings/progress`, { params });
  }
}
