import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { DadosClientes } from './dados-cliente/dados-cliente.component';
import { Inicio } from './inicio/inicio.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    DadosClientes
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    RouterModule.forRoot([
      { path: '', component: Inicio, pathMatch: 'full' },
      { path: 'dados-cliente', component: DadosClientes }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
