import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TranslateModule } from '@ngx-translate/core';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { NavFooterComponent } from './nav-footer/nav-footer.component';
import { ProductComponent } from './product/product.component';
import { CartComponent } from './cart/cart.component';
import { OrderComponent } from './order/order.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { PrivacyComponent } from './privacy/privacy.component';
import { TeacherRegisterComponent } from './teacher/teacher-register/teacher-register.component';
import { TeacherCoursesComponent } from './teacher/teacher-courses/teacher-courses.component';
import { CourseFormComponent } from './teacher/course-form/course-form.component';
import { TeacherGuard } from './guards/teacher.guard';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    NavFooterComponent,
    ProductComponent,
    CartComponent,
    OrderComponent,
    LoginComponent,
    RegisterComponent,
    PrivacyComponent,
    TeacherRegisterComponent,
    TeacherCoursesComponent,
    CourseFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    TranslateModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: ProductComponent, pathMatch: 'full' },
      { path: 'courses', component: ProductComponent },
      { path: 'cart', component: CartComponent },
      { path: 'enrollments', component: OrderComponent },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'privacy', component: PrivacyComponent },
      { path: 'teacher/register', component: TeacherRegisterComponent },
      { path: 'teacher/courses', component: TeacherCoursesComponent, canActivate: [TeacherGuard] }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
