import {Product} from "../models/product.modle"
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ProductListclass } from "../models/productList.modle";


@Injectable()
export class ProductService{

    productList:ProductListclass=new ProductListclass()


    constructor(private myHttpClient:HttpClient){
        this.InitProducts();
        console.log(this.productList.productsArry[0].ProductName)
       
    }

    InitProducts():void{
        let url:string="http://localhost:52786/api/Prosucts";
        this.myHttpClient.get(url).subscribe((x:Array<Product>)=>{this.productList.productsArry=x;});
    }
}