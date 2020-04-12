import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import CategoryDto from '../../../models/CategoryDto.model';
import { DataTransferObject } from '../../../models/DataTransferObject.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BasecomponentComponent } from '../../basecomponent/basecomponent.component';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
})
export class ListComponent extends BasecomponentComponent implements OnInit {
  constructor(public http: HttpClient, public _snackBar: MatSnackBar) {
    super(http, _snackBar);
  }
  dataSource: CategoryDto[];
  actionUrl = 'Category/';
  endPointComplete = this.baseUrl + this.actionUrl;

  ngOnInit(): void {
    this.getData();
  }

  handleDelete(event: any, idToDelete: number) {
    event.preventDefault();
    console.log(idToDelete);
    if (confirm('Estas seguro que deseas borrar este registro?')) {
      console.log(this.endPointComplete + idToDelete);
      this.http
        .delete(this.endPointComplete + idToDelete)
        .subscribe((response: DataTransferObject<CategoryDto>) => {
          console.log(response);
          if (response.header.code !== 200) {
            this.openSnackBar('Algo salió mal.');
          } else {
            this.getData();
          }
        });
    }
  }

  getData() {
    this.http
      .get(this.endPointComplete)
      .subscribe((response: DataTransferObject<CategoryDto[]>) => {
        console.log(response);
        if (response.header.code !== 200) {
          this.openSnackBar('Algo salió mal.');
        } else {
          this.dataSource = response.data;
          this.isLoading = false;
        }
      });
  }
}
