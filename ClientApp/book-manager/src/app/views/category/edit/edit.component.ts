import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import CategoryDto from '../../../models/CategoryDto.model';
import { DataTransferObject } from '../../../models/DataTransferObject.model';
import { environment } from '../../../../environments/environment';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BasecomponentComponent } from '../../basecomponent/basecomponent.component';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css'],
})
export class EditComponent extends BasecomponentComponent implements OnInit {
  id: number;
  response: DataTransferObject<CategoryDto>;
  actionUrl = 'Category/';
  endPointComplete = this.baseUrl + this.actionUrl;
  categoryName = '';
  categoryDescription = '';
  requestBody: CategoryDto;

  constructor(
    private activatedRoute: ActivatedRoute,
    public http: HttpClient,
    public _snackBar: MatSnackBar
  ) {
    super(http, _snackBar);
  }

  ngOnInit(): void {
    this.id = this.activatedRoute.snapshot.params.id;
    this.getData();
  }

  HandleSubmit(event: any) {
    event.preventDefault();
    this.isLoading = true;
    this.requestBody = {
      name: this.categoryName,
      description: this.categoryDescription,
    };
    console.log(this.requestBody);
    this.http
      .post(this.endPointComplete + this.id, this.requestBody)
      .subscribe((response: DataTransferObject<CategoryDto>) => {
        console.log(response);
        if (response.header.code === 200) {
          this.openSnackBar('Editaste correctamente la categoria.');
        } else {
          this.openSnackBar('Algo salió mal.');
        }
        this.isLoading = false;
      });
  }

  getData() {
    this.http
      .get(this.endPointComplete + this.id)
      .subscribe((response: DataTransferObject<CategoryDto>) => {
        console.log(response);
        if (response.header.code !== 200) {
          this.openSnackBar('Algo salió mal.');
        } else {
          this.categoryName = response.data.name;
          this.categoryDescription = response.data.description;
          this.isLoading = false;
        }
      });
  }
}
