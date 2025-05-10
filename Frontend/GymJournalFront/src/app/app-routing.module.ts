import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { TrainingProgressComponent } from './progress/training-progress/training-progress.component';
import { TrainingProfileComponent } from './training/training-profile/training-profile.component';

const routes: Routes = [
  {path: 'login',component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'navbar', component:NavbarComponent},
  {path: 'progress', component:TrainingProgressComponent},
  {path: 'training-profile',component:TrainingProfileComponent},
   {path: '**', redirectTo: '/login', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
