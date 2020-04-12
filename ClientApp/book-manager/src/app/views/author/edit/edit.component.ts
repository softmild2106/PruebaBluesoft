import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthorDto } from '../../../models/AuthorDto.models';
import { DataTransferObject } from '../../../models/DataTransferObject.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BasecomponentComponent } from '../../basecomponent/basecomponent.component';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css'],
})
export class EditComponent extends BasecomponentComponent implements OnInit {
  id: number;
  requestBody: AuthorDto;
  actionUrl = 'Author/';
  endPointComplete = this.baseUrl + this.actionUrl;
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
    // debugger;
    console.log(this.requestBody);
    this.http
      .post(this.endPointComplete + this.id, this.requestBody)
      .subscribe((response: DataTransferObject<AuthorDto>) => {
        console.log(response);
        if (response.header.code === 200) {
          this.openSnackBar('Haz editado correctamente el autor.');
        } else {
          this.openSnackBar('Algo salió mal.');
        }
      });
  }
  getData() {
    this.http
      .get(this.endPointComplete + this.id)
      .subscribe((response: DataTransferObject<AuthorDto>) => {
        console.log(response);
        if (response.header.code !== 200) {
          this.openSnackBar('Algo salió mal.');
        } else {
          this.requestBody = response.data;
          this.isLoading = false;
        }
      });
  }
}
