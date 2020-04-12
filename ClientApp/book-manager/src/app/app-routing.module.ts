import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookComponent } from './views/book/book.component';
// import { AuthorComponent } from './views/author/create.component';
import { CreateComponent as CreateCategoryComponent } from './views/category/create/create.component';
import { EditComponent as EditCategoryComponent } from './views/category/edit/edit.component';
import { ListComponent as ListCategoryComponent } from './views/category/list/list.component';

const routes: Routes = [
  { path: 'home', component: BookComponent },
  { path: 'book', component: BookComponent },
  { path: 'createcategory', component: CreateCategoryComponent },
  { path: 'editcategory/:id', component: EditCategoryComponent },
  { path: 'categorylist', component: ListCategoryComponent },
  // { path: 'author', component: AuthorComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
