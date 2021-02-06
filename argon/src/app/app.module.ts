import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt'; 
import { AppComponent } from './app.component';
import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ComponentsModule } from './components/components.module';
  
import { UserProfileResolver } from 'src/app/_resolver/userprofile.resolver'; 
import { routes } from './app.routing'; 
import { AuthService } from './_services/auth.service';
import { AlertifyService } from './_services/alertify.service';
import { UserService } from './_services/user.service';
import { AuthGuard } from './_guards/auth.guard';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ComponentsModule, 
    NgbModule,
    RouterModule, 
    TabsModule.forRoot(),
    BsDatepickerModule.forRoot(),
    BsDropdownModule.forRoot(),
    PaginationModule.forRoot(),
    RouterModule.forRoot(routes),
    JwtModule.forRoot({
      config: {
         tokenGetter: tokenGetter ,  
         allowedDomains: ['localhost:5000'],
         disallowedRoutes: ['localhost:5000/api/auth']
      }
   })
  ],
  declarations: [
    AppComponent, 
    AdminLayoutComponent,
    AuthLayoutComponent
  ],
  providers: [AuthService,  
    AlertifyService,
  UserService,
  AuthGuard ],
  bootstrap: [AppComponent]
})
export class AppModule { }
