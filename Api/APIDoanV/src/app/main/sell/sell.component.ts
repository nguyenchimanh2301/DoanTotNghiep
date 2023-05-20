import { ApiService } from './../../core/services/api.service';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { environment } from 'src/environments/environment';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';

@Component({
  selector: 'app-sell',
  templateUrl: './sell.component.html',
  styleUrls: ['./sell.component.css']
})
export class SellComponent implements OnInit {
  modal = true;
  product: any;
  products: any=[];
  getproduct_id:any
  host = environment.BASE_API;
  page:number = 1;
  count:number = 0;
   public tablesize:number = 12;
  table_numberSize:any = [5,10,15];
  size:any = 5;
  frmCustomer!:FormGroup
  add_succes=true;
  sum:any;
  category:any;
  load = false;
  name:any;
  dc:any;
  sdt:any;
  public Editor = ClassicEditor;
  constructor(private api:HttpClient,private fb:FormBuilder,private http:ApiService) { }
 
  ngOnInit(): void {
    this.api.get(this.host+'/get_all_category').subscribe(data => {
      this.category = data;
    })
    this.get();
    this.frmCustomer = new FormGroup({
      'txt_name': new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
      'txt_sdt': new FormControl('', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
      'txt_email': new FormControl('', [Validators.email]),
      'txt_address': new FormControl('', [Validators.required]),
      'txt_ghichu': new FormControl('')
    });
  }
  onSubmit(val:any){
    let bill:any = {};
    bill={
      "khach": {
        "id": "string",
        "tenKh": val.txt_name,
        "email": val.txt_email,
        "diaChi": val.txt_address,
        "sdt": val.txt_sdt,
        "note": val.txt_ghichu
      },
      }
      bill.chitiethoadonban=[];
      this.products.forEach((element:any) => {
        bill.chitiethoadonban.push({
          "id": 0,
          "idBillBan": 0,
          "masp": element.id,
          "soluong": element.soLuong,
          "giaban": element.unit_price,
          "idBillBanNavigation": {
            "id": 0,
            "idKh": "string",
            "ngayBan": "2023-01-04T03:59:52.251Z",
            "soHoadon": "string",
            "manguoidung": "string"
          }
        })
      });
      console.log(bill);
    this.api.post('https://localhost:44310/create-hoadonban', bill).subscribe(res=>{
      this.add_succes = false;
    })
    
}
  get hoten() {
    return this.frmCustomer.get('txt_name')!;
  }
  get sodienthoai() {
    return this.frmCustomer.get('txt_sdt')!;
  }
  get email() {
    return this.frmCustomer.get('txt_email')!;
  }
  get diachi() {
    return this.frmCustomer.get('txt_address')!;
  }

  
 
  sizeChange(event:any):void{
    this.tablesize = event.target.value; 
    this.page = 1;
    this. get();
  }
  dataChange(event:any):void{
    this.page = event;
  }
 
 
  get():void{
    this.api.get(this.host+'/get_list_product').subscribe(data=>{
      this.product = data;
      this.load = true;
    });
  }
  search(){
    let name = (<HTMLInputElement>document.getElementById('searchs')).value;
    console.log(name);
    this.api.get(this.host+'/Search?name='+name).subscribe(data=>{
      this.product = data;
    });
  }
  filter(event:any){
    let item:any = event.target.value;
    if(item==0){
      this.get();
    }
    else{
      this.api.get(this.host+'/Search_by_idcategory?id='+item).subscribe(res=>{
        this.product = res;
      })
    }
  }

  public add_order(item: any) {
    if (this.products.length == 0) {
      item.soLuong = 1;
      this.products = [item];
    } else {
      let ok = true;
      for (let x of this.products) {
        if (x.id == item.id) {
          x.soLuong += 1;
          ok = false;
          break;
        }
      }
      if (ok) {
        item.soLuong = 1;
        this.products.push(item);
      }
    }
    // this.tong = this.list_order.reduce((sum: any, x: any) => sum + x.gia * x.soLuong, 0);
  }
  print(){
    this.name = (<HTMLInputElement>document.getElementById('name')).value;
    this.dc = (<HTMLInputElement>document.getElementById('dc')).value;
    this.sdt = (<HTMLInputElement>document.getElementById('sdt')).value;

    this.modal= false;
    this.sum = this.products.reduce((sum:any, x:any) => sum + x.unit_price  * x.soLuong, 0);
  }
  close(){
    this.modal= true;

  }
  remove(item:any){
      var index:number = this.products.findIndex((x: any) => x.id == item);
      if (index >= 0) {
        this.products.splice(index, 1);
    }
  }
  public printHtml() {
     this.name = (<HTMLInputElement>document.getElementById('name')).value;
     this.dc = (<HTMLInputElement>document.getElementById('dc')).value;
     this.sdt = (<HTMLInputElement>document.getElementById('sdt')).value;
    let html_order = '';
    this.products.forEach((x: any) => {
      html_order += `
      <tr>
      <td>1</td>
      <td>${x.name}</td>
      <td>${x.unit_price}</td>
      <td>${x.soLuong}</td>
      <td>${x.unit_price * x.soLuong}</td>
      </tr>
      `;
    });
    let data = `
    <section style="text-align: center;">
        <h1>HÓA ĐƠN GIÁ TRỊ GIA TĂNG</h1>
        <div class="ban">(Bản thể hiện hóa đơn điện tử)</div>
        <div class="ngay">
            <p id="date"></p>
            <script>
                n = new Date();
                y = n.getFullYear();
                m = n.getMonth() + 1;
                d = n.getDate();
                document.getElementById("date").innerHTML = "Ngày " + d + " tháng " + m + " năm " + y;
            </script>
        </div>
    </section>

    <div class="le dam">Tên đơn vị bán hàng: MANH FRESHFOOD</div>
    <div class="le">Mã số thuế: 3269289058</div>
    <div class="le">Địa chỉ: 105 Mai Xá, Kim Động, Hưng Yên</div>
    <div class="le doi">Điện thoại: 0948.098.195</div>
    <div class="le doi">Số tài khoản: 762618652671614</div>
    <div class="le dam">Người mua hàng:${this.name} </div>
    <div class="le">Email: abc@mail.com</div>
    <div class="le">Điện thoại: ${this.sdt}</div>
    <div class="le">Địa chỉ:${this.dc}</div>
    <div class="le doi">Hình thức thanh toán: Tiền mặt / Chuyển khoản</div>
    <div class="le doi">Số tài khoản: 526716147626186</div>
    <div class="le">Ghi chú: </div>
    <table>
        <tr>
            <th>STT</th>
            <th>Tên sản phẩm</th>
            <th>Đơn giá</th>
            <th>Số lượng</th>
            <th>Thành tiền</th>
        </tr>
        ${html_order}
    </table>
    <div class="doi dam ky">Người mua hàng</div>
    <div class="doi dam ky">Người bán hàng</div>
    <div class="doi ky1">(Ký, ghi rõ họ tên)</div>
    <div class="doi ky1">(Ký, ghi rõ họ tên)</div>
    `;

    let popupWin: any = window.open('', '_blank', 'top=0,left=0,height=100%,width=auto,z-index:999');
    popupWin.document.write(`
      <html>
        <head>
          <title>Print tab</title>
          <style>
          .print table {
              margin-top: 15px;
              width: 100%;
          }
          print tr {
              line-height: 27px;
          }
  
          .print table,
          th,
          td {
              border: 1px solid black;
              border-collapse: collapse;
              text-align: center;
          }
  
          .print .ngay {
              font-style: italic;
              font-size: 15px;
              margin-bottom: 5px;
          }
  
          .print .ban {
              font-style: italic;
              font-size: 15px;
              margin: 3px 0px;
          }
  
          .print .dam {
              font-weight: bold;
          }
  
          .print .le {
              margin-bottom: 4px;
              font-size: 15px;
          }
  
          .print .doi {
              width: 50%;
              float: left;
          }
  
          .print .ky {
              text-align: center;
              margin-top: 20px;
          }
  
          .print .ky1 {
              font-style: italic;
              text-align: center;
              margin-top: 5px;
          }
      </style>
        </head>
      <body class='print' onload="window.print();window.close()">${data}</body>
      </html>`
    );
  }
}

