import { Component, OnInit } from '@angular/core';
import { ProductService } from '../shared/product.service';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { importType } from '@angular/compiler/src/output/output_ast';
import { Products, initialProduct } from '../shared/products.model';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryService } from 'src/app/Category/shared/category.service';
import { Category } from 'src/app/Category/shared/category.model';
@Component({
  selector: 'app-comproduct',
  templateUrl: './comproduct.component.html',
  styleUrls: ['./comproduct.component.css']
})
export class ComproductComponent implements OnInit {
  imageUrl = '/assets/img/default.png';
  id: number | string;
  value: Products;
  tittle = '';
  categories: Category[] = [];
  get canSave(): boolean {
    const value = this.value;
    return value.name && value.name !== '' &&
      value.detail && value.detail !== '' &&
      value.cant !== undefined && value.cant > 0 &&
      value.cost !== undefined && value.cost > 0 &&
      value.categoryId !== undefined &&
      value.status !== undefined && value.status > 0
      ;
  }
  constructor(
    private _service2: CategoryService,
    private _service: ProductService,
    private _toastr: ToastrService,
    private _route: ActivatedRoute,
    private _router: Router) { }

  ngOnInit() {
    this._service2.get().subscribe(
      res => this.categories = res,
      error => console.error()
    );
    this.id = this._route.snapshot.paramMap.get('Id');
    if (this.id !== 'new') {
      this.tittle = 'Edit product';
      this._service.get().subscribe(
        res => {
          const valor = res.filter(x => x.id === +this.id)[0];
          this.value = valor;
        },
        error => console.error()
      );
    } else {
      this.value = initialProduct;
      this.tittle = 'Add product';
    }
  }
  onSave = () => {
    if (this.id === 'new') {
      this._service.post(this.value)
        .subscribe(data => {
          this._toastr.success('Product  Added Sucessfully', 'Product Register!');
          this._router.navigate(['/products']);
        });
    } else {
      this._service.put(this.value.id, this.value)
        .subscribe(data => {
          this._toastr.info('Record was Updated Sucessfully', 'Product Updated!');
          this._router.navigate(['/products']);
        });
    }
  }

}
