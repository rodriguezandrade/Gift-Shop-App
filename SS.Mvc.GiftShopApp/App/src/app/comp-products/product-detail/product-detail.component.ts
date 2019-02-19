import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../shared/product.service';
import { Products } from '../shared/products.model';
import { CartitemService } from '../../cart/shared/cartItem.service';
import { cartItem } from '../../cart/shared/cartItem.model';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs/operators'
import { NgForm } from '@angular/forms';
import { GlobalsService } from 'src/app/Core/globals.service';
@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styles: []
})
export class ProductDetailComponent implements OnInit {
  productId;
  statusProductCart = false;
  product = new Products();
  ListPrd: Products[] = [];
  ListProductBackup: any = [];
  constructor(
     private cartItemService: CartitemService,
     private route: ActivatedRoute,
     private router: Router,
     private productService: ProductService,
     private toastr: ToastrService,
     private globals: GlobalsService) { }
  listProduct: Products[];
  listCart: cartItem[] = [];
  Cart: cartItem = new cartItem();
  ngOnInit() {
    const id = parseInt(this.route.snapshot.paramMap.get('Id'));
    this.productId = id;

    this.productService.get().subscribe(
      res => {
        this.ListPrd = res;
        this.listProduct = this.ListPrd;
        this.filterProduct(this.productId);
        this.getLocalStorage();
      },
      error => console.error()
    );
    // this.productService.getProducts();
  }

  filterProduct(idProduct: number) {
    this.product = this.ListPrd.filter(x => x.id === idProduct)[0];
  }

  getLocalStorage() {
    const nombre = localStorage.getItem('nombre');
    if (nombre != null) {
      this.ListProductBackup = JSON.parse(localStorage.getItem('listProduct'));

    }
  }
  saveCart_localstorage() {
    const nombre = 'dbSaveCart';
    localStorage.setItem('nombre', nombre);
    localStorage.setItem('listCart', JSON.stringify(this.listCart));
  }
  addtoCart(prd: Products, amount: number) {
    if (this.globals.user) {
      // Add Product to Database
      this.Cart.productid = prd.id;
      this.Cart.amount = amount;
      this.Cart.subTotal = amount * prd.cost;
      this.Cart.userid = this.globals.user.id;
      // Filter Products to verify if the product exists
      this.cartItemService.getCartItem().pipe(
        map((value, i) => {
          this.statusProductCart = value.map(cv => cv.productId).indexOf(this.Cart.productid) !== -1;
          return value;
        })
      ).subscribe((data: cartItem[]) => {
        this.listCart = data;
        if (this.statusProductCart === true) {
          this.toastr.info('You have this product in your cart', 'You can add quantity of product in your shopping Cart');
          this.router.navigate(['/cart']);
        } else if (this.statusProductCart === false) {
          this.cartItemService.postCartItem(this.Cart)
            .subscribe(() => {
                this.toastr.success('Sucessfully', ' Added to cart!');
              });
        }
      });
    }
    else {
      //Working and Add to Local Storage
      this.Cart.product = prd;
      this.Cart.productid = prd.id;
      this.Cart.amount = amount;
      this.Cart.subTotal = amount * prd.cost;
      this.Cart.userid = 1;
      let nombre = localStorage.getItem("nombre");
      if (nombre != null) {
        this.listCart = JSON.parse(localStorage.getItem("listCart"));
        this.listCart.forEach(element => {
          if (element.productid == this.product.id) {
            this.statusProductCart = true;
          }
        });
      }
      if (this.statusProductCart == true) {
        this.toastr.info("You have this product in your cart", "You can add quantity of product in your shopping Cart");
        this.router.navigate(['/cart'])
      } else if (this.statusProductCart == false) {
        this.listCart.push(this.Cart);
        this.saveCart_localstorage();
        this.toastr.info("Succesfully! ", " Add to Shoping Cart")
      }
    }
  }
  onSubmit(form: NgForm) {
    if (form.value.id == null) {
      this.productService.post(form.value)
        .subscribe(data => {
          this.productService.get();
          this.toastr.success('Product  Added Sucessfully', 'Product Register!')
        });
    }
    else {
      this.productService.put(form.value.id, form.value)
        .subscribe(data => {
          this.productService.get();
          this.toastr.info('Record was Updated Sucessfully', 'Product Updated!')
        });
    }
  }
  save_localstorage() {
    let nombre: string = 'dblocalJson';
    localStorage.setItem("nombre", nombre);
    localStorage.setItem("listProduct", JSON.stringify(this.ListProductBackup));
  }
}
