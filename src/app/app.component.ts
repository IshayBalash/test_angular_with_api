import { Component } from '@angular/core';
import {Product} from "../app/shared/models/product.modle"
import { ProductService } from './shared/services/Productservice.service';
import { ProductListclass } from './shared/models/productList.modle';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  test:number=5;
  productList:ProductListclass=new ProductListclass()

  constructor(private myProductService:ProductService){
    this.productList=myProductService.productList;
  }

}
