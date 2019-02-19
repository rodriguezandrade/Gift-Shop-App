import { NgModule } from '@angular/core';
import { CommonModule, APP_BASE_HREF } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CartComponent } from './cart/cart.component';
import { CompProductsComponent } from './comp-products/comp-products.component';
import { ProductDetailComponent } from './comp-products/product-detail/product-detail.component';
import { AutguardService } from './Core/auth-guard.service';
import { ComproductComponent } from './comp-products/comproduct/comproduct.component';
import { ComproductListComponent } from './comp-products/comproduct-list/comproduct-list.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { GlobalsService } from './Core/globals.service';
import { ShoppingComponent } from './shopping/shopping.component';
import { CategoryComponent } from './Category/category.component';
import { ListCategoryComponent } from './Category/list-category/list-category.component';


const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'cart', component: CartComponent },
  { path: 'shopping', component: ShoppingComponent },
  { path: 'category', component: ListCategoryComponent },
  { path: 'category/:Id', component: CategoryComponent },
  { path: 'products', component: CompProductsComponent },
  { path: 'products/:Id', component: ComproductComponent, canActivate: [AutguardService] },
  { path: 'productDetail/:Id', component: ProductDetailComponent, canActivate: [AutguardService] },
  { path: 'list', component: ComproductListComponent },
  { path: 'signup', component: SignUpComponent },
  { path: 'signin', component: SignInComponent }
];
@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(
      routes,
      { enableTracing: false } // <-- debugging purposes only
    )
  ],
  exports: [RouterModule]

})
export class AppRoutingModule { }
