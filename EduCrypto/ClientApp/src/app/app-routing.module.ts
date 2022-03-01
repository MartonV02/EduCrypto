import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuSideBarTemplateComponent } from './components/menu-sidebar-template/component/menu-sidebar-template.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent} from './components/register/register.component';
import { QuizComponent } from './components/quiz/quiz.component';

const routes: Routes = [
  { path: 'app-menu-sidebar-template', component: MenuSideBarTemplateComponent },
  { path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent},
  { path: 'quiz', component: QuizComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}
