import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../shared/category.service';
import { ToastrService } from 'ngx-toastr';
import { Category } from '../shared/category.model';

@Component({
  selector: 'app-list-category',
   templateUrl: './list-category.component.html',
  styleUrls: ['./list-category.component.css']
})
export class ListCategoryComponent implements OnInit {

  constructor(
    private _service: CategoryService,
    private _toastr:  ToastrService) { }
    items: Category [] = [];
  ngOnInit() {
    this._service.get().subscribe(
      res => this.items = res,
      error => console.error()
    );
  }
  onDelete = (id: number) => {
    this._service.delete(id).subscribe (
      next => {
        this._service.get().subscribe(
          res => {
            this.items = res;
            this._toastr.success('Deleted Succesfully!', 'Category');
          },
          error => console.error()
        );
      }
    );
  }

}
