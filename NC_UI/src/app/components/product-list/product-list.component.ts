import { Component, OnInit } from '@angular/core';
import { ProductVM } from 'src/app/models/viewmodels/productVM.model';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  constructor(private service: ProductsService) { }

  allProducts: ProductVM[] = [];

  ngOnInit(): void {
    this.getAllProducts();
  }

  public getAllProducts() {
    this.service.getAllProducts()
      .subscribe(res => {
        this.allProducts = res.dataList;
      });
  }

  deleteProduct(productId: number) {
    
    this.service.deleteProduct(productId)
      .subscribe(res => {
        this.getAllProducts();
      });
  }

  sendToEdit(product: ProductVM) {
    console.log(product);
  }


}
