import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import CategoryDto from '../../../models/CategoryDto.model';
import { BookDto } from '../../../models/BookDto.model';
import { AuthorDto } from '../../../models/AuthorDto.models';
import { DataTransferObject } from '../../../models/DataTransferObject.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BasecomponentComponent } from '../../basecomponent/basecomponent.component';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css'],
})
export class EditComponent extends BasecomponentComponent implements OnInit {
  constructor(
    private activatedRoute: ActivatedRoute,
    public http: HttpClient,
    public _snackBar: MatSnackBar
  ) {
    super(http, _snackBar);
  }
  id: number;
  requestBody: BookDto = { bookName: '', authorId: 0, categoryId: 0, isbn: '' };
  author: AuthorDto;
  authors: AuthorDto[];
  categories: CategoryDto[];
  authorUrl = 'author/';
  categoryUrl = 'Category/';
  bookUrl = 'Book/';
  filteredAuthorOptions: Observable<AuthorDto[]>;
  myControl = new FormControl();
  categoryId: number;

  ngOnInit(): void {
    this.id = this.activatedRoute.snapshot.params.id;
    this.getAuthors();
    this.getCategories();
    this.getData();
  }

  getData() {
    this.http
      .get(this.baseUrl + this.bookUrl + this.id)
      .subscribe((response: DataTransferObject<BookDto>) => {
        if (response.header.code !== 200) {
          this.openSnackBar('Algo salió mal.');
        } else {
          this.requestBody = response.data;
          console.log(this.requestBody);
          console.log(this.authors);
          let author = this.authors.find(
            (a) => a.id === this.requestBody.authorId
          );

          console.log(author);
          this.myControl.setValue(author);
          this.isLoading = false;
        }
      });
  }

  HandleSubmit(event: any) {
    event.preventDefault();
    // debugger;
    console.log(this.requestBody);
    this.http
      .post(this.baseUrl + this.bookUrl, this.requestBody)
      .subscribe((response: DataTransferObject<BookDto>) => {
        console.log(response);
        if (response.header.code === 200) {
          this.openSnackBar('Haz creado correctamente el libro.');
        } else {
          this.openSnackBar('Algo salió mal.');
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
          this.isLoading = false;
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
          this.filteredAuthorOptions = this.myControl.valueChanges.pipe(
            startWith(''),
            map((value) => {
              if (typeof value === 'string') {
                return value;
              } else {
                this.requestBody.authorId = value.id;
                return value.fullName;
              }
            }),
            map((name) => (name ? this._filter(name) : this.authors.slice()))
          );
        }
      });
  }

  displayFn(userT: AuthorDto): string {
    return userT && userT.fullName ? userT.fullName : '';
  }

  private _filter(value: string): AuthorDto[] {
    console.log(value);
    console.log(this.requestBody.authorId);
    const filterValue = value.toLowerCase();
    return this.authors.filter(
      (option) => option.name.toLowerCase().indexOf(filterValue) === 0
    );
  }
}
