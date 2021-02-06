import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { PaginateResult, Pagination } from 'src/app/_models/pagination';
import { User } from 'src/app/_models/user';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';
import { UserService } from 'src/app/_services/user.service';

@Component({ 
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {
  users: User[];
  user: User = JSON.parse(localStorage.getItem('user'));
  genderList = [{value: 'male', display: 'Males'}, {value: 'female',display: 'Females'}];
  userParams: any = {};
  pagination: Pagination;
  constructor(private userService: UserService, private alertify: AlertifyService,
    private route: ActivatedRoute ) { }

  ngOnInit() {
     this.route.data.subscribe(data => {
       this.users = data['users'].result;
       this.pagination = data['users'].pagination;
     });

     this.userParams.gender = this.user.gender === 'female' ? 'male' : 'female';
     this.userParams.minAge = 18;
     this.userParams.maxAge = 99;
     this.userParams.orderBy = 'LastActive';
  }

  pageChanged(event: any):void {
    this.pagination.currentPage = event.page;
    this.loadUsers();
  }

  resetFilters() {
    this.userParams.gender = this.user.gender === 'female' ? 'male' : 'female';
     this.userParams.minAge = 18;
     this.userParams.maxAge = 99;
     this.loadUsers();
  }

  //KUR NGARKOHET FAQJA NGARKON USERAT QE MERREN NGA FUNKSIONI GETUSERS (user.service.ts)
  loadUsers() {
    this.userService
    .getUsers(this.pagination.currentPage, this.pagination.itemsPerPage,this.userParams)
    .subscribe(
      (res: PaginateResult<User[]>) => {
      this.users = res.result;
      this.pagination = res.pagination;
    },error =>{
      this.alertify.error(error);
    });
  }

}
