import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StorageService {
  private userKey = 'userData';

  // Зберігаємо всі дані користувача після логіну (токен, роль, id)
  saveUserData(data: any): void {
    localStorage.setItem(this.userKey, JSON.stringify(data));
  }

  // Отримуємо повний об'єкт користувача
  getUserData(): any {
    const data = localStorage.getItem(this.userKey);
    return data ? JSON.parse(data) : null;
  }

  // Перевіряємо, чи користувач авторизований
  isLoggedIn(): boolean {
    return !!localStorage.getItem(this.userKey);
  }

  // Отримуємо роль (наприклад, для приховування меню)
  getUserRole(): string | null {
    const user = this.getUserData();
    return user ? user.role : null;
  }

  // Отримуємо ID для відправки замовлень
  getUserId(): string | null {
    const user = this.getUserData();
    return user ? user.id : null;
  }

  isTeacher(): boolean {
    const user = this.getUserData();
    return user !== null && user.role === 1; // Role.Teacher
  }

  isStudent(): boolean {
    const user = this.getUserData();
    return user !== null && user.role === 2; // Role.Student
  }

  // Очищення (для кнопок Logout)
  clean(): void {
    localStorage.removeItem(this.userKey);
  }

  // Альтернативна назва для очищення
  clear(): void {
    this.clean();
  }
}
