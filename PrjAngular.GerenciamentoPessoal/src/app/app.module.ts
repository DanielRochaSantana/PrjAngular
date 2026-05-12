import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DadosAtividades } from './dados-atividade/dados-atividade.component';
import { DadosAtuacoes } from './dados-atuacao/dados-atuacao.component';
import { DadosCompromissos } from './dados-compromisso/dados-compromisso.component';
import { DadosCursos } from './dados-curso/dados-curso.component';
import { DadosDespesas } from './dados-despesa/dados-despesa.component';
import { DadosUsuarios } from './dados-usuario/dados-usuario.component';
import { Inicio } from './inicio/inicio.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    DadosUsuarios,
    DadosAtividades,
    DadosDespesas,
    DadosAtuacoes,
    DadosCompromissos,
    DadosCursos
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    RouterModule.forRoot([
      { path: '', component: Inicio, pathMatch: 'full' },
      { path: 'dados-usuario', component: DadosUsuarios },
      { path: 'dados-atividade', component: DadosAtividades },
      { path: 'dados-despesa', component: DadosDespesas },
      { path: 'dados-atuacao', component: DadosAtuacoes },
      { path: 'dados-compromisso', component: DadosCompromissos },
      { path: 'dados-curso', component: DadosCursos }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
