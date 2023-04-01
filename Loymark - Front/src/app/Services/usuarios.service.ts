import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  private base_endpoint: string = `${environment.api_url}/Usuarios`;

  seActualizo$ = new EventEmitter();
  constructor(private _http: HttpClient) {}

  getAll() {
    return this._http.get(`${this.base_endpoint}`);
  }

  getById(id:number){
    return this._http.get(`${this.base_endpoint}/${id}`);
  }

  newUser(user:any){
    return this._http.post(`${this.base_endpoint}`, user);
  }

  updateUser(id:number, user:any){
    return this._http.put(`${this.base_endpoint}/${id}`, user);
  }

  
  deleteUsuer(id:number){
    return this._http.delete(`${this.base_endpoint}/${id}`);;
  }

  actualizado(){
    return this.seActualizo$.asObservable();
  }

  UpdateOk(msj: string){
    this.seActualizo$.next(msj);
  }
}
