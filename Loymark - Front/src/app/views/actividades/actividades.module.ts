import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ActividadesRoutingModule } from './actividades-routing.module';
import { ActividadesComponent } from './actividades.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CardModule, FormModule, GridModule, TableModule } from '@coreui/angular';
import { Ng2PaginationModule } from 'ng2-pagination';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { NgxPaginationModule } from 'ngx-pagination';
import { IconModule } from '@coreui/icons-angular';


@NgModule({
  declarations: [
    ActividadesComponent
  ],
  imports: [
    CommonModule,
    ActividadesRoutingModule,
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
export class ActividadesModule { }
