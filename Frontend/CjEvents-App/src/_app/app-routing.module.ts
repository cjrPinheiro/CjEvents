import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactComponent } from './_components/contact/contact.component';
import { DashboardComponent } from './_components/dashboard/dashboard.component';
import { EventsComponent } from './_components/events/events.component';
import { ProfileComponent } from './_components/profile/profile.component';
import { SpeakersComponent } from './_components/speakers/speakers.component';

const routes: Routes = [
{path: 'events', component: EventsComponent},
{path: 'dashboard', component: DashboardComponent},
{path: 'contact', component: ContactComponent},
{path: 'profile', component: ProfileComponent},
{path: 'speakers', component: SpeakersComponent},
{path: '', redirectTo: 'dashboard', pathMatch: 'full'},
{path: '**', redirectTo: 'dashboard', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
