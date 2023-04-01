import { formatDate } from '@angular/common';
import { PaisesService } from './../../../Services/paises.service';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { UsuariosService } from 'src/app/Services/usuarios.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-modal-usuario',
  templateUrl: './modal-usuario.component.html',
  styleUrls: ['./modal-usuario.component.scss'],
})
export class ModalUsuarioComponent implements OnInit {
  @Input() modalName: any;
  @Input() formCategory!: FormGroup;
  @Input() data: any = null;

  paises: any;

  constructor(
    public activeModal: NgbActiveModal,
    private _userService: UsuariosService
  ) {}

  ngOnInit(): void {
    this.formCategory = this.createFormGroup();

    if (this.data != null) {
      this.nombre!.setValue(this.data[0].nombre);
      this.apellido!.setValue(this.data[0].apellido);
      this.email!.setValue(this.data[0].email);
      this.fecha_nacimiento!.setValue(
        formatDate(this.data[0]?.fechaNacimiento, 'yyyy-MM-dd', 'en')
      );
      this.telefono!.setValue(this.data[0].telefono);
      this.PaisReferencia!.setValue(this.data[0].paisReferencia);
      this.recibir_info!.setValue(this.data[0].recibirInfo);
    }
  }

  createFormGroup() {
    return new FormGroup({
      nombre: new FormControl('', [Validators.required]),
      apellido: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required]),
      fecha_nacimiento: new FormControl('', [Validators.required]),
      telefono: new FormControl(''),
      PaisReferencia: new FormControl('', [Validators.required]),
      recibir_info: new FormControl(false, [Validators.required]),
    });
  }

  get nombre() {
    return this.formCategory.get('nombre');
  }
  get apellido() {
    return this.formCategory.get('apellido');
  }
  get email() {
    return this.formCategory.get('email');
  }
  get fecha_nacimiento() {
    return this.formCategory.get('fecha_nacimiento');
  }
  get telefono() {
    return this.formCategory.get('telefono');
  }
  get PaisReferencia() {
    return this.formCategory.get('PaisReferencia');
  }
  get recibir_info() {
    return this.formCategory.get('recibir_info');
  }

  close() {
    this.activeModal.close();
  }

  onSubmit(value: any) {
    console.log({ value });
    if (this.data != null) {
      this.update(value);
    } else {
      this.save(value);
    }
  }

  save(values: any) {
    values.fecha_nacimiento = new Date(values.fecha_nacimiento);
    values.FechaNacimiento = new Date(values.fecha_nacimiento);
    console.log(values);
    this._userService.newUser(values).subscribe((res) => {

    this.showToast("Usuario Creado con Exito", 'success')



      this.activeModal.close();
      this._userService.UpdateOk('Creación con Éxito!');
    },err=>{
      this.showToast("No Se pudo crear al usuario", 'error')
    });
  }

  update(values: any) {
    values.id = this.data[0].id;
    values.FechaNacimiento = new Date(values.fecha_nacimiento);

    this._userService.updateUser(values.id, values).subscribe((res) => {
      this.showToast("Usuario Actualizado con Exito", 'success')
      this.activeModal.close();
      this._userService.UpdateOk('Actualización con Éxito!');
    },err=>{
      this.showToast("No Se pudo actualizar al usuario", 'error')

    });
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
