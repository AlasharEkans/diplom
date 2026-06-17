import { CourseModel } from './courseModel';

export interface CartModel {
  id: string;
  userId: string;
  courseId: string;
  course: CourseModel | null;
}