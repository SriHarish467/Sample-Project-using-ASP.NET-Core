import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateEditProductComponent } from './product-overview/create-edit-product/create-edit-product.component';
import { ProductOverviewComponent } from './product-overview/product-overview/product-overview.component';

const routes: Routes = [
  {
    path:'',
    component:ProductOverviewComponent
  },
  {
    path:'create',
    component:CreateEditProductComponent
  },
  {
    path:'edit/:id',
    component:CreateEditProductComponent
  },
  {
    path:'***',
    redirectTo:''
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
