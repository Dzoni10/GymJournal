import { Component, OnInit } from '@angular/core';
import { User } from '../model/user.model';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Registration } from '../model/registration.model';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {


  loggedInUser: User|undefined;

  constructor(private authService: AuthService, private router: Router, private snackBar:MatSnackBar)
  {}


  registrationForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    surname: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required]),
    phone: new FormControl('', [Validators.required]),
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
    confirmPassword: new FormControl('', [Validators.required]),
    
  });

  register(): void {

    const registration: Registration = {
      name: this.registrationForm.value.name || "",
      surname: this.registrationForm.value.surname || "",
      email: this.registrationForm.value.email || "",
      phone: this.registrationForm.value.phone || "",
      username: this.registrationForm.value.username || "",
      password: this.registrationForm.value.password || "",
      };

      const form = this.registrationForm.value;

     if (form.password !== form.confirmPassword) {
        alert("Passwords do not match.");
        return;
      }

      if(this.registrationForm.valid)
      {
        this.authService.register(registration).subscribe({
          next: ()=>{
            this.router.navigate(['/login']);
          },
          error: (err)=>{
            console.log(err);
            const message = err.error?.detail as string;
            if(message?.includes("username"))
              this.snackBar.open("Username already exist" , "Close", { duration: 3000 ,verticalPosition:'bottom', horizontalPosition:'center'})
            else if(message?.includes("Email") || message?.includes(".com"))
              this.snackBar.open("Wrong email format => must be 'smth@(gmail,yahoo..).com'" , "Close", { duration: 3000 ,verticalPosition:'bottom', horizontalPosition:'center'})
            else if(message?.includes("nonuniquemail"))
              this.snackBar.open("Email already exist" , "Close", { duration: 3000 ,verticalPosition:'bottom', horizontalPosition:'center'})
          }
        });
      }
    }

    passwordMatchValidator(formGroup: FormGroup) {
      const password = formGroup.get('password')?.value;
      const confirmPassword = formGroup.get('confirmPassword')?.value;
      return password === confirmPassword ? null : { passwordMismatch: true };
    }
}
