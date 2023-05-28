
import { ApiService } from '../../core/services/api.service';
import { Component, ElementRef, OnInit ,ViewChild } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { UploadService } from './../../core/services/image.service';
import { Observable } from 'rxjs';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
  selectedFile: File | null = null;
  product: any;
  getproduct_id:any
  host = environment.BASE_API;
  page:number = 1;
  count:number = 0;
   public tablesize:number = 5;
  table_numberSize:any = [5,10,15];
  size:any = 5;
  formAC!:FormGroup
  active=true;
  actived=true;
  image:any;
  add_succes = true;
  delete_succes = true;
  iscreated:any = true;
  category:any;
  load = false;
  public file: any;
  public Editor = ClassicEditor;
  status:any =[{
    'name':'Online',
    'status':true,
  },
  {
    'name':'Offline',
    'status':false,
  }
];
  constructor(private api:HttpClient,private fb:FormBuilder,private apisv:ApiService ,private uploads:UploadService) {
   }

  ngOnInit(): void {
    this.api.get(this.host+'/get_all_loaihomestay').subscribe(data => {
      this.category = data;
    })
    this.get();
    this.formAC = new FormGroup({
      'taikhoan': new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
      'matkhau': new FormControl('', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
      'loaiquyen': new FormControl('', [Validators.required]),
      'trangthai': new FormControl(''),
    });
  }
  get taiKhoan() {
    return this.formAC.get('taikhoan')!;
  }
  get matKhau() {
    return this.formAC.get('matkhau')!;
  }
  get trangthai() {
    return this.formAC.get('trangthai')!;
  }
  get loaiquyen() {
    return this.formAC.get('loaiquyen')!;
  }
 

  onFileSelected(event: any) {
    const file: File = event.target.files[0];
    console.log(file);
    this.apisv.uploadFiles(file).subscribe(
      response => {
        // Xử lý kết quả thành công
        console.log('Upload thành công:', response);
      },
      error => {
        // Xử lý lỗi nếu có
        console.log('Lỗi upload:', error);
      }
    );
  }

  add_Product(item:any){
    this.image = document.getElementById('files');
    let obj ={
        maNguoiDung: "string",
        taiKhoan: item.taikhoan,
        matKhau:  item.matkhau,
        trangThai: Boolean(item.trangthai),
        loaiQuyen: item.loaiquyen
      
    }
    console.log(obj);
    if(this.iscreated==true){
      this.api.post(this.host+'/add_Account',obj).subscribe(data => {
        this.active = true;
        this.add_succes=false
        setTimeout(()=>{this.add_succes=true;},2000);})
    }
    else{
      this.api.put(this.host+'/update_Account',obj).subscribe(data => {
        this.get();
       this.active = true;
       this.add_succes=false
       setTimeout(()=>{this.add_succes=true;},2000);})
    }
  }
  ShowModal(item:any){
    this.active= false;
    this.api.get(this.host+'/get_acc_byid?id='+item).subscribe(data=>{
      this.getproduct_id = data;
      this.formAC = this.fb.group({
        id:   [this.getproduct_id.maTaiKhoan,Validators.required],
        taikhoan:   [this.getproduct_id.taiKhoan,Validators.required],
        matKhau:         [this.getproduct_id.matKhau,Validators.required],
        loaiquyen: [this.getproduct_id.loaiQuyen,Validators.required],
        trangthai: [this.getproduct_id.trangThai,Validators.required],

        // txt_mota:    [this.getproduct_id.motaSp,Validators.required],
        // txt_soluong: [this.getproduct_id.so_luong,Validators.required],
        // txt_donvi:   [this.getproduct_id.donViTinh,Validators.required],
        // ngaySanxuat: [this.getproduct_id.ngaySanxuat,Validators.required],
        // hanSudung:   [this.getproduct_id.hanSudung,Validators.required],
      });
      
    });
  }
  // public upload(event: any) {
  //   if (event.target.files && event.target.files.length > 0) {
  //     this.file = event.target.files[0];
  //     this.apisv.uploadFileSingle('/api/upload/upload', 'sanpham', this.file).subscribe((res: any) => {
  //     });
  //   }
  // }
  update_Product(item:any){
    this.image = document.getElementById('files');
    let obj ={
      id :item.id,
      tenPhong: item.tenPhong,
      idloaiPhong: 1,
      anh :this.image.files[0].name,
      dongia : Number(item.dongia),
      trangthai: true,
      idloaiPhongNavigation: {
        "id": 0,
        "tenLoaiPhong": "string",
        "ngayTao": "2023-05-19T09:19:21.785Z",
        "nguoiTao": "string",
        "ngayCapNhat": "2023-05-19T09:19:21.785Z",
        "nguoiCapNhat": "string"
      }
      }
    console.log(obj);
   
  }
  DeleteProduct(item:any){
    if(confirm('bạn có muốn xóa homestay'+item.ten)){
      this.api.delete(this.host+'/delete_Account?maacc='+item).subscribe(data => {
        this.delete_succes=false;
        setTimeout(() => {this.delete_succes=true},2000);
        this.get();
       })
    }
    
  }
  sizeChange(event:any):void{
    this.tablesize = event.target.value; 
    this.page = 1;
    this. get();
  }
  dataChange(event:any):void{
    this.page = event;
  }
  close(){
    this.active = true;
  }
  Show(value:any){
      this.active=false;
      this.formAC = this.fb.group({
        taikhoan   : [''],
        matkhau:         [''],
        loaiquyen: [''],
        trangthai:    [''],
        txt_soluong: [''],
    
      });
  }
  get():void{
    this.api.get(this.host+'/get_all_account').subscribe(data=>{
      this.product = data;
      console.log(data)
      this.load = true;
    });
  }
  search(){
    let name = (<HTMLInputElement>document.getElementById('searchs')).value;
    console.log(name);
    this.api.get(this.host+'/Search_LoaiHomstay?name='+name).subscribe(data=>{
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
}

