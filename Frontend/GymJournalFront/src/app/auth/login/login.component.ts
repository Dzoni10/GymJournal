import { Component } from '@angular/core';
import { FormControl,FormGroup,Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import {Router} from '@angular/router';
import { Login } from '../model/login.model';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  animations: [
    trigger('slideIn', [
      state('void', style({ transform: 'translateY(0)', opacity: 0 })),
      transition(':enter', [
        animate('2.5s ease-out', style({ transform: 'translateY(0)', opacity: 1 }))
      ])
    ])
  ]
})
export class LoginComponent {

  constructor(private authService: AuthService, private router: Router,private snackBar: MatSnackBar){}

  loginForm = new FormGroup({
    username: new FormControl('', [Validators.required]),
    password: new FormControl('',[Validators.required])
  });

  login(): void{
    const login: Login ={
      username: this.loginForm.value.username || "",
      password: this.loginForm.value.password || ""
    };

    if(this.loginForm.valid)
    {
      this.authService.login(login).subscribe({
        next: ()=>{
          this.router.navigate(['/training-profile']);
        },
        error: (err)=>{
          this.snackBar.open("User with this credentials does not exist please sign up" , "Close", { duration: 3000 ,verticalPosition:'bottom', horizontalPosition:'center'})
        }
      });
    }
  }

}
