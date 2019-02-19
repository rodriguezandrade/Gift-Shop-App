import { Component, OnInit } from '@angular/core';
import { ProductService } from '../comp-products/shared/product.service';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { PipeTransform, Pipe } from '@angular/core';
import { GlobalsService } from '../Core/globals.service';
import { AppComponent } from '../app.component';
import { Products, ProductsDto } from '../comp-products/shared/products.model';
import { Category } from '../Category/shared/category.model';
import { CategoryService } from '../Category/shared/category.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  ListPrd: ProductsDto[] = [];
  ListPrd2: ProductsDto[] = [];
  categories: Category[] = [];
  paginationcount = 6;
  countProduct = 0;
  _filterNameProduct = '';
  categoryProduct = '';

  constructor(
    private _service2: CategoryService,
    private _service: ProductService,
    public _globals: GlobalsService) { }

  ngOnInit() {
    this._service.get().subscribe(
      res => {
        this.ListPrd = res;
        this.ListPrd2 = res;
      },
      error => console.error()
    );
    this._service2.get().subscribe(
      res => this.categories = res,
      error => console.error()
    );
  }

  addPagination(pages: number) {
    if (pages === 0) {
      pages = 6;
    }
    this.paginationcount = pages;
    this.savePagination();
    this.countProduct = this.ListPrd.length;
  }
  savePagination() {
    const nombre = 'DbPagination';
    localStorage.setItem('pagination', nombre);
    localStorage.setItem('listpagination', JSON.stringify(this.paginationcount));
  }
  getPagination() {
    const nombre = localStorage.getItem('DbPagination');
    if (nombre != null) {
      this.paginationcount = JSON.parse(localStorage.getItem('listpagination'));
    }
  }
  // filter by Products and Category
  filterDataCategory(event: any) {
    this.categoryProduct = event.target.value;
  }
  searchProduct(nameProduct: string, pages: number) {
    if (pages <= 0 || pages != null) {
      this.paginationcount = 6;
    } else {
      this.paginationcount = pages;
    }
    this._filterNameProduct = nameProduct;
    this.filterData();
  }

  filterData() {
    this._service2.get().subscribe(
      res => this.categories = res,
      error => console.error()
    );
    this.ListPrd = this.ListPrd2;
    this.ListPrd = this.ListPrd.filter(product =>
      (this._filterNameProduct ? product.name.toLocaleLowerCase().indexOf(this._filterNameProduct.toLocaleLowerCase()) !== -1 : true) &&
      (this.categoryProduct ? product.categoryName.toLocaleLowerCase().indexOf(this.categoryProduct.toLocaleLowerCase()) !== -1 : true )
    );
  }
}
