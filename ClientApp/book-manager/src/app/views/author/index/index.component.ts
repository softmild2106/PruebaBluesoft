import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import AuthorDto from '../../../models/CategoryDto.model';
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

  dataSource: AuthorDto[];
  actionUrl = 'Author/';
  endPointComplete = this.baseUrl + this.actionUrl;

  ngOnInit(): void {
    this.getData();
  }

  getData() {
    this.http
      .get(this.endPointComplete)
      .subscribe((response: DataTransferObject<AuthorDto[]>) => {
        console.log(response);
        if (response.header.code !== 200) {
          this.openSnackBar('Algo salió mal.');
        } else {
          this.dataSource = response.data;
          this.isLoading = false;
        }
      });
  }

  handleDelete(event: any, idToDelete: number) {
    event.preventDefault();
    console.log(idToDelete);
    if (confirm('Estas seguro que deseas borrar este registro?')) {
      console.log(this.endPointComplete + idToDelete);
      this.http
        .delete(this.endPointComplete + idToDelete)
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
}
