import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {
  host = environment.BASE_API;
  page:number = 1;
  count:number = 0;
  public tablesize:number = 5;
  table_numberSize:any = [5,10,15];
  size:any = 5;
  active=true;
  order:any;
  khach:any;
  detail_order:any;
  orderdetail=true;
  modal = true;
  total:number = 0;;
  constructor(private api:HttpClient) { }
  ngOnInit(): void {
    this.get()
  }
  sizeChange(event:any):void{
    this.tablesize = event.target.value; 
    this.page = 1;
    this. get();
  }
  dataChange(event:any):void{
    this.page = event;
  }
  get(){
    this.api.get(this.host+'/get_all_hoadon').subscribe(data =>{
      this.order = data;
      console.log(data);
    })
  }
  show(item:any){
    this.modal= false;
    this.orderdetail = false;
    this.api.get(this.host+'/get_chitiet_hoadon?madonhang='+item.maDonHang).subscribe(data =>{
      console.log(item.maDonHang);
      this.detail_order = data;
      this.detail_order.map((item:any) =>{
        this.total+=item.soLuong*item.giaMua;
      })
      console.log(this.detail_order);
    })
  }
  close(){
    this.modal= true;

  }
}
