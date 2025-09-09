import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Atividade } from '../interfaces/Atividade.interface';

@Injectable({
  providedIn: 'root'
})

export class AtividadeService {

  private _http: HttpClient;

  private _UrlBase: string;

  constructor(http: HttpClient) {

    this._http = http;

    this._UrlBase = "http://localhost:5275/api/Atividade/";

  }

  getAll(): Observable<Atividade[]> {

    // debugger

    return this._http.get<Atividade[]>(`${this._UrlBase}ObterAtividades`);

  }

  get(Id: any): Observable<Atividade> {

    // debugger

    return this._http.get<Atividade>(`${this._UrlBase}ObterAtividadePorId?Id=${Id}`);

  }

  create(data: any): Observable<any> {

    // debugger

    return this._http.post(`${this._UrlBase}AdicionarAtividade`, data);

  }

  update(Id: any, data: any): Observable<any> {

    // debugger

    return this._http.put(`${this._UrlBase}AtualizarAtividade?Id=${Id}`, data);

  }

  delete(Id: any): Observable<any> {

    // debugger

    return this._http.delete(`${this._UrlBase}ApagarAtividade?Id=${Id}`);

  }

  deleteAll(): Observable<any> {

    // debugger

    return this._http.delete(this._UrlBase);

  }

  findByName(name: any): Observable<any> {

    // debugger

    return this._http.get(`${this._UrlBase}?Descricao=${name}`);

  }
}
