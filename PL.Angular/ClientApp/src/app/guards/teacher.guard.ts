import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { StorageService } from '../storage/storage.service';

@Injectable({ providedIn: 'root' })
export class TeacherGuard implements CanActivate {
  constructor(private storageService: StorageService, private router: Router) {}

  canActivate(): boolean {
    if (this.storageService.isTeacher()) {
      return true;
    }
    this.router.navigate(['/']);
    return false;
  }
}
