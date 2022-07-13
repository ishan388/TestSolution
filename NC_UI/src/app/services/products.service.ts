import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
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

}
