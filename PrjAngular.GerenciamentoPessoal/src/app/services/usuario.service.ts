import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../interfaces/Usuario.interface';

@Injectable({
  providedIn: 'root'
})

export class UsuarioService {

  private _http: HttpClient;

  private _UrlBase: string;

  constructor(http: HttpClient) {

    this._http = http;

    this._UrlBase = "http://localhost:5275/api/Usuario/";

  }

  getAll(): Observable<Usuario[]> {

    // debugger

    return this._http.get<Usuario[]>(`${this._UrlBase}ObterUsuarios`);

  }

  get(Id: any): Observable<Usuario> {

    // debugger

    return this._http.get<Usuario>(`${this._UrlBase}ObterUsuarioPorId?Id=${Id}`);

  }

  create(data: any): Observable<any> {

    // debugger

    return this._http.post(`${this._UrlBase}AdicionarUsuario`, data);

  }

  update(Id: any, data: any): Observable<any> {

    // debugger

    return this._http.put(`${this._UrlBase}AtualizarUsuario?Id=${Id}`, data);

  }

  delete(Id: any): Observable<any> {

    // debugger

    return this._http.delete(`${this._UrlBase}ApagarUsuario?Id=${Id}`);

  }

  deleteAll(): Observable<any> {

    // debugger

    return this._http.delete(this._UrlBase);

  }

  findByName(name: any): Observable<any> {

    // debugger

    return this._http.get(`${this._UrlBase}?Nome=${name}`);

  }
}
