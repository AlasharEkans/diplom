import { EnrolledCourse } from './enrolledCourse';

export interface EnrollmentModel {
  id: string;
  studentId: string;
  enrolledAt: string;
  status: number;
  courses: EnrolledCourse[];
}