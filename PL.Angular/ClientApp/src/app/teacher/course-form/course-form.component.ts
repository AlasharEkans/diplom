import { Component, Input, Output, EventEmitter, OnInit, OnChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TeacherCourseService, CreateCourseRequest, UpdateCourseRequest } from '../teacher-course.service';
import { CourseModel } from '../../models/courseModel';

@Component({
  selector: 'app-course-form',
  templateUrl: './course-form.component.html',
  standalone: false
})
export class CourseFormComponent implements OnInit, OnChanges {
  @Input() course: CourseModel | null = null;
  @Input() userId!: string;
  @Output() saved = new EventEmitter<void>();
  @Output() cancelled = new EventEmitter<void>();

  form!: FormGroup;
  submitting = false;

  constructor(private fb: FormBuilder, private courseService: TeacherCourseService) {}

  ngOnInit(): void {
    this.buildForm();
  }

  ngOnChanges(): void {
    this.buildForm();
  }

  buildForm(): void {
    this.form = this.fb.group({
      title: [this.course?.title ?? '', Validators.required],
      description: [this.course?.description ?? ''],
      author: [this.course?.author ?? '', Validators.required],
      imageName: [this.course?.imageName ?? '']
    });
  }

  get isEdit(): boolean {
    return !!this.course;
  }

  submit(): void {
    if (this.form.invalid || this.submitting) return;
    this.submitting = true;

    const { title, description, author, imageName } = this.form.value;

    if (this.isEdit && this.course) {
      const request: UpdateCourseRequest = { id: this.course.id, title, description, author, imageName, userId: this.userId };
      this.courseService.updateCourse(this.course.id, request).subscribe({
        next: () => { this.submitting = false; this.saved.emit(); },
        error: (err) => { this.submitting = false; console.error(err); }
      });
    } else {
      const request: CreateCourseRequest = { title, description, author, imageName, userId: this.userId };
      this.courseService.createCourse(request).subscribe({
        next: () => { this.submitting = false; this.saved.emit(); },
        error: (err) => { this.submitting = false; console.error(err); }
      });
    }
  }
}
