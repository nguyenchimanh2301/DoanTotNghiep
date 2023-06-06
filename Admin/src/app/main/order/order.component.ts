import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, OnInit,ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { DomSanitizer } from '@angular/platform-browser';
import * as DOMPurify from 'dompurify';
import { htmlToText } from 'html-to-text';
import * as htmlDocx from 'html-docx-js';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {
  @ViewChild('panelBody') panelBody!: ElementRef<HTMLDivElement>;
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
  total:number = 0;
  public htmlContent!: string;
  constructor(private api:HttpClient,private sanitizer: DomSanitizer) { }
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
    this.api.get(this.host+'/get_all_donhang').subscribe(data =>{
      this.order = data;
      console.log(data);
    })
  }
  show(item:any){
    this.modal= false;
    let html:string= "";
    this.orderdetail = false;
    this.api.get(this.host+'/get_chitiet_hoadon?madon='+item.id).subscribe(data =>{
      this.detail_order = data;
      console.log(this.detail_order);
      const formattedDate = new Date(this.detail_order.ngaydat).toLocaleString('vi-VN', { 
        dateStyle: 'short',
        timeStyle: 'short'
      });
      const formattedDate2 = new Date(this.detail_order.ngaytra).toLocaleString('vi-VN', { 
        dateStyle: 'short',
        timeStyle: 'short'
      });
      
      this.total+=this.detail_order.tongthoigiandat*this.detail_order.dongia;
      let formattedPrice = this.total.toLocaleString('vi-VN', { style: 'currency', currency: 'VND' });
      html =` <div class="containers">
    <h1>Hóa đơn Homestay</h1>
    <div class="bill-details">
      <div class="room-details">
        <h2>Thông tin phòng</h2>
        <p>Tên phòng: ${this.detail_order.tenPhong}</p>
        <p>Loại phòng:${this.detail_order.tenLoaiPhong}</p>
        <p>Ngày đặt:${formattedDate}</p>
        <p>Ngày trả:${formattedDate2}</p>
      </div>
      <div class="guest-details">
        <h2>Thông tin khách hàng</h2>
        <p>Họ tên:${ this.detail_order.tenKh}</p>
        <p>Email: ${this.detail_order.email}</p>
        <p>Số điện thoại: ${this.detail_order.sdt}</p>
      </div>
    </div>
    <div class="payment-details">
      <h2>Thông tin thanh toán</h2>
      <p>Tổng tiền:${formattedPrice}</p>
      <p>Phương thức thanh toán: Visa</p>
      <p>Số thẻ: **** **** **** 1234</p>
    </div>
  </div>
  <style>
  .containers {
    max-width: 600px;
    margin: 0 auto;
    padding: 20px;
    font-family: Arial, sans-serif;
  }

  h1 {
    text-align: center;
  }

  .bill-details {
    display: flex;
    justify-content: space-between;
    margin-top: 20px;
  }

  .room-details,
  .guest-details {
    flex-basis: 48%;
  }

  .payment-details {
    margin-top: 20px;
  }

  h2 {
    font-size: 1.2em;
    margin-top: 0;
  }

  p {
    margin-top: 5px;
  }
</style>`
  ;
    const bodys: HTMLElement | null = document.getElementById("bodys");
    // Gán chuỗi HTML vào nội dung của phần tử
    if (bodys) {
      bodys.innerHTML = html;
    }
    })
  }
  close(){
    this.modal= true;

  }
//   OnSubmit(){
//     const htmlContent = this.panelBody.nativeElement.innerHTML;

// // Chuyển đổi HTML thành tệp Word
// const convertedDoc = htmlDocx.asBlob(htmlContent);

// // Tạo URL tải xuống tệp Word
// const url = window.URL.createObjectURL(convertedDoc);

// // Tạo và cấu hình phần tử <a> để tải xuống tệp Word
// const a = document.createElement('a');
// a.href = url;
// a.download = 'output.docx';

// // Thêm phần tử <a> vào body và kích hoạt sự kiện click để tải xuống
// document.body.appendChild(a);
// a.click();

// // Gỡ bỏ phần tử <a> và thu hồi URL
// document.body.removeChild(a);
// window.URL.revokeObjectURL(url);
//   }
  onSubmit() {
    this.htmlContent = this.panelBody.nativeElement.innerHTML;
    const textContent = htmlToText(this.htmlContent);
    const data = { htmlContent: textContent };
    this.api.post(this.host + '/api/word', data, { responseType: 'blob' })
      .subscribe((blob: Blob) => {
        const url = window.URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = url;
        
// Lưu nội dung văn bản vào tệp Word (output.docx)
        a.download = 'output.docx';
        document.body.appendChild(a);
        a.click();
        document.body.removeChild(a);
        window.URL.revokeObjectURL(url);
      });
  }
}
