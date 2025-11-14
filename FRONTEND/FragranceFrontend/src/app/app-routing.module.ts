import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListComponent } from './list/list.component';
import { CreateComponent } from './create/create.component';

const routes: Routes = [
  {path:"", redirectTo:"list", pathMatch:"full"},
  {path:"list", component:ListComponent},
  {path:"create", component:CreateComponent},
  {path:"**", redirectTo:"list", pathMatch:"full"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
