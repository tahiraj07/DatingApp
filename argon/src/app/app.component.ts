import { Component } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';  
import { User } from './_models/user';
import { AuthService } from './_services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent { 
  title = 'argon-dashboard-angular';
  jwtHelper = new JwtHelperService();

  constructor(private authservice: AuthService) {}
  ngOnInit() {
    const token = localStorage.getItem('token');
    const user: User = JSON.parse(localStorage.getItem('user'));
    if(token) {
      this.authservice.decodedToken = this.jwtHelper.decodeToken(token);
    }
    if (user) {
      this.authservice.currentUser = user;
    }
  }
  loggedIn() {
    return this.authservice.loggedIn();
 }
}
 