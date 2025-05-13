import { Component, OnInit } from '@angular/core';
import { TraininigProgress } from '../model/training-progress.model';
import { ProgressService } from '../progress.service';
import { FormControl } from '@angular/forms';
import { trigger, state, style, transition, animate } from '@angular/animations';

@Component({
  selector: 'app-training-progress',
  templateUrl: './training-progress.component.html',
  styleUrls: ['./training-progress.component.css'],
  animations: [
    trigger('slideIn', [
      state('void', style({ transform: 'translateY(-100%)', opacity: 0 })),
      transition(':enter', [
        animate('1.5s ease-out', style({ transform: 'translateY(0)', opacity: 1 }))
      ])
    ])
  ]
})
export class TrainingProgressComponent implements OnInit {

progressData: TraininigProgress | undefined;
selectedDate = new FormControl(new Date());
dataSource: TraininigProgress[] = [];
displayedColumns: string[] = ['weekNumber', 'totalTrainings', 'totalDuration', 'averageDifficulty', 'averageFatigue'];

constructor(private progressService: ProgressService){}
  
 ngOnInit(): void {
   this.fetchDataForSelectedMonth();
 }

fetchDataForSelectedMonth(): void{
  const selected = this.selectedDate.value;
  if (!selected) return;

  if (!(selected instanceof Date)) {
    console.error('Invalid date selected.');
    return;
  }

  const year = selected.getFullYear();
  const month = selected.getMonth() + 1;

  this.progressService.getWeeklyProgress(year, month).subscribe({
    next: (data) => {
      this.dataSource = data;
      console.log(this.dataSource);
    },
    error: (err) => {
      console.error('Failed to fetch progress data:', err);
    }
  });
}

chosenMonthHandler(normalizedMonth: Date, datepicker: any){
  const newDate = new Date(normalizedMonth);
  newDate.setDate(1);
  this.selectedDate.setValue(newDate);
  datepicker.close(); 
}

}
