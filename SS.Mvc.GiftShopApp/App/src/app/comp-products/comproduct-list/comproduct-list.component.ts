import { Component, OnInit } from '@angular/core';
import { ProductService } from '../shared/product.service';
import { Products, ProductsDto } from '../shared/products.model';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-comproduct-list',
  templateUrl: './comproduct-list.component.html',
  styleUrls: ['./comproduct-list.component.css']
})
export class ComproductListComponent implements OnInit {
  items: ProductsDto[] = [];
  constructor(
    private _service: ProductService,
    private _toastr: ToastrService) { }

  ngOnInit() {
    this._service.get().subscribe(
      res => this.items = res,
      error => console.error()
    );
  }

  onDelete = (id: number) => {
    this._service.delete(id)
      .subscribe(
        next => {
          this._service.get().subscribe(
            res => {
              this.items = res;
              this._toastr.success('Deleted Succesfully!', 'Product');
            },
            error => console.error()
          );
        });
  }

}
