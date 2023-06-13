import { Role } from './../../../entities/role';
import { Component, OnInit } from '@angular/core';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { AuthenticationService } from 'src/app/core/authentication/authentication.service';
@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})

export class SidebarComponent implements OnInit {
  hide = true;
  public user: any;
  constructor(private authe:AuthenticationService) { }

  ngOnInit(): void {
    this.user = JSON.parse(localStorage.getItem('user')|| '{}');
    console.log(this.user.role);
    // if(this.user.role=="admin"){
    // this.hide = false;
    // }
  }
  logout(){
    this.authe.logout();
   
  }
  
}
