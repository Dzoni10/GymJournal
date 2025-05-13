import { Component,OnInit } from '@angular/core';
import{MatSelectModule} from'@angular/material/select';
import {MatSliderModule} from '@angular/material/slider'
import { TrainingModel } from '../model/training.model';
import { TrainingProfileService } from '../training-profile.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthService } from 'src/app/auth/auth.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-training-profile',
  templateUrl: './training-profile.component.html',
  styleUrls: ['./training-profile.component.css'],
})
export class TrainingProfileComponent implements OnInit {

  trainingForm!: FormGroup;
  constructor(private trainingProfileService: TrainingProfileService, private builder: FormBuilder, private authService: AuthService, private dp: DatePipe){}

   
   userName="";
   recentTrainings: TrainingModel[]=[];
   usrId: number=0;
   today: Date = new Date();

   ngOnInit(): void {
    this.today=new Date();
    this.authService.usr.subscribe(user => {
      this.usrId = user.id;
    });

    this.getName(this.usrId);

    this.trainingForm = this.builder.group({
      exerciseType: [ '', Validators.required],
      duration: [null, [Validators.required, Validators.min(1), Validators.max(60)]],
      calories: [null, [Validators.required, Validators.min(1)]],
      difficulty: [1],
      fatigue: [1],
      note: [''],
      date: [new Date(), Validators.required],
      time: ['', Validators.required] 
    });

    this.getRecentTrainings();
   }

   onSubmit(): void{

    const formValue = this.trainingForm.value;

    const date = new Date(formValue.date);
    const [hours, minutes] = formValue.time.split(':').map((v: string) => parseInt(v, 10));
    date.setHours(hours);
    date.setMinutes(minutes);
    date.setSeconds(0);
    date.setMilliseconds(0);

    const training: TrainingModel={
      userId : this.usrId,
      exerciseType: Number(this.trainingForm.value.exerciseType),
      duration: this.trainingForm.value.duration || 0,
      calories: this.trainingForm.value.calories || 0,
      difficulty: this.trainingForm.value.difficulty || 0,
      fatigue: this.trainingForm.value.fatigue || 0,
      note: this.trainingForm.value.note || "",
      date: date.toISOString()
    };

    
    if(this.trainingForm.valid)
    {
      this.trainingProfileService.addTraining(training).subscribe({
        next:()=>{
          console.log(training);
          this.trainingForm.reset();
          this.getRecentTrainings();
        },error:(err)=>{
          alert("Cannot save training");
          console.log(err);
        }
      });
    }
   }

   getRecentTrainings()
    {
      this.trainingProfileService.getTrainings().subscribe({
        next: (res)=>{
          this.recentTrainings=res.results.sort((a, b) => new Date(a.date).getTime() - new Date(b.date).getTime()).reverse();
        },error:(err)=>{
          alert("Cannot get trainings");
          console.log(err);
        }
      });
    }

    reverseStatus(training: TrainingModel) : string{
      if(training.exerciseType === 0)
        return "Cardio";
      else if(training.exerciseType === 1)
        return "Strength";
      else
        return "Flexibility";
    }

    convertDate(date: string|Date):string {
      if (!date) return '';
      const parsedDate = typeof date === 'string' ? new Date(date) : date;
     return this.dp.transform(parsedDate, 'EEEE,dd-MM-yyyy HH:mm a')||'';
    }

    getName(id: number){
      this.authService.getName(id).subscribe({
        next:(res)=>{
            this.userName=res;
        },error: (err)=>{
          console.log("Error with name",err);
        }
      });
    }
}
