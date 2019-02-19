import { Component, OnInit } from '@angular/core';
import {ProductService} from './shared/product.service';
@Component({
  selector: 'app-comp-products',
  templateUrl: './comp-products.component.html',
  styleUrls: ['./comp-products.component.css'],
  providers:[ProductService]
})
export class CompProductsComponent implements OnInit {

  constructor(private productService:ProductService) { }

  ngOnInit() {
  }

}
