import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Despesa } from '../interfaces/Despesa.interface';

@Injectable({
  providedIn: 'root'
})

export class DespesaService {

  private _http: HttpClient;

  private _UrlBase: string;

  constructor(http: HttpClient) {

    this._http = http;

    this._UrlBase = "http://localhost:5275/api/Despesa/";

  }

  getAll(): Observable<Despesa[]> {

    // debugger

    return this._http.get<Despesa[]>(`${this._UrlBase}ObterDespesas`);

  }

  get(Id: any): Observable<Despesa> {

    // debugger

    return this._http.get<Despesa>(`${this._UrlBase}ObterDespesaPorId?Id=${Id}`);

  }

  create(data: any): Observable<any> {

    // debugger

    return this._http.post(`${this._UrlBase}AdicionarDespesa`, data);

  }

  update(Id: any, data: any): Observable<any> {

    // debugger

    return this._http.put(`${this._UrlBase}AtualizarDespesa?Id=${Id}`, data);

  }

  delete(Id: any): Observable<any> {

    // debugger

    return this._http.delete(`${this._UrlBase}ApagarDespesa?Id=${Id}`);

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
