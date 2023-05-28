
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../core/services/api.service';
import { Component, ElementRef, OnInit ,ViewChild } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { UploadService } from './../../core/services/image.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],

})
export class ProductComponent implements OnInit {
  selectedFile: File | null = null;
  product: any;
  getproduct_id:any
  host = environment.BASE_API;
  page:number = 1;
  count:number = 0;
   public tablesize:number = 5;
  table_numberSize:any = [5,10,15];
  size:any = 5;
  formSP!:FormGroup
  Iscreated:any=true;
  active=true;
  actived=true;
  image:any;
  add_succes = true;
  delete_succes = true;
  title:any = "THÊM";
  category:any;
  load = false;
  public file: any;
  public Editor = ClassicEditor;
  constructor(private api:HttpClient,private fb:FormBuilder,private apisv:ApiService ,private uploads:UploadService) { }
 
  ngOnInit(): void {
    this.api.get(this.host+'/get_all_loaihomestay').subscribe(data => {
      this.category = data;
    })
    this.get();
    this.formSP = new FormGroup({
      'tenPhong': new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
      'dongia': new FormControl('', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
      'lsp': new FormControl('', [Validators.required]),
      'txt_mota': new FormControl(''),
      'txt_soluong': new FormControl('', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
      'txt_donvi': new FormControl(''),
      'ngaySanxuat': new FormControl(''),
      'hanSudung': new FormControl(''),
    });
  }



 
  get tenPhong() {
    return this.formSP.get('tenPhong')!;
  }
  get giatien() {
    return this.formSP.get('dongia')!;
  }
  get mota() {
    return this.formSP.get('txt_mota')!;
  }
  get soluong() {
    return this.formSP.get('txt_soluong')!;
  }
  
  get donvi() {
    return this.formSP.get('txt_donvi')!;
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
    id :item.id,
    tenPhong: item.tenPhong,
    idloaiPhong: 1,
    anh :this.image.files[0].name,
    dongia : item.dongia,
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
    if(this.Iscreated==true){
      this.api.post(this.host+'/add_homestay',obj).subscribe(data => {
        this.active = true;
        this.add_succes=false
        setTimeout(()=>{this.add_succes=true;},2000);})
    }
    else{
      this.api.put(this.host+'/update_homestay',obj).subscribe(data => {
        this.get();
       this.actived = true;
       this.add_succes=false
       setTimeout(()=>{this.add_succes=true;},2000);})
    }
  }
  ShowModal(item:any){
    this.Iscreated=false;
    this.title = "Sửa"
    this.active= false;
    this.api.get(this.host+'/getht_by_id?id='+item).subscribe(data=>{
      this.getproduct_id = data;
      this.formSP = this.fb.group({
        id:   [this.getproduct_id.id,Validators.required],
        tenPhong:   [this.getproduct_id.ten,Validators.required],
        lsp:         [this.getproduct_id.idloai,Validators.required],
        dongia: [this.getproduct_id.dongia,Validators.required],
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

  DeleteProduct(item:any){
    if(confirm('bạn có muốn xóa homestay'+item.ten)){
      this.api.delete(this.host+'/Delete_homestay?id='+item.id).subscribe(data => {
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
    this.actived = true;
  }
  Show(value:any){
      this.active=false;
      this.formSP = this.fb.group({
        txt_tensp   : [''],
        lsp:         [''],
        txt_giatien: [''],
        txt_mota:    [''],
        txt_soluong: [''],
        txt_donvi:   [''],
        ngaySanxuat: [''] ,
        hanSudung:   ['']
      });
  }
  get():void{
    this.api.get(this.host+'/get_all_homestay').subscribe(data=>{
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
