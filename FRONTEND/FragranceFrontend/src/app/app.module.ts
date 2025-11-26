import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListComponent } from './list/list.component';
import { CreateComponent } from './create/create.component';
import { HttpClientModule, provideHttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ConfigService } from './config.service';

@NgModule({
  declarations: [
    AppComponent,
    ListComponent,
    CreateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [provideHttpClient(),{
    provide: APP_INITIALIZER,
    useFactory: (cfg:ConfigService) => () => cfg.load(),
    deps: [ConfigService],
    multi:true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
