import { Routes } from '@angular/router';

import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { IconsComponent } from '../../pages/icons/icons.component'; 
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { TablesComponent } from '../../pages/tables/tables.component';
import { UsersComponent } from '../../pages/users/users.component';  
import { MemberListResolver } from 'src/app/_resolver/member-list.resolver';
import { AuthGuard } from 'src/app/_guards/auth.guard';
import { UserProfileResolver } from 'src/app/_resolver/userprofile.resolver';
import { TasksComponent } from 'src/app/pages/tasks/tasks.component';
import { ChatComponent } from 'src/app/pages/chat/chat.component';
import { MessagesResolver } from 'src/app/_resolver/messages.resolver';
import { TaskDetailComponent } from 'src/app/pages/task-detail/task-detail.component';
import { TaskDetailResolver } from 'src/app/_resolver/task-detail.resolver';

export const AdminLayoutRoutes: Routes = [
    {path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
    { path: 'dashboard',      component: DashboardComponent }, 
    { path: 'user-profile',   component: UserProfileComponent , resolve: {user: UserProfileResolver}},
    { path: 'tables',         component: TablesComponent },
    { path: 'icons',          component: IconsComponent }, 
    { path: 'tasks',          component: TasksComponent },
    { path: 'task-detail/:id',component: TaskDetailComponent , resolve: {task: TaskDetailResolver}},
    { path: 'chat',           component: ChatComponent , resolve: {messages: MessagesResolver}},
    { path: 'users',          component: UsersComponent , resolve: {users: MemberListResolver}}
          ]  }
];
 