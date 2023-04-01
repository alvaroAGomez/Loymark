import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsuariosRoutingModule } from './usuarios-routing.module';
import { UsuariosComponent } from './usuarios.component';
import { ListUsuariosComponent } from './list-usuarios/list-usuarios.component';
import { ModalUsuarioComponent } from './modal-usuario/modal-usuario.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CardModule, TableModule, FormModule, GridModule } from '@coreui/angular';
import { NgxPaginationModule } from 'ngx-pagination';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { IconModule } from '@coreui/icons-angular';


@NgModule({
  declarations: [
    UsuariosComponent,
    ListUsuariosComponent,
    ModalUsuarioComponent
  ],
  imports: [
    CommonModule,
    UsuariosRoutingModule,
    ReactiveFormsModule,
    CardModule,
    TableModule,
    FormModule,
    GridModule,
    FormsModule,
    NgxPaginationModule,
    Ng2SearchPipeModule,
    IconModule
  ]
})
export class UsuariosModule { }
