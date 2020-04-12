import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookComponent } from './views/book/book.component';
import { CreateComponent as CreateAuthorComponent } from './views/author/create/create.component';
import { EditComponent as EditAuthorComponent } from './views/author/edit/edit.component';
import { CreateComponent as CreateCategoryComponent } from './views/category/create/create.component';
import { EditComponent as EditCategoryComponent } from './views/category/edit/edit.component';
import { ListComponent as ListCategoryComponent } from './views/category/list/list.component';

const routes: Routes = [
  { path: 'home', component: BookComponent },
  { path: 'book', component: BookComponent },
  { path: 'createcategory', component: CreateCategoryComponent },
  { path: 'editcategory/:id', component: EditCategoryComponent },
  { path: 'categorylist', component: ListCategoryComponent },
  { path: 'createauthor', component: CreateAuthorComponent },
  { path: 'editauthor/:id', component: EditAuthorComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
