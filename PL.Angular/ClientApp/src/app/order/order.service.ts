import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EnrollmentModel } from '../models/enrollmentModel';
import { EnrollmentRequestModel } from '../models/enrollmentRequestModel';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl + 'api/enrollments';
  }

  createEnrollment(request: EnrollmentRequestModel): Observable<EnrollmentModel> {
    return this.http.post<EnrollmentModel>(`${this.baseUrl}/create`, request);
  }

  getStudentEnrollments(userId: string): Observable<EnrollmentModel[]> {
    return this.http.get<EnrollmentModel[]>(`${this.baseUrl}/student/${userId}`);
  }

  getAllEnrollments(): Observable<EnrollmentModel[]> {
    return this.http.get<EnrollmentModel[]>(this.baseUrl);
  }

  updateStatus(id: string, status: number): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${id}/status`, status);
  }
}