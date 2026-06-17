import { Component, OnInit } from '@angular/core';
import { CartService } from './cart.service';
import { CartModel } from '../models/cartModel';
import { OrderService } from '../order/order.service';
import { StorageService } from '../storage/storage.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
} as any)
export class CartComponent implements OnInit {
  public cartItems: CartModel[] = [];
  private userId: string | null = null;

  constructor(
    private cartService: CartService,
    private orderService: OrderService,
    private storageService: StorageService
  ) { }

  ngOnInit(): void {
    this.userId = this.storageService.getUserId();
    if (this.userId) {
      this.loadCart();
    }
  }

  loadCart(): void {
    if (this.userId) {
      this.cartService.getCart(this.userId).subscribe({
        next: (data) => {
          this.cartItems = data;
        },
        error: (err) => {
          console.error(err);
        }
      });
    }
  }

  removeItem(cartId: string): void {
    this.cartService.removeFromCart(cartId).subscribe({
      next: () => {
        this.loadCart();
      },
      error: (err) => {
        console.error(err);
      }
    });
  }

  confirmEnrollment(): void {
    if (!this.userId || this.cartItems.length === 0) {
      return;
    }

    const courseIds = this.cartItems.map(item => item.courseId);
    this.orderService.createEnrollment({ userId: this.userId, courseIds: courseIds }).subscribe({
      next: () => {
        alert('Заявку на навчання успішно надіслано!');
        this.cartService.clearCart(this.userId!).subscribe({
          next: () => {
            this.cartItems = [];
          }
        });
      },
      error: (err) => {
        console.error(err);
      }
    });
  }
}