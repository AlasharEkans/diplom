import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TeacherRegisterService } from '../teacher-register.service';
import { LoginService } from '../../login/login.service';
import { StorageService } from '../../storage/storage.service';

@Component({
  selector: 'app-teacher-register',
  templateUrl: './teacher-register.component.html',
  standalone: false
})
export class TeacherRegisterComponent {
  form: FormGroup;
  error = '';

  constructor(
    private fb: FormBuilder,
    private teacherRegisterService: TeacherRegisterService,
    private loginService: LoginService,
    private storageService: StorageService,
    private router: Router
  ) {
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      firstName: [''],
      lastName: [''],
      accessCode: ['', Validators.required]
    });
  }

  submit(): void {
    if (this.form.invalid) return;

    const { email, password, firstName, lastName, accessCode } = this.form.value;

    this.teacherRegisterService.registerTeacher({ email, password, firstName, lastName, accessCode }).subscribe({
      next: () => {
        this.loginService.signinto({ email, password }).subscribe({
          next: (res: any) => {
            this.storageService.saveUserData(res);
            this.router.navigate(['/teacher/courses']);
          },
          error: () => this.router.navigate(['/login'])
        });
      },
      error: (err) => {
        this.error = err.error || 'Помилка реєстрації. Перевірте код доступу.';
      }
    });
  }
}
