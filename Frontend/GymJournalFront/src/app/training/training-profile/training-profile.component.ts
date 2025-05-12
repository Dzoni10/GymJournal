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
      date: [new Date(), Validators.required]
    });

    this.getRecentTrainings();
   }

   onSubmit(): void{

    const training: TrainingModel={
      userId : this.usrId,
      exerciseType: Number(this.trainingForm.value.exerciseType),
      duration: this.trainingForm.value.duration || 0,
      calories: this.trainingForm.value.calories || 0,
      difficulty: this.trainingForm.value.difficulty || 0,
      fatigue: this.trainingForm.value.fatigue || 0,
      note: this.trainingForm.value.note || "",
      date: this.trainingForm.value.date || ""
    };

    
    if(this.trainingForm.valid)
    {
      this.trainingProfileService.addTraining(training).subscribe({
        next:()=>{
          console.log(training);
          this.trainingForm.reset();
        },error:(err)=>{
          alert("Cannot save training");
          console.log(err);
        }
      });
    }
    this.getRecentTrainings();
   }


   getRecentTrainings()
    {
      this.trainingProfileService.getTours().subscribe({
        next: (res)=>{
          this.recentTrainings=res.results;
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

    convertDate(date: Date):string {
     return this.dp.transform(date, 'EEEE,dd-MM-yyyy')!;
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
