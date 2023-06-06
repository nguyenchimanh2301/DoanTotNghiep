import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  public host = environment.BASE_API;
  public product:any;
  public customer:any;
  public order:any;
  public sum:any;
  public count:any;
  public countkh:any;
  public countdh:any;
  public counttt:any =0;

  constructor(private api:HttpClient) { }

  ngOnInit(): void {
    this.api.get(this.host+'/get_all_homestay').subscribe(data=>{
      this.product = data;
      for (let index = 0; index < this.product.length; index++) {
        this.count = index;        
      }
    });
    this.api.get(this.host+'/get_Cus').subscribe(data =>{
      this.customer = data;
      this.countkh =   this.customer.length;        
    })
    this.api.get(this.host+'/get_all_donhang').subscribe(data =>{
      this.order = data;
      console.log(this.order);
      this.countdh =   this.order.length;  
      });   
      this.api.get(this.host+'/get_all_ctdonhang').subscribe(data =>{
        this.sum = data;
        console.log(this.sum);
        console.log(this.counttt);
         this.sum.forEach((element:any) => {
          this.counttt += element.dongia;
        });
        });     
  }

}
