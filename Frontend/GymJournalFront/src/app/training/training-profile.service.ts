import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TrainingModel } from './model/training.model';
import { environment } from 'src/env/enviroment';
import { Observable } from 'rxjs';
import { PagedResults } from '../shared/paged-results';

@Injectable({
  providedIn: 'root'
})
export class TrainingProfileService {

  constructor(private http: HttpClient) { }

  addTraining(training: TrainingModel): Observable<TrainingModel>{
    console.log(training);
    return this.http.post<TrainingModel>(environment.apiHost + 'trainings',training);
  }

  getTrainings(): Observable<PagedResults<TrainingModel>>{
    return this.http.get<PagedResults<TrainingModel>>(environment.apiHost + 'trainings/userTrainings');
  }

}
