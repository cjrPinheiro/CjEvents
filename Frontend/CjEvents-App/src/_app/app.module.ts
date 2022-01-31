import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'

import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BsModalService, ModalModule } from 'ngx-bootstrap/modal';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from "ngx-spinner";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventsComponent } from './_components/events/events.component';
import { SpeakersComponent } from './_components/speakers/speakers.component';
import { NavComponent } from './_components/nav/nav.component';
import { FormsModule } from '@angular/forms';
import { EventService } from 'src/_app/_services/event.service';
import { DateTimeFormatPipe } from 'src/_app/_helpers/dateTimeFormat.pipe';
import { TitleComponent } from './_shared/title/title.component';
import { DashboardComponent } from './_components/dashboard/dashboard.component';
import { ProfileComponent } from './_components/profile/profile.component';
import { ContactComponent } from './_components/contact/contact.component';

@NgModule({
  declarations: [
    AppComponent,
    EventsComponent,
    SpeakersComponent,
    NavComponent,
    DateTimeFormatPipe,
    TitleComponent,
    DashboardComponent,
    ProfileComponent,
    ContactComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule,
    FormsModule,
    BsDropdownModule,
    TooltipModule,
    ModalModule,
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true
    }),
    NgxSpinnerModule
  ],
  providers: [
    EventService,
    BsModalService
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],

})
export class AppModule { }
