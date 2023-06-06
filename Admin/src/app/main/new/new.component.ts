import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ApiService } from 'src/app/core/services/api.service';
import { FileUploadService } from 'src/app/core/services/file-upload.service';
import { environment } from 'src/environments/environment';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { CKEditorComponent } from '@ckeditor/ckeditor5-angular';
import { htmlToText } from 'html-to-text';

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
  title:any = "THÊM";
  formTT!:FormGroup
  active=true;
  actived=true;
  image:any;
  add_succes = true;
  delete_succes = true;
  iscreated:any = false;
  category:any;
  load = false;
  public file: any;
  public Editor = ClassicEditor;
  public ckEditorInstance: any;
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
      'noidung': new FormControl('', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
      'id': new FormControl('', []),
    
    });
  }
 
  get tieude() {
    return this.formTT.get('tieude')!;
  }
  get noidung() {
    return this.formTT.get('noidung')!;
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
      onEditorReady(event: any) {
        this.ckEditorInstance = event.editor;
       const textContent = this.ckEditorInstance.getData();

      }
    
  add_Product(item:any){
    this.image = document.getElementById('files');
    let currd = new Date();
    // const inputDate: string = (document.getElementById("date") as HTMLInputElement).value; 
    // const formattedDate = moment(inputDate, "YYYY-MM-DD");
    // Truy cập đến CKEditor thông qua CKEditorComponent


// Sử dụng câu lệnh để lấy nội dung văn bản
const textContent = htmlToText(item.noidung);
     let obj ={
        "idbaiviet": item.id,
        "iduser": 0,
        "anh": this.selectedFile?.name,
        "tieude": item.tieude,
        "noidung": textContent,
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
       this.title= "CẬP NHẬT";
       this.add_succes=false
       setTimeout(()=>{this.add_succes=true;},2000);})
    }
  }
  ShowModal(item:any){
    this.active= false;
    this.api.get(this.host+'/getbv_by_id?id='+item.idbaiviet).subscribe(data=>{
      this.getid = data;
      this.formTT = this.fb.group({
        id:   [this.getid.idbaiviet,Validators.required],
        tieude:   [this.getid.tieude,Validators.required],
        noidung:         [this.getid.noidung,Validators.required],

      });
      
    });
  }
 
  
  DeleteProduct(item:any){
    if(confirm('bạn có muốn xóa bài viết'+item.tieude)){
      this.api.delete(this.host+'/Delete_baiviet?id='+item.idbaiviet).subscribe(data => {
        this.delete_succes=false;
        console.log(item.id);
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
      this.iscreated = true;
      this.formTT = this.fb.group({
        tieude   : [''],
        noidung:   [''],
        
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
    this.api.get(this.host+'/Search_baiviet?name='+name).subscribe(data=>{
      this.product = data;
      console.log(this.product);
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






