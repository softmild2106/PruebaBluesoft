import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookComponent } from './views/book/book.component';
import { CategoryComponent } from './views/category/category.component';
import { AuthorComponent } from './views/author/author.component';

const routes: Routes = [
  { path: 'home', component: BookComponent },
  { path: 'book', component: BookComponent },
  { path: 'category', component: CategoryComponent },
  { path: 'author', component: AuthorComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
