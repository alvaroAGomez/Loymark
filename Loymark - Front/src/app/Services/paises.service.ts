import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PaisesService {

  constructor(private _http: HttpClient) {}

  getPaises() {
    return this._http.get('http://country.io/names.json');
  }
  
}
