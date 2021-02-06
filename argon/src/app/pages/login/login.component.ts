import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router'; 
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({ 
  selector: 'app-login', 
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit  { 
  public collapsed = false;
  model: any = {};
  constructor(public authservice: AuthService, private alertify: AlertifyService,
    private router: Router ) { }

  ngOnInit() {
  }

  login() {
    this.authservice.login(this.model).subscribe(next => {
      this.alertify.success('Logged in sucesfully!');
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.router.navigate(['/dashboard']);
    }
    );
  }

  loggedIn() {
     return this.authservice.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    this.authservice.decodedToken = null;
    this.authservice.currentUser = null;
    this.alertify.message('Logged Out!');
    this.router.navigate(['/login']);
  }
}
