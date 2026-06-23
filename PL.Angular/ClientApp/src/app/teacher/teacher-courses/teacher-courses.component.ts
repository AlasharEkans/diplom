import { Component, OnInit } from '@angular/core';
import { TeacherCourseService } from '../teacher-course.service';
import { CourseModel } from '../../models/courseModel';
import { StorageService } from '../../storage/storage.service';

@Component({
  selector: 'app-teacher-courses',
  templateUrl: './teacher-courses.component.html',
  standalone: false
})
export class TeacherCoursesComponent implements OnInit {
  courses: CourseModel[] = [];
  userId: string | null = null;
  editingCourse: CourseModel | null = null;
  isCreating = false;

  constructor(
    private teacherCourseService: TeacherCourseService,
    private storageService: StorageService
  ) {}

  ngOnInit(): void {
    this.userId = this.storageService.getUserId();
    this.loadCourses();
  }

  loadCourses(): void {
    this.teacherCourseService.getCourses().subscribe({
      next: (data) => this.courses = data,
      error: (err) => console.error(err)
    });
  }

  startCreate(): void {
    this.editingCourse = null;
    this.isCreating = true;
  }

  startEdit(course: CourseModel): void {
    this.editingCourse = { ...course };
    this.isCreating = false;
  }

  onSaved(): void {
    this.isCreating = false;
    this.editingCourse = null;
    this.loadCourses();
  }

  onCancelled(): void {
    this.isCreating = false;
    this.editingCourse = null;
  }

  deleteCourse(id: string): void {
    if (!this.userId || !confirm('Ви впевнені, що хочете видалити цей курс?')) return;
    this.teacherCourseService.deleteCourse(id, this.userId).subscribe({
      next: () => this.loadCourses(),
      error: (err) => console.error(err)
    });
  }

  get showList(): boolean {
    return !this.isCreating && !this.editingCourse;
  }
}
