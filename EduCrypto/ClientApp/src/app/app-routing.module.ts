import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuSideBarTemplateComponent } from './components/menu-sidebar-template/component/menu-sidebar-template.component';

const routes: Routes = [
  { path: 'app-menu-sidebar-template', component: MenuSideBarTemplateComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}
