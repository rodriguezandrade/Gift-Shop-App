import { Component, OnInit } from '@angular/core';
import { Products } from '../comp-products/shared/products.model';
import { ToastrService } from 'ngx-toastr';
import { cartItem } from './shared/cartItem.model';
import { CartitemService } from './shared/cartItem.service';
import { GlobalsService } from '../Core/globals.service';
import { sale } from '../shopping/shared/sale.model';
import { SaleService } from '../shopping/shared/sale.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  total: number = 0;
  listProductCart: cartItem[] = [];
  Cart: cartItem = new cartItem();
  Sale: sale = new sale();

  get haveItemd(): boolean {
    return this.listProductCart.length > 0
  }

  constructor(private saleService: SaleService, private router: Router, private globals: GlobalsService, private itemCartService: CartitemService, private toastr: ToastrService) {
  }
  ngOnInit() {
    this.consultCart();

  }
  consultCart() {
    if (this.globals.user) {
      this.itemCartService.getCartItem().subscribe((data: cartItem[]) => {
        this.listProductCart = data;
        this.listProductCart.forEach(element => {
          this.total += element.subTotal;
        });
      });
    } else {
      this.getCartFromLocalStorage();
    }
  }
  getCartFromLocalStorage() {
    let nombre = localStorage.getItem("nombre");
    if (nombre != null) {
      this.listProductCart = JSON.parse(localStorage.getItem("listCart"));
      this.listProductCart.forEach(element => {
        this.total += element.subTotal;
      });
    }
  }
  addSale(sale: sale) {
    if (this.globals.user) {
      //Add Sale
 
        this.itemCartService.checkout().subscribe((data: cartItem) => {
          this.toastr.success('You have successfully purchased!');
          this.router.navigate(['/shopping'])
          this.consultCart();
        });

      
    }

  }
}

