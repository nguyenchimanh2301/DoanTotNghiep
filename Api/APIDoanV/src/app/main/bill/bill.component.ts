// import { Component, OnInit } from '@angular/core';
// import { FormGroup } from '@angular/forms';
// import { environment } from 'src/environments/environment';

// @Component({
//   selector: 'app-bill',
//   templateUrl: './bill.component.html',
//   styleUrls: ['./bill.component.css']
// })
// export class BillComponent implements OnInit {

//   product: any;
//   getproduct_id:any
//   host = environment.BASE_API;
//   page:number = 1;
//   count:number = 0;
//    public tablesize:number = 5;
//   table_numberSize:any = [5,10,15];
//   size:any = 5;
//   formBill!:FormGroup
//   active=true;
//   image:any;
//   add_succes = true;
//   delete_succes = true;
//   Mode = '0'
//   category:any;
//   constructor(private api:HttpClient,private fb:FormBuilder) { }

//   ngOnInit(): void {
//     this.api.get(this.host+'/get_all_category').subscribe(data => {
//       this.category = data;
//     })
//     this.get();
//     this.formSP = new FormGroup({
//       'txt_tensp': new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
//       'txt_giatien': new FormControl('', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
//       'txt_email': new FormControl('', [Validators.email]),
//       'lsp': new FormControl('', [Validators.required]),
//       'txt_mota': new FormControl(''),
//       'txt_soluong': new FormControl('', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
//       'txt_donvi': new FormControl(''),
//       'ngaySanxuat': new FormControl(''),
//       'hanSudung': new FormControl(''),
//       'idsp': new FormControl(''),
//     });
//   }
//   get tensp() {
//     return this.formSP.get('txt_tensp')!;
//   }
//   get giatien() {
//     return this.formSP.get('txt_giatien')!;
//   }
//   get mota() {
//     return this.formSP.get('txt_mota')!;
//   }
//   get soluong() {
//     return this.formSP.get('txt_soluong')!;
//   }
  
//   get donvi() {
//     return this.formSP.get('txt_donvi')!;
//   }
//   add_Product(item:any){
    
//     this.image = document.getElementById('files');
//     let obj ={
//     ID:" ",
//     name: item.txt_tensp,
//     idLoaiSp: item.lsp.trim(),
//     idNcc: "2",
//     motaSp: item.txt_mota,
//     unitPrice: item.txt_giatien,
//     soLuong: item.txt_soluong,
//     image :this.image.files[0].name,
//     donViTinh: item.txt_donvi,
//     ngaySanxuat:item.ngaySanxuat,
//     hanSudung:item.hanSudung,
//     }
//     console.log(obj);
//     this.api.post(this.host+'/add_Sp',obj).subscribe(data => {
//       this.get();
//      this.active = true;
//      this.add_succes=false
//      setTimeout(()=>{this.add_succes=true;},2000);})
//   }
//   ShowModal(item:any){
//     this.active = false;
//     this.api.get(this.host+'/get_by_id?id='+item).subscribe(data=>{
//       this.getproduct_id = data;
//       this.formSP = this.fb.group({
//         txt_tensp:   [this.getproduct_id.name,Validators.required],
//         lsp:         [this.getproduct_id.id_loai_sp,Validators.required],
//         txt_giatien: [this.getproduct_id.unit_price,Validators.required],
//         txt_mota:    [this.getproduct_id.motaSp,Validators.required],
//         txt_soluong: [this.getproduct_id.so_luong,Validators.required],
//         txt_donvi:   [this.getproduct_id.donViTinh,Validators.required],
//         ngaySanxuat: [this.getproduct_id.ngaySanxuat,Validators.required],
//         hanSudung:   [this.getproduct_id.hanSudung,Validators.required],
//       });
      
//     });
//   }
//   update_Product(item:any){
//     this.image = document.getElementById('files');
//     let obj ={
//     Id : item.idsp,
//     name: item.txt_tensp,
//     idLoaiSp: item.lsp,
//     idNcc: "2",
//     motaSp: "abcd",
//     unitPrice: item.txt_giatien,
//     soLuong: item.txt_soluong,
//     image :this.image.files[0].name,
//     donViTinh: item.txt_donvi,
//     ngaySanxuat:item.ngaySanxuat,
//     hanSudung:item.hanSudung,
//     }
//     console.log(obj);
//     this.api.post(this.host+'/add_Sp',obj).subscribe(data => {
//       this.get();
//      this.active = true;
//      this.add_succes=false
//      setTimeout(()=>{this.add_succes=true;},2000);})
//   }
//   DeleteProduct(item:any){
//     if(confirm('Are you sure you want to delete')){
//       this.api.delete(this.host+'/Delete_Sp?id='+item).subscribe(data => {
//         this.delete_succes=false;
//         setTimeout(() => {this.delete_succes=true},2000);
//         this.get();
//        })
//     }
    
//   }
//   sizeChange(event:any):void{
//     this.tablesize = event.target.value; debugger
//     this.page = 1;
//     this. get();
//   }
//   dataChange(event:any):void{
//     this.page = event;
//   }
//   close(){
//     this.active = true;
//   }
//   Show(value:any){
//       if(value==this.Mode){
//       this.active=false;
//       }
//       this.formSP = this.fb.group({
//         txt_tensp   : [''],
//         lsp:         [''],
//         txt_giatien: [''],
//         txt_mota:    [''],
//         txt_soluong: [''],
//         txt_donvi:   [''],
//         ngaySanxuat: [''] ,
//         hanSudung:   ['']
//       });
//   }
//   get():void{
//     this.api.get(this.host+'/').subscribe(data=>{
//       this.product = data;
//     });
//   }
//   // search(){
//   //   let name = (<HTMLInputElement>document.getElementById('searchs')).value;
//   //   console.log(name);
//   //   this.api.get(this.host+'/Search?name='+name).subscribe(data=>{
//   //     this.product = data;
//   //   });
//   // }
  
// }

