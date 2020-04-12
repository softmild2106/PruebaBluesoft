import { Component, OnInit } from '@angular/core';
import CategoryDto from '../../../models/CategoryDto.model';
import { DataTransferObject } from '../../../models/DataTransferObject.model';
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
})
export class CreateComponent implements OnInit {
  response: DataTransferObject<CategoryDto>;
  baseUrl: string = environment.SITE_URL;
  actionUrl = 'Category';
  categoryName = '';
  categoryDescription = '';
  requestBody: CategoryDto;
  constructor(private http: HttpClient, private _snackBar: MatSnackBar) {}

  ngOnInit(): void {
    // debugger;
    this.http
      .get(this.baseUrl + this.actionUrl)
      .subscribe(
        (response: DataTransferObject<DataTransferObject<CategoryDto>>) => {
          console.log(response);
        }
      );
  }

  HandleSubmit(event: any) {
    event.preventDefault();
    this.requestBody = {
      name: this.categoryName,
      description: this.categoryDescription,
    };
    // debugger;
    console.log(this.requestBody);
    this.http
      .post(this.baseUrl + this.actionUrl, this.requestBody)
      .subscribe((response: DataTransferObject<CategoryDto>) => {
        console.log(response);
        if (response.header.code === 200) {
          this.openSnackBar('Haz creado correctamente la categoria.');
        } else {
          this.openSnackBar('Algo salió mal.');
        }
      });
  }

  openSnackBar(message: string) {
    this._snackBar.open(message, 'ok', {
      duration: 2000,
    });
  }
}
