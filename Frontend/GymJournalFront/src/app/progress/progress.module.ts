import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrainingProgressComponent } from './training-progress/training-progress.component';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule, MatMonthView } from '@angular/material/datepicker';
import { MatCardModule } from '@angular/material/card';
import {MatTableModule} from '@angular/material/table';
import { MatNativeDateModule } from '@angular/material/core';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    TrainingProgressComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDatepickerModule,
    MatCardModule,
    MatTableModule,
    MatNativeDateModule,
    RouterModule
  ]
})
export class ProgressModule { }
