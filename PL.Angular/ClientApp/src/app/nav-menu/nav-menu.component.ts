import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { StorageService } from '../storage/storage.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(private storageService: StorageService, private router: Router) { }

  get isUserLoggedIn(): boolean {
    return this.storageService.isLoggedIn();
  }

  get isTeacher(): boolean {
    return this.storageService.isTeacher();
  }

  get isStudent(): boolean {
    return this.storageService.isStudent();
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout() {
    this.storageService.clean();
    this.router.navigate(['/login']);
  }
}
