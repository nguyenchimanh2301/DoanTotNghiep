import { htmlToText } from 'html-to-text';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {
  host = environment.BASE_API;
  page:number = 1;
  count:number = 0;
  public tablesize:number = 5;
  table_numberSize:any = [5,10,15];
  size:any = 5;
  active=true;
  customer:any;
  customerdetail:any;
  email:any;
  send_success = true;
  formMail!:FormGroup
  public Editor = ClassicEditor;

  constructor(private api:HttpClient,private fb:FormBuilder) { }

  ngOnInit(): void {
    
    this.get();
    this.formMail = new FormGroup({
      'tieu_de': new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
      'email': new FormControl('', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
      'noidung': new FormControl('', [Validators.required]),
      
      // 'txt_mota': new FormControl(''),
      // 'txt_soluong': new FormControl('', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
      // 'txt_donvi': new FormControl(''),
      // 'ngaySanxuat': new FormControl(''),
      // 'hanSudung': new FormControl(''),
    });
  }
  get tieude() {
    return this.formMail.get('tieu_de')!;
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
    this.api.get(this.host+'/get_Cus').subscribe(data =>{
      this.customer = data;
      console.log(data);
    })
  }
  Show(){
    this.active = false;
  }
  close(){
    this.active = true;
  }
  Showinfo(item:any){
    this.active = false;
    this.api.get(this.host+'/get_cus_by_id?id='+item).subscribe(data =>{
      this.customerdetail = data;
      console.log(this.customerdetail);
      this.email=this.customerdetail.email;
    })
  }
  SendEmail(val:any):void{

 const textContent = htmlToText(val.noidung);
  let obj : any = {
    "to": this.email,
    "subject": val.tieu_de,
    "body": textContent
  }
  this.api.post(this.host+'/api/Email',obj).subscribe(data => {
    this.active = true;
    setTimeout(()=>{this.send_success=true;},2000);})
    
  };
}
