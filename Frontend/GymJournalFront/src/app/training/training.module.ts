import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrainingProfileComponent } from './training-profile/training-profile.component';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCommonModule, MatNativeDateModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { MatSliderModule } from '@angular/material/slider';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatMomentDateModule } from '@angular/material-moment-adapter';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    TrainingProfileComponent
  ],
  imports: [
    CommonModule,
    MatButtonModule,
    MatFormFieldModule,
    MatCommonModule,
    MatSelectModule,
    MatSliderModule,
    MatDatepickerModule,
    MatInputModule,
    MatCardModule,
    MatNativeDateModule,
    MatListModule,
    MatIconModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    FormsModule,
    MatMomentDateModule,
    RouterModule
    
  ]
})
export class TrainingModule { }
