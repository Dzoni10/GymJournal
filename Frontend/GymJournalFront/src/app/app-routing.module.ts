import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { TrainingProgressComponent } from './progress/training-progress/training-progress.component';
import { TrainingProfileComponent } from './training/training-profile/training-profile.component';
import { authGuard } from './core/guard/auth.guard';

const routes: Routes = [
  {path: 'login',component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'navbar', component:NavbarComponent,canActivate:[authGuard]},
  {path: 'progress', component:TrainingProgressComponent,canActivate:[authGuard]},
  {path: 'training-profile',component:TrainingProfileComponent, canActivate:[authGuard]},
  {path: '**', redirectTo: '/login', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
