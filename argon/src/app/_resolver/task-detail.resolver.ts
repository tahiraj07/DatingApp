import {Injectable} from '@angular/core';
import {User} from '../_models/user';
import {Resolve,Router, ActivatedRouteSnapshot} from '@angular/router';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Task } from '../_models/task';
import { AuthService } from '../_services/auth.service';

@Injectable()
export class TaskDetailResolver implements Resolve<Task> {
    constructor(private userService: UserService,private authService: AuthService,
        private router: Router, private alertify: AlertifyService) {}

        resolve(route: ActivatedRouteSnapshot): Observable<Task> {
            return this.userService.getTaskk(this.authService.decodedToken.nameid, route.params['id']).pipe(
                catchError(error => {
                    this.alertify.error('Problem retrieving data');
                    this.router.navigate(['/dashboard']);
                    return of(null);
                })
            );
        }
        
}