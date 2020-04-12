import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BookComponent } from './views/book/book.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './components/navbar/navbar.component';
import { MaterialModule } from './material-module';
import { ReactiveFormsModule } from '@angular/forms';
import { CreateComponent as CreateCategoryComponent } from './views/category/create/create.component';
import { MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { EditComponent } from './views/category/edit/edit.component';
import { BasecomponentComponent } from './views/basecomponent/basecomponent.component';
import { ListComponent } from './views/category/list/list.component';
import { CustomTableComponent } from './components/custom-table/custom-table.component';
@NgModule({
  declarations: [
    AppComponent,
    BookComponent,
    NavbarComponent,
    CreateCategoryComponent,
    EditComponent,
    BasecomponentComponent,
    ListComponent,
    CustomTableComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    MaterialModule,
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
