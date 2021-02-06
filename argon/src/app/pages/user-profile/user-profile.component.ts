import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { ActivatedRoute,Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { User } from 'src/app/_models/user';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';
import { UserService } from 'src/app/_services/user.service';
import { catchError } from 'rxjs/operators'; 
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {
  @ViewChild('editForm',{static:true}) editForm: NgForm;
  user: User;

  //ti nuk e mbyll dot faqen pa i ruajtur ndryshimet qe ke bere ne profilin tend
  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }  
  constructor(private route: ActivatedRoute,private alertify: AlertifyService,
    private userService: UserService, private authService: AuthService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
    this.user = data['user'];
    
  });
  }
  // updateUser() {
  //   this.userService.updateUser(this.authService.decodedToken.nameid, this.user).subscribe(next => {
  //     this.alertify.success('Profile updated successfully');
  //     this.editForm.reset(this.user);
  //   },error => {
  //     this.alertify.error(error);
  //   })
  // }

  // updateMainPhoto(photoUrl) {
  //   this.user.photoUrl = photoUrl;
  // }
//   resolve(): Observable<User> {
//     return this.userService.getUser(this.authService.decodedToken.nameid).pipe(
//         catchError(error => {
//             this.alertify.error('Problem retrieving your data');
//             this.router.navigate(['/members']);
//             return of(null);
//         })
//     );
// }
}
