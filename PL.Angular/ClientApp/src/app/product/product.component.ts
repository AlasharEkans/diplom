import { Component, OnInit } from '@angular/core';
import { CourseService } from './course.service';
import { CourseModel } from '../models/courseModel';
import { CartService } from '../cart/cart.service';
import { StorageService } from '../storage/storage.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
} as any)
export class ProductComponent implements OnInit {
  public courses: CourseModel[] = [];
  private userId: string | null = null;

  constructor(
    private courseService: CourseService,
    private cartService: CartService,
    private storageService: StorageService
  ) { }

  ngOnInit(): void {
    this.userId = this.storageService.getUserId();
    this.loadCourses();
  }

  loadCourses(): void {
    this.courseService.getCourses().subscribe({
      next: (data) => {
        this.courses = data;
      },
      error: (err) => {
        console.error(err);
      }
    });
  }

  enroll(courseId: string): void {
    if (!this.userId) {
      alert('Будь ласка, авторизуйтесь у системі');
      return;
    }
    this.cartService.addToCart({ userId: this.userId, courseId: courseId }).subscribe({
      next: () => {
        alert('Курс додано до списку обраного');
      },
      error: (err) => {
        console.error(err);
      }
    });
  }
}