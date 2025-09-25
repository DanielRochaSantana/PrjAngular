import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Atuacao } from '../interfaces/Atuacao.interface';

@Injectable({
  providedIn: 'root'
})

export class AtuacaoService {

  private _http: HttpClient;

  private _UrlBase: string;

  constructor(http: HttpClient) {

    this._http = http;

    this._UrlBase = "http://localhost:5275/api/Atuacao/";

  }

  getAll(): Observable<Atuacao[]> {

    // debugger

    return this._http.get<Atuacao[]>(`${this._UrlBase}ObterAtuacoes`);

  }

  get(Id: any): Observable<Atuacao> {

    // debugger

    return this._http.get<Atuacao>(`${this._UrlBase}ObterAtuacaoPorId?Id=${Id}`);

  }

  create(data: any): Observable<any> {

    // debugger

    return this._http.post(`${this._UrlBase}AdicionarAtuacao`, data);

  }

  update(Id: any, data: any): Observable<any> {

    // debugger

    return this._http.put(`${this._UrlBase}AtualizarAtuacao?Id=${Id}`, data);

  }

  delete(Id: any): Observable<any> {

    // debugger

    return this._http.delete(`${this._UrlBase}ApagarAtuacao?Id=${Id}`);

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
