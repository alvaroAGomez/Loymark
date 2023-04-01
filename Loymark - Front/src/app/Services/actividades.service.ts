import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import {HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ActividadesService {

  private base_endpoint: string = `${environment.api_url}/Actividades`;

  constructor(private _http: HttpClient) {}

  getActividades() {
    return this._http.get(`${this.base_endpoint}`);
  }
}
