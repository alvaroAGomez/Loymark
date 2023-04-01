import { Component, OnInit } from '@angular/core';
import { ActividadesService } from 'src/app/Services/actividades.service';


@Component({
  selector: 'app-actividades',
  templateUrl: './actividades.component.html',
  styleUrls: ['./actividades.component.scss']
})
export class ActividadesComponent implements OnInit{

  list!: any;
  columns!: string[];

  order: string = '';
  sortedCollection!: any[];
  reverse: boolean = false;
  pageActual :number = 1;
  resultadoXPagina:number=5;
  filtro:any;


  constructor(private svc : ActividadesService,
              ){}

  ngOnInit(): void {
    this.svc.getActividades().subscribe(res=>{
      console.log(res);
      this.list = res;
    })
  }


  setOrder(value: string) {
    if (this.order === value) {
      this.reverse = !this.reverse;
    }
    this.order = value;
  }
  
  Search() {
    if(this.filtro==""){
      this.ngOnInit();
    }else{
      this.list = this.list.filter((res:any)=>{
        return res.filtro.toLocaleLowerCase().match(this.filtro.toLocaleLowerCase());
      });
    }
  }
}







