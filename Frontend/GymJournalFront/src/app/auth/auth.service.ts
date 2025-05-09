import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable,tap } from 'rxjs';
import { User } from './model/user.model';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { TokenStorage } from '../core/jwt/token.service';
import { Registration } from './model/registration.model';
import { AuthenticationResponse } from './model/authentication-response.model';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/env/enviroment';
import { Login } from './model/login.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  usr = new BehaviorSubject<User>({id:0,username:""})

  constructor(private http: HttpClient,
              private router: Router,
              private tokenStorage: TokenStorage
  ) { }

  register(registration: Registration): Observable<AuthenticationResponse>{
    return this.http.post<AuthenticationResponse>(environment.apiHost + 'users', registration).pipe(tap((authenticationResponse)=>{
      this.tokenStorage.saveAccessToken(authenticationResponse.accessToken);
      this.setUser();
    }))
  }

  login(login: Login): Observable<AuthenticationResponse> {
    return this.http
      .post<AuthenticationResponse>(environment.apiHost + 'users/login', login)
      .pipe(
        tap((authenticationResponse) => {
          this.tokenStorage.saveAccessToken(authenticationResponse.accessToken);
          this.setUser();
        })
      );
  }

  private setUser(): void {
    const jwtHelperService = new JwtHelperService();
    const accessToken = this.tokenStorage.getAccessToken() || "";

    // Decode token
    const decodedToken = jwtHelperService.decodeToken(accessToken);

    // Use bracket notation to access the role key
    const roleKey = 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role';
    const user: User = {
      id: +decodedToken.id, // Convert id to a number
      username: decodedToken.username || "unknown", // Provide a default for username
    };
    console.log('Decoded Token:', decodedToken);

    this.usr.next(user);
  }

  checkIfUserExists(): void {
    const accessToken = this.tokenStorage.getAccessToken();
    if (accessToken == null) {
      return;
    }
      //ciscenje prethodnog isteklog tokena
    const jwtHelper = new JwtHelperService();
    if(jwtHelper.isTokenExpired(accessToken))
    {
      this.tokenStorage.clear();
      return;
    }

    this.setUser();
  }

  logout(): void {
    this.router.navigate(['/']).then(_ => {
      this.tokenStorage.clear();
      this.usr.next({ username: "", id: 0});
    });
  }
}
