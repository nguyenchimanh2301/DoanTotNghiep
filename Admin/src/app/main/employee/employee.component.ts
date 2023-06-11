import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { ApiService } from 'src/app/core/services/api.service';
import { FileUploadService } from 'src/app/core/services/file-upload.service';
import { environment } from 'src/environments/environment';
@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  selectedFile!: File | null;
  categories: any;
  getlsp_id:any
  host = environment.BASE_API;
  page:number = 1;
  count:number = 0;
   public tablesize:number = 5;
  table_numberSize:any = [5,10,15];
  size:any = 5;
  formLSP!:FormGroup
  active=true;
  image:any;
  Mode = '0'
  toast:String = "THÊM"
  title:string = "THÊM NHÂN VIÊN ";
  iscreate = false;
  add_succes = true;
  delete_succes = true;
  
  constructor(private api:HttpClient,public fb:FormBuilder,private apisv:ApiService,private up:FileUploadService) { }

  ngOnInit(): void {
    this.formLSP = new FormGroup({
      'txt_tenlsp': new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
    });
  }
  get tenlsp() {
    return this.formLSP.get('txt_tenlsp')!;
  }
  
 
  // add_Product(item:any){
  //   let obj ={
  //     id : item.id,
  //     tenLoaiPhong: item.txt_tenlsp,
  //     }
  //   if(this.iscreate){
  //     console.log(obj);
  //     this.api.post(this.host+'/add_loaihomestay',obj).subscribe(data => {
  //         this.get();
  //         this.active = true;
  //         this.add_succes=false
  //         setTimeout(()=>{this.add_succes=true;},2000);
  //     })
  //   }
  //   else{
  //     this.api.put(this.host+'/update_loaihomestay',obj).subscribe(data => {
  //       this.get();
  //      this.active = true;
  //      this.toast = "SỬA";
  //      this.add_succes=false
  //      setTimeout(()=>{this.add_succes=true;},2000);})
  //   }
   
   
  // }
  ShowModal(item:any){
  this.title = "SỬA LOẠI HOME STAY"
    this.active = false;
    this.api.get(this.host+'/get_loaihomestay_id?id='+item).subscribe(data=>{
      this.getlsp_id = data;
      this.formLSP = this.fb.group({
        txt_tenlsp:   [this.getlsp_id.tenloai,Validators.required],
        id:         [  this.getlsp_id.id,Validators.required],
      });
      
    });
  }
  update_Product(item:any){
    this.image = document.getElementById('files');
    let obj ={
    id : item.idsp,
    tenLoaiPhong: item.lsp,
    }
    console.log(obj);
    
  }
  DeleteLSP(item:any){
    if(confirm('Are you sure you want to delete')){
      this.api.delete(this.host+'/Delete_loaihomestay?id='+item).subscribe(data => {
        this.delete_succes=false;
        setTimeout(() => {this.delete_succes=true},2000);
       })
    }
    
  }
  sizeChange(event:any):void{
    this.tablesize = event.target.value; debugger
    this.page = 1;
  }
  dataChange(event:any):void{
    this.page = event;
  }
  close(){
    this.active = true;
  }
  Show(value:any){
      if(value==this.Mode){
      this.active=false;
      }
  this.iscreate = true;

  }
  // get():void{
  //   this.api.get(this.host+'/get_all_loaihomestay').subscribe(data=>{
  //     this.categories = data;
  //   });
  // }
  // search(){
  //   let name = (<HTMLInputElement>document.getElementById('searchs')).value;
  //   console.log(name);
  //   this.api.get(this.host+'/earch_Homstay?name=z'+name).subscribe(data=>{
       
  //     this.categories = data;
  //   });
  // }
  // onFileSelected(event: any) {
  //   const files: FileList = event.target.files;
  //       this.selectedFile = files.item(0);
        
  //       if (this.selectedFile) {
  //         const formData = new FormData();
  //         const headers = new HttpHeaders();
  //         headers.append('Content-Type', this.selectedFile.type);
  //         this.api.post(this.host+'/api/FileUpload/api/Upanh', formData, { headers: headers })
  //           .subscribe(
  //             response => {
  //               console.log(response); // Xử lý phản hồi từ API (nếu cần)
  //             },
  //             error => {
  //               console.error(error); // Xử lý lỗi (nếu có)
  //             }
  //           );
  //       } else {
  //         console.error("No file selected.");
  //       }

  //     }
  onFileSelected(event: any): void {
    const file: File = event.target.files[0];
  
    this.up.uploadFile(file)
      .then(response => {
        console.log('File uploaded successfully.');
        // Xử lý phản hồi theo nhu cầu
      })
      .catch(error => {
        console.error('Error uploading file:', error);
        // Xử lý lỗi theo nhu cầu
      });
  }
  
    //   console.log(this.selectedFile);
    //   this.api.post(this.host + '/api/FileUpload/api/Upanh', formData)
    //     .subscribe(
    //       response => {
    //         console.log(response); // Xử lý phản hồi từ API (nếu cần)
    //       },
    //       error => {
    //         console.error(error); // Xử lý lỗi (nếu có)
    //       }
    //     );
    // } else {
    //   console.error("No file selected.");
    // }
  }

  
  
  
  
  
  
  