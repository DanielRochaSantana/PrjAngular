import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { DadosUsuarios } from './dados-usuario/dados-usuario.component';
import { Inicio } from './inicio/inicio.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    DadosUsuarios
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    RouterModule.forRoot([
      { path: '', component: Inicio, pathMatch: 'full' },
      { path: 'dados-usuario', component: DadosUsuarios }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
