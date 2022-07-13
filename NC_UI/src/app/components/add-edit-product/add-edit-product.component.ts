import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductVM } from 'src/app/models/viewmodels/productVM.model';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'add-edit-product',
  templateUrl: './add-edit-product.component.html',
  styleUrls: ['./add-edit-product.component.css']
})
export class AddEditProductComponent implements OnInit {

  public product!: ProductVM;

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
  }

  constructor(private service: ProductsService) {
  }

  ngOnInit(): void {
    this.cancel();
  }

  saveProduct(): void {
    console.log(this.product);
    if (this.product.id == 0) {
      this.service.addProduct(this.product)
        .subscribe(res => {
          console.log(res);
          this.cancel();
        });
    }
    else {
      this.service.editProduct(this.product)
        .subscribe(res => {
          console.log(res);
          this.cancel();
        });
    }
  }

}
