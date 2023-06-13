import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ReactiveFormsModule} from '@angular/forms';
import { AuthenticationService } from '../core/authentication/authentication.service';
import { first, iif } from 'rxjs';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public frmLogin!:FormGroup;
  public submitted = false;
  public loading = false;
  public returnUrl!:string;
  public hide:any=true;
  public error = '';
  constructor(private auService:AuthenticationService,private router:Router,private route:ActivatedRoute) {
    if(this.auService.userValue){
      this.router.navigate(['/']);
    }
   }

  ngOnInit(): void {
    this.frmLogin = new FormGroup({
      'txt_user': new FormControl('', [Validators.required]),
      'txt_password': new FormControl('', [Validators.required]),
    });
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }
  get taikhoan() {
    return this.frmLogin.get('txt_user')!;
  }
  get matkhau() {
    return this.frmLogin.get('txt_password')!;
  }
  public login(value:any){
    this.submitted = true;
    if(this.frmLogin.invalid){
         return;
    }
    this.loading = true;
    this.auService.login(value.txt_user,value.txt_password)
    .pipe(first()).subscribe(
      (data)=>{
        this.hide=false;
        setTimeout(()=>{this.router.navigate([this.returnUrl]);},3000);

        
      },
      (error)=>{
        this.error = error;
        this.loading = false;
        alert("Sai tên tài khoản hoặc mật khẩu");
      }
    );
  }

}
