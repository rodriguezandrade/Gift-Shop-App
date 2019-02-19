import { Component, OnInit } from '@angular/core';
import { GlobalsService } from '../Core/globals.service';
import { SaleService } from './shared/sale.service';
import { sale } from './shared/sale.model';

@Component({
  selector: 'app-shopping',
  templateUrl: './shopping.component.html',
  styleUrls: ['./shopping.component.css']
})
export class ShoppingComponent implements OnInit {
  total: number = 0;
  listSale: sale[] = [];
  Sale: sale = new sale();
  constructor(private globals: GlobalsService,private itemSaleService: SaleService,) { }

  ngOnInit() {
    this.consultSale();
  }
  consultSale() {
    if (this.globals.user) {
      this.itemSaleService.getSale().subscribe((data: sale[]) => {
        this.listSale = data;
      
        
        
      });
    } else {
       if (confirm(' you do not have products bought yet') == false) {
       }
    }
  }
}
