import { Routes } from '@angular/router';

import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { IconsComponent } from '../../pages/icons/icons.component';
import { MapsComponent } from '../../pages/maps/maps.component';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { TablesComponent } from '../../pages/tables/tables.component';
import { UsersComponent } from '../../pages/users/users.component';  
import { MemberListResolver } from 'src/app/_resolver/member-list.resolver';
import { AuthGuard } from 'src/app/_guards/auth.guard';
import { UserProfileResolver } from 'src/app/_resolver/userprofile.resolver';
import { TasksComponent } from 'src/app/pages/tasks/tasks.component';

export const AdminLayoutRoutes: Routes = [
    {path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
    { path: 'dashboard',      component: DashboardComponent }, 
    { path: 'user-profile',   component: UserProfileComponent , resolve: {user: UserProfileResolver}},
    { path: 'tables',         component: TablesComponent },
    { path: 'icons',          component: IconsComponent },
    { path: 'maps',           component: MapsComponent },
    { path: 'tasks',           component:TasksComponent },
    { path: 'users',           component: UsersComponent , resolve: {users: MemberListResolver}}
          ]  }
];
 