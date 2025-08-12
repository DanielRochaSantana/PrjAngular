import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from '../interfaces/Cliente.interface';

@Injectable({
  providedIn: 'root'
})

export class ClienteService {

  private _http: HttpClient;

  private _UrlBase: string;

  constructor(http: HttpClient) {

    this._http = http;

    this._UrlBase = "https://192.168.15.7:8082/api/Administracao/";

  }

  getAll(): Observable<Cliente[]> {

    debugger

    return this._http.get<Cliente[]>(`${this._UrlBase}ListarClientes`);

  }

  get(Id: any): Observable<Cliente> {

    debugger

    return this._http.get<Cliente>(`${this._UrlBase}ObterCliente?Id=${Id}`);

  }

  create(data: any): Observable<any> {

    debugger

    return this._http.post(`${this._UrlBase}AdicionarCliente`, data);

  }

  update(Id: any, data: any): Observable<any> {

    debugger

    return this._http.put(`${this._UrlBase}AtualizarCliente?Id=${Id}`, data);

  }

  delete(Id: any): Observable<any> {

    debugger

    return this._http.delete(`${this._UrlBase}RemoverCliente?Id=${Id}`);

  }

  deleteAll(): Observable<any> {

    debugger

    return this._http.delete(this._UrlBase);

  }

  findByName(name: any): Observable<any> {

    debugger

    return this._http.get(`${this._UrlBase}?Nome=${name}`);

  }
}
