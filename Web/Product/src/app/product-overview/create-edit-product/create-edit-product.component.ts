import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from 'src/app/service/data.service';
import { IPriceDetail, IProductDetail } from '../model/product-detail';

@Component({
  selector: 'app-create-edit-product',
  templateUrl: './create-edit-product.component.html',
  styleUrls: ['./create-edit-product.component.scss']
})
export class CreateEditProductComponent implements OnInit {

  public productId:any;
  public productForm: FormGroup;
  public productDetail= <IProductDetail>{};
  public buttonName:string='Create';
  constructor(private router:Router,private activateRoute:ActivatedRoute,private service:DataService,public formBuilder: FormBuilder ) {
    this.productForm = this.formBuilder.group({
      'productName': [''],
      'description': [''],
      'price': [''],
      });
      this.productDetail.priceDetail=<IPriceDetail>{};
   }

  ngOnInit(): void {
    this.activateRoute.params.subscribe(params => {
      if (params["id"]) {
      this.productId = params["id"];
      this.getProductDetailsById();
      this.buttonName='Update';
      }
      });
  }

  public getProductDetailsById(){
    this.service.getRequestById(this.productId).subscribe(response=>{
      this.productDetail=response;
    });
  }

  public createUpdateProductDetail(){
    if(this.buttonName === 'Create'){
      this.productDetail.isActive=true;
      this.productDetail.priceDetail.isActive=true;
     this.service.create(this.productDetail).subscribe(()=>{
      this.redirectToBack();
     });
    }
    else{
      this.service.update(this.productDetail).subscribe(()=>{
        this.redirectToBack();
      });
    }
  }

  public redirectToBack(){
     this.router.navigate(['']);
  }
}
