import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';
import { SidebarDirective } from '../nav/sidebar.directive';
@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html', 
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit { 
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
      this.router.navigate(['/members']);
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
    this.router.navigate(['/home']);
  }
}
