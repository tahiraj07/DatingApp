import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ClipboardModule } from 'ngx-clipboard';

import { AdminLayoutRoutes } from './admin-layout.routing';
import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { IconsComponent } from '../../pages/icons/icons.component';
import { MapsComponent } from '../../pages/maps/maps.component';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { TablesComponent } from '../../pages/tables/tables.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from 'src/_services/auth.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { UserService } from 'src/_services/user.service';
import { AuthGuard } from 'src/app/_guards/auth.guard';
import { UserProfileResolver } from 'src/app/_resolver/userprofile.resolver';
import { MemberListResolver } from 'src/app/_resolver/member-list.resolver';
import { UsersComponent } from 'src/app/pages/users/users.component'; 
import { MemberCardComponent } from 'src/app/pages/member-card/member-card.component';
import { TasksComponent } from 'src/app/pages/tasks/tasks.component';
import { TabsModule } from 'ngx-bootstrap/tabs'; 
// import { ToastrModule } from 'ngx-toastr';  
@NgModule({
  imports: [
    CommonModule,
    TabsModule.forRoot(),
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    HttpClientModule,
    NgbModule,
    ClipboardModule 
  ],
  declarations: [
    DashboardComponent,
    UserProfileComponent,
    TablesComponent, 
    IconsComponent,
    MapsComponent,
    UsersComponent,
    MemberCardComponent,
    TasksComponent
  ],
  providers: [AuthService,  
    AlertifyService,
  UserService,
  AuthGuard,
  MemberListResolver,
  UserProfileResolver ]
})

export class AdminLayoutModule {}
