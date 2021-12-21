import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from 'src/app/service/data.service';
//import { ProductDetail } from '../model/product-detail';


@Component({
  selector: 'app-product-overview',
  templateUrl: './product-overview.component.html',
  styleUrls: ['./product-overview.component.scss']
})
export class ProductOverviewComponent implements OnInit {

  public productList:any;
  public displayedColumns: string[] = ['productName', 'description', 'price','action'];
  public dataSource:any[]=[];
  constructor(private service:DataService,private router:Router) { }

  ngOnInit(): void {
    this.getAllProductDetails();
  }

  public getAllProductDetails(){
    this.service.getRequest().subscribe(response=>{
         this.dataSource = response;
    });
  }
 public onClickRedirectToCreatePage(){
      this.router.navigate(['create']);
  }
  public onClickToDeleteProduct(id:any){
    if(confirm("Are you sure to delete")) {
       this.service.delete(id).subscribe(()=>{
         this.getAllProductDetails();
       });
    }
  }
  public onClickToEditProduct(id:any){
    this.router.navigate(['edit/'+id]);
  }
}
