
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../core/services/api.service';
import { Component, ElementRef, OnInit ,ViewChild } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],

})
export class ProductComponent implements OnInit {
  File:any;
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
  color:any ;
  nameanh:any ;

  load = false;
  public file: any;
  public Editor = ClassicEditor;
  public selectedOption!: number;
  @ViewChild('fileInput') fileInput: any;
  constructor(private api:HttpClient,private fb:FormBuilder,private apisv:ApiService ) { }
 
  ngOnInit(): void {
    this.api.get(this.host+'/get_all_loaihomestay').subscribe(data => {
      this.category = data;
      
    })
    this.get();
    this.formSP = new FormGroup({
      'ten_Phong': new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
      'don_gia': new FormControl('', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
      'lsp': new FormControl('', [Validators.required]),
      'dia_chi': new FormControl('', [Validators.required]),
      
      // 'txt_mota': new FormControl(''),
      // 'txt_soluong': new FormControl('', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
      // 'txt_donvi': new FormControl(''),
      // 'ngaySanxuat': new FormControl(''),
      // 'hanSudung': new FormControl(''),
    });
  }
 
  get tenPhong() {
    return this.formSP.get('ten_Phong')!;
  }
  get giatien() {
    return this.formSP.get('don_gia')!;
  }
  get mota() {
    return this.formSP.get('txt_mota')!;
  }
  get diachi() {
    return this.formSP.get('dia_chi')!;
  }
  
  get donvi() {
    return this.formSP.get('txt_donvi')!;
  }


  onFileSelected(event: any) {
  const files: FileList = event.target.files;
  this.file = files.item(0);
  this.nameanh = this.file.name;
  const formData = new FormData();
  formData.append('file', this.file);
  this.api.post('https://localhost:44310/api/Uphomestay', formData, {
    reportProgress: true,
    responseType: 'json'})
    .toPromise()
    .then(res => {
      console.log("ok");
    },
    err => {
      console.log(err);
    });
}



  
   

  add_Product(item:any){

    let obj ={
    id :item.id,
    tenPhong: item.ten_Phong,
    idloaiPhong: this.selectedOption,
    anh :this.nameanh,
    diaChi: item.dia_chi,
    dongia : item.don_gia,
    trangthai: false,
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
        this.get();
        this.active = true;
        this.add_succes=false
        setTimeout(()=>{this.add_succes=true;},2000);})
    }
    else{
      this.api.put(this.host+'/update_homestay',obj).subscribe(data => {
        this.get();
       this.active = true;
       this.add_succes=false
       setTimeout(()=>{this.add_succes=true;},2000);})
    }
  }
  ShowModal(item:any){
    this.Iscreated=false;
    this.title = "Sửa"
    this.active= false;
    this.api.get(this.host+'/getht_by_id?id='+item).subscribe(data=>{
      console.log(item);
      this.getproduct_id = data;
      console.log(this.getproduct_id);
      this.formSP = this.fb.group({
        id:   [this.getproduct_id.id,Validators.required],
        ten_Phong:   [this.getproduct_id.tenPhong,Validators.required],
        lsp:         [this.getproduct_id.idloaiPhong,Validators.required],
        don_gia: [this.getproduct_id.dongia,Validators.required],
        dia_chi: [this.getproduct_id.diaChi,Validators.required],

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
      this.title="THÊM";
     if(value==0){
      this.formSP = this.fb.group({
        ten_Phong   : [''],
        lsp:         [''],
        don_gia: [''],
        dia_chi:    [''],
        // txt_soluong: [''],
        // txt_donvi:   [''],

      });
     }
  }
  get():void{
    this.api.get(this.host+'/get_all_homestay').subscribe(data=>{
      this.product = data;
       
      this.product.forEach((element:any) => {
        if(element.trangthai==false){
          this.color="btn-warning"
        }
        else{
          this.color="btn-success";
        }
      });
      
      this.load = true;
    });
  }
  search(){
    let name = (<HTMLInputElement>document.getElementById('searchs')).value;
    console.log(name);
    this.api.get(this.host+'/Search_Homstay?name='+name).subscribe(data=>{
      this.product = data;
    });
  }
  filter(event:any){
    let item:any = event.target.value;
    if(item==0){
      this.get();
    }
    else{
      this.api.get(this.host+'/get_all_homestay_by_idloai?id='+item).subscribe(res=>{
        this.product = res;
      })
    }
  }
}
