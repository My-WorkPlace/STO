import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

// used to create fake backend
import { fakeBackendProvider } from './_helpers';

import { AppRoutingModule } from './app-routing.module';
import { JwtInterceptor, ErrorInterceptor } from './_helpers';
import { AppComponent } from './app.component';

import { HomeComponent } from './home';
import { AlertComponent } from './_components/alert';
import {CalendarComponent} from "./_components/calendar/calendar.component";
import {SelectorComponent} from "./_components/selector/selector.component";
import {MomentPipe} from "./shared/moment.pipe";
import {OrganizerComponent} from "./_components/organizer/organizer.component";
import {SheduleTaskComponent} from "./_components/sheduleTask/sheduleTask.component";
// import { AlertComponent } from './_components/alert/alert.component';

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpClientModule,
        AppRoutingModule
    ],
    declarations: [
        AppComponent,
        AlertComponent,
        HomeComponent,
      CalendarComponent,
      SelectorComponent,
      OrganizerComponent,
      SheduleTaskComponent,
      MomentPipe
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },

        // provider used to create fake backend
        //fakeBackendProvider
    ],
    bootstrap: [AppComponent]
})
export class AppModule { };
