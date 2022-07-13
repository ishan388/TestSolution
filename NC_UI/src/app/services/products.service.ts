import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Response } from '../models/common/response.model';
import { ProductVM } from '../models/viewmodels/productVM.model';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  apiPath: string = 'https://localhost:7220/api/Products';
  constructor(private http: HttpClient) { }

  getAllProducts(): Observable<Response<ProductVM>> {
    return this.http.get<Response<ProductVM>>(this.apiPath);
  }

  deleteProduct(productId: number): Observable<Response<number>> {
    return this.http.delete<Response<number>>(this.apiPath + '/' + productId.toString());
  }

  getProduct(productId: number): Observable<Response<ProductVM>> {
    return this.http.get<Response<ProductVM>>(this.apiPath + '/' + productId.toString());
  }

  addProduct(product: ProductVM): Observable<Response<number>> {
    return this.http.post<Response<number>>(this.apiPath, product);
  }

  editProduct(product: ProductVM): Observable<Response<number>> {
    return this.http.put<Response<number>>(this.apiPath, product);
  }

  //Fill product details in save form in click of any record of list
  productTransfer_L2F = new BehaviorSubject<ProductVM>(new ProductVM());
  selectedProduct = this.productTransfer_L2F.asObservable();
  shareproductFromList2Form(product: ProductVM) {
    this.productTransfer_L2F.next(product);
  }

  //Refresh the list in click of any button in save form
  infoTransfer_F2L = new BehaviorSubject<boolean>(false);
  anyButtonClick = this.infoTransfer_F2L.asObservable();
  isProductedSavedorCancelled(isAnyButtonClick: boolean) {
    this.infoTransfer_F2L.next(isAnyButtonClick);
  }

}
