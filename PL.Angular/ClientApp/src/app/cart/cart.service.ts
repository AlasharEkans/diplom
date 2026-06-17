import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CartModel } from '../models/cartModel';
import { CartRequestModel } from '../models/cartRequestModel';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl + 'api/cart';
  }

  getCart(userId: string): Observable<CartModel[]> {
    return this.http.get<CartModel[]>(`${this.baseUrl}/${userId}`);
  }

  addToCart(request: CartRequestModel): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/add`, request);
  }

  removeFromCart(cartId: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/remove/${cartId}`);
  }

  clearCart(userId: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/clear/${userId}`);
  }
}