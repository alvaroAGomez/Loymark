import { UsuariosService } from './../../../Services/usuarios.service';
import { Component, OnInit } from '@angular/core';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import Swal from 'sweetalert2';
import { ModalUsuarioComponent } from '../modal-usuario/modal-usuario.component';

@Component({
  selector: 'app-list-usuarios',
  templateUrl: './list-usuarios.component.html',
  styleUrls: ['./list-usuarios.component.scss']
})
export class ListUsuariosComponent implements OnInit {
  list!: any[];
  columns!: string[];

  order: string = '';
  sortedCollection!: any[];
  reverse: boolean = false;
  pageActual: number = 1;
  resultadoXPagina: number = 5;
  filtro: any;
  options: NgbModalOptions = {
    size: 'lg',
  };


  constructor(private _svcUsuarios: UsuariosService,

    private ngbModal: NgbModal
  ) {

    this._svcUsuarios.actualizado().subscribe((res: any) => {

      this.getUsuarios();
    })
  }

  ngOnInit(): void {
    this.getUsuarios();
  }

  getUsuarios() {
    this._svcUsuarios.getAll().subscribe((res: any) => {
      this.list = res;
      console.log(res);


    })
  }

  setOrder(value: string) {
    if (this.order === value) {
      this.reverse = !this.reverse;
    }
    this.order = value;
  }

  Search() {
    if (this.filtro == "") {
      this.ngOnInit();
    } else {
      this.list = this.list.filter((res: any) => {
        return res.filtro.toLocaleLowerCase().match(this.filtro.toLocaleLowerCase());
      });
    }
  }


  deleteUsuario(id: number) {


    Swal.fire({
      title: 'Borrar Usuario',
      text: '¿Esta seguro de eliminar el Usuario?',
      icon: 'question',
      showCancelButton: true,
      focusConfirm: true,
      confirmButtonText: 'Aceptar',
      cancelButtonText: 'Cancelar',
      confirmButtonColor: '#000000',
      cancelButtonColor: '#f27474',
    }).then((confirm) => {

      if(confirm.isConfirmed){
        this._svcUsuarios.deleteUsuer(id).subscribe((res: any) => {
          console.log(res);
          this.getUsuarios();
          this.showToast("Usuario Eliminado", 'success')
          console.log("todo ok ");
          

        }, (err:any) => {
          this.showToast("No Se pudo eliminar al usuario", 'error')
          console.log("todo mal");
          
        })
      }


    });


  }

  updateUsuario(id: number) {
    const modalRef = this.ngbModal.open(ModalUsuarioComponent, this.options);
    modalRef.componentInstance.modalName = "Actualizar Categoría";
    modalRef.componentInstance.idUsuario = id;
    modalRef.componentInstance.data = this.list.filter(function (usuario) { return usuario.id == id; });

  }

  viewUsuario(id: number) {
    const modalRef = this.ngbModal.open(ModalUsuarioComponent, this.options);
    modalRef.componentInstance.modalName = "Detalle de Categoría";
    modalRef.componentInstance.idUsuario = id;
    modalRef.componentInstance.data = this.list.filter(function (usuario) { return usuario.id == id; });

  }


  
  showToast(titulo:string, icono:any){
    const Toast = Swal.mixin({
      toast: true,
      position: 'top-end',
      showConfirmButton: false,
      timer: 3000,
      timerProgressBar: true,
      didOpen: (toast) => {
        toast.addEventListener('mouseenter', Swal.stopTimer)
        toast.addEventListener('mouseleave', Swal.resumeTimer)
      }
    })
    
    Toast.fire({
      icon: icono,
      title: titulo
    })
  }
}








