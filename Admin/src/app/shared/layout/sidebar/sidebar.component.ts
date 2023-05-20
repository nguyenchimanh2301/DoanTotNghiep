import { Component, OnInit } from '@angular/core';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { AuthenticationService } from 'src/app/core/authentication/authentication.service';
@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})

export class SidebarComponent implements OnInit {
  hide = false;
  constructor(private authe:AuthenticationService) { }

  ngOnInit(): void {
  }
  logout(){
    this.authe.logout();
  }
  
}
