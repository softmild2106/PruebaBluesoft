import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateComponent as CreateAuthorComponent } from './views/author/create/create.component';
import { IndexComponent as IndexAuthorComponent } from './views/author/index/index.component';
import { EditComponent as EditAuthorComponent } from './views/author/edit/edit.component';
import { CreateComponent as CreateCategoryComponent } from './views/category/create/create.component';
import { EditComponent as EditCategoryComponent } from './views/category/edit/edit.component';
import { ListComponent as ListCategoryComponent } from './views/category/list/list.component';
import { CreateComponent as CreateBookComponent } from './views/book/create/create.component';
import { EditComponent as EditBookComponent } from './views/book/edit/edit.component';

const routes: Routes = [
  // { path: 'home', component: BookComponent },
  { path: 'createcategory', component: CreateCategoryComponent },
  { path: 'editcategory/:id', component: EditCategoryComponent },
  { path: 'categorylist', component: ListCategoryComponent },
  { path: 'author/create', component: CreateAuthorComponent },
  { path: 'author/edit/:id', component: EditAuthorComponent },
  { path: 'author/index', component: IndexAuthorComponent },
  { path: 'book/create', component: CreateBookComponent },
  { path: 'book/edit/:id', component: EditBookComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
