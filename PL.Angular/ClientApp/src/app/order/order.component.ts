import { Component, OnInit } from '@angular/core';
import { OrderService } from './order.service';
import { EnrollmentModel } from '../models/enrollmentModel';
import { StorageService } from '../storage/storage.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
} as any)
export class OrderComponent implements OnInit {
  public enrollments: EnrollmentModel[] = [];
  private userId: string | null = null;

  constructor(
    private orderService: OrderService,
    private storageService: StorageService
  ) { }

  ngOnInit(): void {
    this.userId = this.storageService.getUserId();
    if (this.userId) {
      this.loadEnrollments();
    }
  }

  loadEnrollments(): void {
    if (this.userId) {
      this.orderService.getStudentEnrollments(this.userId).subscribe({
        next: (data) => {
          this.enrollments = data;
        },
        error: (err) => {
          console.error(err);
        }
      });
    }
  }

  getStatusText(status: string | number): string {
    switch (status) {
      case 0:
      case 'Requested':
        return 'Очікує підтвердження';
      case 1:
      case 'Active':
        return 'Активне навчання';
      case 2:
      case 'Completed':
        return 'Курс завершено';
      case 3:
      case 'Cancelled':
        return 'Скасовано';
      default:
        return 'Невідомий статус';
    }
  }
}