import { Component, OnInit,ViewEncapsulation } from '@angular/core';
import { AuthService } from 'src/app/auth/auth.service';
import { User } from 'src/app/auth/model/user.model';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  user: User | undefined;

  constructor(private authService: AuthService, private cdr:ChangeDetectorRef){}

  ngOnInit(): void {
    this.authService.usr.subscribe(user=>{
      this.user=user;
      this.cdr.detectChanges();
    });

  }

  onLogout(): void{
    this.authService.logout();
    this.cdr.detectChanges();
  }
}
