import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { ApiService } from 'src/app/core/services/api.service';
import { FileUploadService } from 'src/app/core/services/file-upload.service';
import { environment } from 'src/environments/environment';
@Component({
  selector: 'app-new',
  templateUrl: './new.component.html',
  styleUrls: ['./new.component.css']
})
export class NewComponent implements OnInit {

  selectedFile!: File | null;
  product: any;
  getid:any
  host = environment.BASE_API;
  page:number = 1;
  count:number = 0;
   public tablesize:number = 5;
  table_numberSize:any = [5,10,15];
  size:any = 5;
  title:any = 5;
  formTT!:FormGroup
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
  constructor(private api:HttpClient,private fb:FormBuilder,private apisv:ApiService,private filesv:FileUploadService ) {
   }
   
  ngOnInit(): void {

    this.get();

    this.api.get(this.host+'/get_all_loaihomestay').subscribe(data => {
      this.category = data;
    })
    this.formTT = new FormGroup({
      'tieude': new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
      'matkhau': new FormControl('', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
      'loaiquyen': new FormControl('', [Validators.required]),
      'trangthai': new FormControl(''),
    });
  }
  get tieude() {
    return this.formTT.get('tieude')!;
  }
  get noidung() {
    return this.formTT.get('matkhau')!;
  }
  get trangthai() {
    return this.formTT.get('trangthai')!;
  }
  get loaiquyen() {
    return this.formTT.get('loaiquyen')!;
  }
  
  onFileSelected(event: any) {
    const files: FileList = event.target.files;
        this.selectedFile = files.item(0);
        if (this.selectedFile) {
          const formData = new FormData();
          formData.append('file', this.selectedFile);
          this.api.post(this.host+'/api/FileUpload/api/Upanh', formData)
            .subscribe(
              response => {
                console.log(response); // Xử lý phản hồi từ API (nếu cần)
              },
              error => {
                console.error(error); // Xử lý lỗi (nếu có)
              }
            );
        } else {
          console.error("No file selected.");
        }



      }
  
  // onFileSelected(event: any) {
  //   const file: File = event.target.files[0];
  //   console.log(file);
  //   this.apisv.uploadFiles(file).subscribe(
  //     response => {
  //       // Xử lý kết quả thành công
  //       console.log('Upload thành công:', response);
  //     },
  //     error => {
  //       // Xử lý lỗi nếu có
  //       console.log('Lỗi upload:', error);
  //     }
  //   );
  // }

  add_Product(item:any){
    this.image = document.getElementById('files');
    let currd = new Date();
    // const inputDate: string = (document.getElementById("date") as HTMLInputElement).value; 
    // const formattedDate = moment(inputDate, "YYYY-MM-DD");
    let obj ={
        "idbaiviet": 0,
        "iduser": 0,
        "anh": this.selectedFile?.name,
        "tieude": item.tieude,
        "noidung": item.noidung,
        "ngaydangbai": currd,
    }
    console.log(obj);
    if(this.iscreated==true){
      this.api.post(this.host+'/add_baiviet',obj).subscribe(data => {
        this.active = true;
        this.add_succes=false
        setTimeout(()=>{this.add_succes=true;},2000);})
    }
    else{
      this.api.put(this.host+'/update_baiviet',obj).subscribe(data => {
        this.get();
       this.active = true;
       this.add_succes=false
       setTimeout(()=>{this.add_succes=true;},2000);})
    }
  }
  ShowModal(item:any){
    this.active= false;
    this.api.get(this.host+'/get_acc_byid?id='+item).subscribe(data=>{
      this.getid = data;
      this.formTT = this.fb.group({
        // id:   [this.getproduct_id.maTaiKhoan,Validators.required],
        // taikhoan:   [this.getproduct_id.taiKhoan,Validators.required],
        // matKhau:         [this.getproduct_id.matKhau,Validators.required],
        // loaiquyen: [this.getproduct_id.loaiQuyen,Validators.required],
        // trangthai: [this.getproduct_id.trangThai,Validators.required],

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
      
      }
    console.log(obj);
   
  }
  DeleteProduct(item:any){
    if(confirm('bạn có muốn xóa bài viết'+item.tieude)){
      this.api.delete(this.host+'/Delete_baiviet?id='+item.id).subscribe(data => {
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
      this.formTT = this.fb.group({
        tieude   : [''],
        noidung:         [''],
        loaiquyen: [''],
        trangthai:    [''],
        txt_soluong: [''],
    
      });
  }
  get():void{
    this.api.get(this.host+'/get_all_baiviet').subscribe(data=>{
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




  
function moment(inputDate: string, arg1: string) {
  throw new Error('Function not implemented.');
}

