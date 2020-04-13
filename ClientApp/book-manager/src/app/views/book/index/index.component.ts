import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import CategoryDto from '../../../models/CategoryDto.model';
import { BookDto } from '../../../models/BookDto.model';
import { AuthorDto } from '../../../models/AuthorDto.models';
import { BookFilterDto } from '../../../models/BookFilterDto.model';
import { DataTransferObject } from '../../../models/DataTransferObject.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BasecomponentComponent } from '../../basecomponent/basecomponent.component';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css'],
})
export class IndexComponent extends BasecomponentComponent implements OnInit {
  constructor(public http: HttpClient, public _snackBar: MatSnackBar) {
    super(http, _snackBar);
  }

  bookFilter: BookFilterDto;
  authors: AuthorDto[];
  categories: CategoryDto[];
  dataSource: BookDto[];
  authorUrl = 'author/';
  categoryUrl = 'Category/';
  bookUrl = 'Book/';
  getBookWithParamsUrl = 'Book/GetBookList';
  typeSearch: number = 0;
  searchText: string;
  categoryId: number;
  authorId: number;

  ngOnInit(): void {
    this.getCategories();
    this.getAuthors();
    this.getData();
  }

  handleSearch(event: any) {
    event.preventDefault();
    let params = new HttpParams().set('SearchType', this.typeSearch.toString());
    console.log(this.typeSearch);
    switch (this.typeSearch.toString()) {
      case '1': {
        params = params.set('Name', this.searchText);
        break;
      }
      case '2': {
        params = params.set('CategoryId', this.categoryId.toString());
        break;
      }
      case '3': {
        params = params.set('AuthorId', this.authorId.toString());
        break;
      }
      default: {
        this.openSnackBar('Debes seleccionar una opción de búsqueda.');
        break;
      }
    }
    this.getData(params);
  }

  handleDelete(event: any, idToDelete: number) {
    event.preventDefault();
    console.log(idToDelete);
    if (confirm('Estas seguro que deseas borrar este registro?')) {
      this.http
        .delete(this.baseUrl + this.bookUrl + idToDelete)
        .subscribe((response: DataTransferObject<AuthorDto>) => {
          console.log(response);
          if (response.header.code !== 200) {
            this.openSnackBar('Algo salió mal.');
          } else {
            this.getData();
          }
        });
    }
  }

  getData(params?: HttpParams) {
    this.http
      .get(this.baseUrl + this.getBookWithParamsUrl, { params })
      .subscribe((response: DataTransferObject<BookDto[]>) => {
        console.log(response);
        if (response.header.code !== 200) {
          this.openSnackBar('Algo salió mal.');
        } else {
          this.dataSource = response.data;
          this.isLoading = false;
        }
      });
  }

  getCategories() {
    this.http
      .get(this.baseUrl + this.categoryUrl)
      .subscribe((response: DataTransferObject<CategoryDto[]>) => {
        console.log(response);
        if (response.header.code !== 200) {
          this.openSnackBar('Algo salió mal.');
        } else {
          this.categories = response.data;
        }
      });
  }

  getAuthors() {
    this.http
      .get(this.baseUrl + this.authorUrl)
      .subscribe((response: DataTransferObject<AuthorDto[]>) => {
        console.log(response);
        if (response.header.code !== 200) {
          this.openSnackBar('Algo salió mal.');
        } else {
          this.authors = response.data;
        }
      });
  }
}
