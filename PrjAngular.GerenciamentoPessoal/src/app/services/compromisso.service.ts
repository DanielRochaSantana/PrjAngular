import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Compromisso } from '../interfaces/Compromisso.interface';

@Injectable({
  providedIn: 'root'
})

export class CompromissoService {

  private _http: HttpClient;

  private _UrlBase: string;

  constructor(http: HttpClient) {

    this._http = http;

    this._UrlBase = "http://localhost:5275/api/Compromisso/";

  }

  getAll(): Observable<Compromisso[]> {

    // debugger

    return this._http.get<Compromisso[]>(`${this._UrlBase}ObterCompromissos`);

  }

  get(Id: any): Observable<Compromisso> {

    // debugger

    return this._http.get<Compromisso>(`${this._UrlBase}ObterCompromissoPorId?Id=${Id}`);

  }

  create(data: any): Observable<any> {

    // debugger

    return this._http.post(`${this._UrlBase}AdicionarCompromisso`, data);

  }

  update(Id: any, data: any): Observable<any> {

    // debugger

    return this._http.put(`${this._UrlBase}AtualizarCompromisso?Id=${Id}`, data);

  }

  delete(Id: any): Observable<any> {

    // debugger

    return this._http.delete(`${this._UrlBase}ApagarCompromisso?Id=${Id}`);

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
