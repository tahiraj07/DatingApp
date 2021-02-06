import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt'; 
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/_services/auth.service';

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  styleUrls: ['./admin-layout.component.scss']
})
export class AdminLayoutComponent implements OnInit {
  jwtHelper = new JwtHelperService(); 

  constructor(private authservice: AuthService) {}
  title = 'pro-dashboard-angular'; 
  
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
