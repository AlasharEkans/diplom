import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CourseModel } from '../models/courseModel';

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl + 'api/courses';
  }

  getCourses(): Observable<CourseModel[]> {
    return this.http.get<CourseModel[]>(this.baseUrl);
  }

  getCourse(id: string): Observable<CourseModel> {
    return this.http.get<CourseModel>(`${this.baseUrl}/${id}`);
  }
}