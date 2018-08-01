import { Component, OnInit } from '@angular/core';
import {Product} from "../app/shared/models/product.modle"
import { ProductService } from './shared/services/Productservice.service';
import { ProductListclass } from './shared/models/productList.modle';
import { timeout } from 'q';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  
 
  productList:ProductListclass=new ProductListclass()
  ShowProductList:boolean;

  ResponsMassage:string="AAA";

  DidPostWork:string="show post result";

  DidPutWork:string="show put result"



  getAllProducts():void{
  this.myProductService.InitProducts()
  this.ShowProductList=true;
  console.log(this.productList.productsArry)
  
  }

  getSpesificPeoduct(param:string):void{
    this.myProductService.SetSpecificProduct(param)
    console.log(this.productList.singleProduct)   
  }


   Productname2:string="Sprit"
  DeleteProduct(productname:string){
    alert("delte funk")
    this.myProductService.DeleteProduct(this.Productname2).subscribe(
      (res)=>{
        if(res){
          this.getAllProducts();
        }
        this.ResponsMassage=(res)?"deleteWork":"delete faild";
        alert(this.ResponsMassage)
      }
    )
  }

 
  AddNewBook():void{
    let NewProduct:Product={ProductName:"arci",Price:20};
    alert(NewProduct.Price)
    let callback=(bool:boolean)=>{this.DidPostWork=(bool)?"postWorks":"postdontwork";}
    this.myProductService.AddNewProduct(NewProduct,callback)
  }

  EditProduct():void{
    let NewProduct:Product={ProductName:"arci",Price:30};
    alert(NewProduct.Price)
    let callback=(bool:boolean)=>{this.DidPutWork=(bool)?"postWorks":"postdontwork";}
    this.myProductService.EditProduct(NewProduct.ProductName,NewProduct,callback)
  }
  


  constructor(private myProductService:ProductService){
  }
  
  ngOnInit(){
    this.productList=this.myProductService.productList;
    
  }

}
