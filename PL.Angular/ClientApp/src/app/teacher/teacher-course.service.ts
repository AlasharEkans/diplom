import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CourseModel } from '../models/courseModel';

export interface CreateCourseRequest {
  title: string;
  description: string;
  author: string;
  imageName: string;
  userId: string;
}

export interface UpdateCourseRequest extends CreateCourseRequest {
  id: string;
}

@Injectable({ providedIn: 'root' })
export class TeacherCourseService {
  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl + 'api/courses';
  }

  getCourses(): Observable<CourseModel[]> {
    return this.http.get<CourseModel[]>(this.baseUrl);
  }

  createCourse(request: CreateCourseRequest): Observable<CourseModel> {
    return this.http.post<CourseModel>(this.baseUrl, request);
  }

  updateCourse(id: string, request: UpdateCourseRequest): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${id}`, request);
  }

  deleteCourse(id: string, userId: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}?userId=${userId}`);
  }
}
