import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Task } from 'src/app/_models/task';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-task-detail',
  templateUrl: './task-detail.component.html',
  styleUrls: ['./task-detail.component.css']
})
export class TaskDetailComponent implements OnInit {
  @Input() createdById:number;
  @Input() com: Comment;
  comms: Comment[];
  task: Task;
  comm: Comment;
  toggle = false;
  status = "Enable";
  constructor(private route: ActivatedRoute,private router:Router, private alertify: AlertifyService,
    public userService: UserService, private authService: AuthService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.task = data['task'];
    });
  }
  updateTask() {
    this.userService.updateTask(this.authService.decodedToken.nameid, this.task.id ).subscribe(next => {
      
      this.alertify.success('Task updated successfully'); 
    },error => {
      this.alertify.error(error);
    })
  }

  enableDisableRule(job) {
    this.toggle = !this.toggle;
    this.status = this.toggle ? "Enable" : "Disable";
  }

  addComment(){ 
     
    this.userService.addcomment(this.authService.decodedToken.nameid,this.comm).subscribe(() => 
    {
      
      this.alertify.success('Comment added!');
      this.router.navigate(['/dashboard']);   
    },error => {
      console.log(error);
    }
    );
  }
}
