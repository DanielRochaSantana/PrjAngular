import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Curso } from '../interfaces/Curso.interface';

@Injectable({
  providedIn: 'root'
})

export class CursoService {

  private _http: HttpClient;

  private _UrlBase: string;

  constructor(http: HttpClient) {

    this._http = http;

    this._UrlBase = "http://localhost:5275/api/Curso/";

  }

  getAll(): Observable<Curso[]> {

    // debugger

    return this._http.get<Curso[]>(`${this._UrlBase}ObterCursos`);

  }

  get(Id: any): Observable<Curso> {

    // debugger

    return this._http.get<Curso>(`${this._UrlBase}ObterCursoPorId?Id=${Id}`);

  }

  create(data: any): Observable<any> {

    // debugger

    return this._http.post(`${this._UrlBase}AdicionarCurso`, data);

  }

  update(Id: any, data: any): Observable<any> {

    // debugger

    return this._http.put(`${this._UrlBase}AtualizarCurso?Id=${Id}`, data);

  }

  delete(Id: any): Observable<any> {

    // debugger

    return this._http.delete(`${this._UrlBase}ApagarCurso?Id=${Id}`);

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
