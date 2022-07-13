import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { ProductVM } from 'src/app/models/viewmodels/productVM.model';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'add-edit-product',
  templateUrl: './add-edit-product.component.html',
  styleUrls: ['./add-edit-product.component.css']
})
export class AddEditProductComponent implements OnInit {

  public product: ProductVM = new ProductVM();

  cancel() {
    this.product = {
      statusName: 'Active',
      id: 0,
      name: '',
      price: 0,
      status: 1,
      createdDateTime: new Date(),
      modifiedDateTime: new Date()
    };
    this.sendRefreshSignal();
  }

  constructor(private service: ProductsService) {
    
  }

  ngOnInit(): void {
    this.service.selectedProduct.subscribe(data => {
      if (data.id > 0)
        this.product = data;
    });
  }

  sendRefreshSignal() {
    this.service.isProductedSavedorCancelled(true);
  }

  saveProduct(): void {
    if (this.product.name.length > 0) {
      if (this.product.id == 0) {
        this.service.addProduct(this.product)
          .subscribe(res => {
            this.cancel();
          });
      }
      else {
        this.service.editProduct(this.product)
          .subscribe(res => {
            this.cancel();
          });
      }
    }
  }

}
