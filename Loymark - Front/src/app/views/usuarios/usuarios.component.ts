import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { Component } from '@angular/core';
import { ModalUsuarioComponent } from './modal-usuario/modal-usuario.component';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.scss']
})
export class UsuariosComponent {

  options: NgbModalOptions = {
    size: 'lg',
  };


  constructor(
    private ngbModal: NgbModal
  ){}

  nuevoUsuario(){
  
    const modalRef = this.ngbModal.open(ModalUsuarioComponent, this.options);
    modalRef.componentInstance.modalName = "Nuevo  Usuario";

    
  }
}
