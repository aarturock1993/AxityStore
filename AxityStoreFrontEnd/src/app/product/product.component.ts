import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IProduct } from './product';
import { ProductService } from './product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  products: IProduct[];
  userInfo: any;
  errorMessage: string;
  
  constructor(private productService: ProductService,
              private router: Router) { }

  ngOnInit(): void {

    this.userInfo = JSON.parse(sessionStorage.getItem('UserInfo'));

    this.productService.getAllProducts().subscribe({
        next: products =>{
          this.products = products;
        }, 
        error: err => this.errorMessage = err
     });
  }

  logOut(): void{
    sessionStorage.clear();
    this.router.navigate(['']);
  }

}
