import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class TeacherRegisterService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  registerTeacher(payload: { email: string; password: string; firstName: string; lastName: string; accessCode: string }) {
    return this.http.post(this.baseUrl + 'api/registration/teacher', payload);
  }
}
