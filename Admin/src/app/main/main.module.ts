import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { MainRoutes } from './main.routes';
import { MainComponent } from './main.component';
import { IndexComponent } from './index/index.component';
import { ProductComponent } from './homestay/product.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { CategoryComponent } from './category/category.component';
import { OrderComponent } from './order/order.component';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { CustomerComponent } from './customer/customer.component';
import { SellComponent } from './sell/sell.component';
import { DetailbillComponent } from './detailbill/detailbill.component';
import { AccountComponent } from './account/account.component';
import { NewComponent } from './new/new.component';
import { EmployeeComponent } from './employee/employee.component';
@NgModule({
    declarations:
     [MainComponent, IndexComponent, ProductComponent, CategoryComponent, OrderComponent, CustomerComponent, SellComponent, DetailbillComponent, AccountComponent, NewComponent, EmployeeComponent],
    imports: [
        CommonModule,
        SharedModule,
        RouterModule.forChild(MainRoutes),
        NgxPaginationModule,
        FormsModule,
        ReactiveFormsModule,
        CKEditorModule,
        
    ]
})
export class MainModule { }