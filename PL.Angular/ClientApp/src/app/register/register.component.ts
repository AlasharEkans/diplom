import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegisterService } from './register.service';
import { StorageService } from '../storage/storage.service';
import { LoginService } from '../login/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  standalone: false
})
export class RegisterComponent {
  registerForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private registerService: RegisterService,
    private storageService: StorageService,
    private loginService: LoginService,
    private router: Router
  ) {
    this.registerForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      firstName: [''],
      lastName: ['']
    });
  }

  registerinto() {
    if (this.registerForm.invalid) {
      return;
    }

    const payload = {
      email: this.registerForm.get('email')?.value,
      password: this.registerForm.get('password')?.value,
      firstName: this.registerForm.get('firstName')?.value,
      lastName: this.registerForm.get('lastName')?.value
    };

    this.registerService.registerinto(payload).subscribe(
      (res) => {
        // Дані для подальшого авто-логіну
        const loginData = {
          email: payload.email,
          password: payload.password
        };

        this.loginService.signinto(loginData).subscribe(
          (resLog) => {
            this.storageService.saveUserData(resLog);
            // Переходимо на головну і оновлюємо сторінку, щоб змінилося меню
            this.router.navigate(['/']).then(() => {
              window.location.reload();
            });
          },
          (errorLog) => {
            console.error('Login error:', errorLog);
          }
        );
      },
      (error) => {
        console.error('Registration error:', error);
        alert('Помилка при реєстрації. Можливо, такий Email вже існує.');
      }
    );
  }
}
