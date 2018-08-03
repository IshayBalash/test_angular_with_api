import {Product} from "../models/product.modle"
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ProductListclass } from "../models/productList.modle";
import { Observable } from "rxjs/Observable";


@Injectable()
export class ProductService{

    productList:ProductListclass=new ProductListclass()

    


    constructor(private myHttpClient:HttpClient){
    }

    InitProducts():void{
        alert("in the funck")
        let url:string="http://localhost:54628/api/Product";
        this.myHttpClient.get(url).subscribe((x:Array<Product>)=>{this.productList.productsArry=x;}
        )   
    }
    SetSpecificProduct(productname:string):void{
        alert("in the secend functin")
        this.myHttpClient.get(`http://localhost:54628/api/Product?productname=${productname}`,{headers:{Authorization:"RegisterUser Client"}})
        .subscribe((x:Product)=>{this.productList.singleProduct=x;});
              
    }

    DeleteProduct(productname:string):Observable<boolean>{
        alert("service delte funk")
        return this.myHttpClient.delete<boolean>(`http://localhost:54628/api/Product?productname=${productname}`,{headers:{Authorization:"RegisterUser Manager"}});
    }

    

}