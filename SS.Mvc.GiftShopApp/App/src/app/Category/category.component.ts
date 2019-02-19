import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryService } from './shared/category.service';
import { ToastrService } from 'ngx-toastr';
import { Category, initialCategory } from './shared/category.model';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  id: string | number;
  value: Category;
  tittle = '';
  get canSave(): boolean {
    const value = this.value;
    return value.name && value.name !== '' &&
      value.detail && value.detail !== '' ;
  }
  constructor(
    private _route: ActivatedRoute,
    private _service: CategoryService,
    private _toastr: ToastrService,
    private _router: Router  ) { }
  ngOnInit() {
    this.id = this._route.snapshot.paramMap.get('Id') ;
    if (this.id !== 'new') {
      this.tittle = 'Edit Category';
      this._service.get().subscribe(
        res => {
          const valor = res.filter(x => x.id === +this.id)[0];
          this.value = valor;
        },
        error => console.error()
      );
    } else {
      this.value = initialCategory;
      this.tittle = 'Add Category';
    }
  }

  onSave = () => {
    if (this.id === 'new') {
      this._service.post(this.value)
        .subscribe(data => {
          this._toastr.success('Category Added Sucessfully', 'Category Registered!');
          this._router.navigate(['/category']);
        });
    } else {
      this._service.put(this.value.id, this.value).subscribe( data => {
      this._toastr.info( 'Modified Succesfully' , 'Category');
      this._router.navigate(['/category']);
      }
      );
    }
  }
}
