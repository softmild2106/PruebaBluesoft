import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './components/navbar/navbar.component';
import { MaterialModule } from './material-module';
import { ReactiveFormsModule } from '@angular/forms';
import { CreateComponent as CreateCategoryComponent } from './views/category/create/create.component';
import { MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { EditComponent } from './views/category/edit/edit.component';
import { BasecomponentComponent } from './views/basecomponent/basecomponent.component';
import { ListComponent } from './views/category/list/list.component';
import { CreateComponent as CreateAuthorComponent } from './views/author/create/create.component';
import { EditComponent as EditAuthorComponent } from './views/author/edit/edit.component';
import { IndexComponent as IndexAuthorComponent } from './views/author/index/index.component';
import { CreateComponent as CreateBookComponent } from './views/book/create/create.component';
import { EditComponent as EditBookComponent } from './views/book/edit/edit.component';
import { IndexComponent as IndexBookComponent } from './views/book/index/index.component';
import { HomeComponent } from './views/home/home.component';
@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CreateCategoryComponent,
    EditComponent,
    BasecomponentComponent,
    ListComponent,
    CreateAuthorComponent,
    EditAuthorComponent,
    IndexAuthorComponent,
    CreateBookComponent,
    EditBookComponent,
    IndexBookComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    MaterialModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
  ],
  providers: [
    {
      provide: MAT_FORM_FIELD_DEFAULT_OPTIONS,
      useValue: { appearance: 'fill' },
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
