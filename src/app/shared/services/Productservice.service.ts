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
        let url:string="http://localhost:52786/api/Prosucts";
        this.myHttpClient.get(url).subscribe((x:Array<Product>)=>{this.productList.productsArry=x;}
        )   
    }
    SetSpecificProduct(productname:string):void{
        alert("in the secend functin")
        let url=`http://localhost:52786/api/Prosucts?productname=${productname}`
        this.myHttpClient.get(url).subscribe((x:Product)=>{this.productList.singleProduct=x;console.log(this.productList.singleProduct)});

    }

    DeleteProduct(productname:string):Observable<boolean>{
        alert("service delte funk")
        let url:string=`http://localhost:52786/api/Prosucts?productname=${productname}`;
        return this.myHttpClient.delete<boolean>(url);
    }

    AddNewProduct(Productparam:Product,callback:(bool:boolean)=>void):void{
        alert(JSON.stringify(Productparam))
        this.myHttpClient.post<boolean>("http://localhost:52786/api/Prosucts",JSON.stringify(Productparam),{headers:{"content-type":"application/json"}}).subscribe(()=>{this.InitProducts();callback(true);},()=>{callback(false)});
    }

    EditProduct(productname:string,Productparam:Product,callback:(bool:boolean)=>void):void{
        alert(JSON.stringify(Productparam))
        this.myHttpClient.put<boolean>(`http://localhost:52786/api/Prosucts?productname=${productname}`,JSON.stringify(Productparam),{headers:{"content-type":"application/json"}}).subscribe(()=>{this.InitProducts();callback(true);},()=>{callback(false)});
    }

}