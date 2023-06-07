import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { DecimalPipe } from '@angular/common';

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
  selectedDate: string = '';
  selectedMonth: number = 0;
  selectedYear: number = 0;
  
  constructor(private api:HttpClient,private decimalPipe: DecimalPipe) { }

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
  //code logic
  calculateTotal(): string {
    const filteredInvoices = this.order.filter((invoice: any) => {
      const invoiceDate = new Date(invoice.ngaytra);
      const selectedDate = new Date(this.selectedDate);
      // So sánh ngày bằng cách so sánh năm, tháng và ngày
      return (
        invoiceDate.getFullYear() === selectedDate.getFullYear() &&
        invoiceDate.getMonth() === selectedDate.getMonth() &&
        invoiceDate.getDate() <= selectedDate.getDate()
      );
    });
  
    const totalAmount = filteredInvoices.reduce((total: number, invoice: any) => {
      console.log(invoice.thanhtien);
      const numbers = invoice.thanhtien.split(/\s+/); // Tách chuỗi thành mảng các số bằng khoảng trắng
      const validNumbers = numbers.filter((num: any) => !isNaN(parseFloat(num))); // Lọc bỏ các giá trị không phải số
      validNumbers.forEach((num: any) => {
        total += parseFloat(num);
      });
      return total;
    }, 0);
  
    return totalAmount;
  
    // Định dạng totalAmount bằng DecimalPipe
    
  }















  
  calculateTotal1(): number {
    const filteredInvoices = this.order.filter((invoice: any) => {
      const invoiceDate = new Date(invoice.ngaydat);
      return (
        invoiceDate.getMonth() + 1 === this.selectedMonth &&
        invoiceDate.getFullYear() === this.selectedYear
      );
    });
  
    const totalAmount = filteredInvoices.reduce((total: number, invoice: any) => {
      console.log(invoice.thanhtien);
      const numbers = invoice.thanhtien.split(/\s+/); // Tách chuỗi thành mảng các số bằng khoảng trắng
      const validNumbers = numbers.filter((num: any) => !isNaN(parseFloat(num))); // Lọc bỏ các giá trị không phải số
      validNumbers.forEach((num: any) => {
        total += parseFloat(num);
      });
      return total;
    }, 0);
  
    return totalAmount;
  }
  
    //luu í:
    
}
