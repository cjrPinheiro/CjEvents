import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactComponent } from './_components/contact/contact.component';
import { DashboardComponent } from './_components/dashboard/dashboard.component';
import { EventDetailComponent } from './_components/events/event-detail/event-detail.component';
import { EventListComponent } from './_components/events/event-list/event-list.component';
import { EventsComponent } from './_components/events/events.component';
import { ProfileComponent } from './_components/user/profile/profile.component';
import { SpeakersComponent } from './_components/speakers/speakers.component';
import { LoginComponent } from './_components/user/login/login.component';
import { RegistrationComponent } from './_components/user/registration/registration.component';
import { UserComponent } from './_components/user/user.component';

const routes: Routes = [
  {path:'user', component: UserComponent,
  children:[
    {path: 'login', component: LoginComponent},
    {path: 'registration', component: RegistrationComponent}
  ]
},
{path: 'events', redirectTo: 'events/list'},
{
  path: 'events', component: EventsComponent,
  children: [
    {path: 'detail/:id', component: EventDetailComponent},
    {path: 'detail', component: EventDetailComponent},
    {path: 'list', component: EventListComponent}
  ]
},
{path: 'user/profile', component: ProfileComponent},
{path: 'dashboard', component: DashboardComponent},
{path: 'contact', component: ContactComponent},
{path: 'speakers', component: SpeakersComponent},
{path: '', redirectTo: 'dashboard', pathMatch: 'full'},
{path: '**', redirectTo: 'dashboard', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
