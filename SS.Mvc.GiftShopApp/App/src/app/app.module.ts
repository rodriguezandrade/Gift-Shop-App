import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { CompProductsComponent } from './comp-products/comp-products.component';
import { ComproductComponent } from './comp-products/comproduct/comproduct.component';
import { ComproductListComponent } from './comp-products/comproduct-list/comproduct-list.component';
import { ToastrModule } from 'ngx-toastr';
import { SignUpComponent } from './sign-up/sign-up.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { UserService } from './sign-up/shared/user.service';
import { Routes, RouterModule } from '@angular/router';
import { APP_BASE_HREF } from '@angular/common';
import { SignInComponent } from './sign-in/sign-in.component';
import { CartComponent } from './cart/cart.component';
import { ShoppingComponent } from './shopping/shopping.component';
import { ProductFilterPipe } from './comp-products/product-filter.pipe';
import { HomeComponent } from './home/home.component';
import { ProductDetailComponent } from './comp-products/product-detail/product-detail.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { GlobalsService } from './Core/globals.service';
import { AutguardService } from './Core/auth-guard.service';
import { AppRoutingModule } from './app-routing.module';
import { CategoryComponent } from './Category/category.component';
import { ListCategoryComponent } from './Category/list-category/list-category.component';


@NgModule({

  declarations: [
    AppComponent,
    CompProductsComponent,
    ComproductComponent,
    ComproductListComponent,
    SignUpComponent,
    SignInComponent,
    CartComponent,
    ShoppingComponent,
    ProductFilterPipe,
    HomeComponent,
    CategoryComponent,
    ProductDetailComponent,
    ListCategoryComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
    HttpClientModule,
    NgxPaginationModule,
    AppRoutingModule
  ],
  exports: [RouterModule],
  providers: [GlobalsService, AutguardService, { provide: APP_BASE_HREF, useValue: '#/' }],

  bootstrap: [AppComponent]
})
export class AppModule {

}


export const routingComponents = [ProductDetailComponent, ComproductListComponent];
