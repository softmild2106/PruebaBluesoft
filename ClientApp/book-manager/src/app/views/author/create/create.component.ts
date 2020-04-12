import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthorDto } from '../../../models/AuthorDto.models';
import { DataTransferObject } from '../../../models/DataTransferObject.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BasecomponentComponent } from '../../basecomponent/basecomponent.component';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
})
export class CreateComponent extends BasecomponentComponent implements OnInit {
  requestBody: AuthorDto = { name: '', lastName: '', dateBirth: new Date() };
  actionUrl = 'Author';
  constructor(public http: HttpClient, public _snackBar: MatSnackBar) {
    super(http, _snackBar);
  }

  ngOnInit(): void {}

  HandleSubmit(event: any) {
    event.preventDefault();
    // debugger;
    console.log(this.requestBody);
    this.http
      .post(this.baseUrl + this.actionUrl, this.requestBody)
      .subscribe((response: DataTransferObject<AuthorDto>) => {
        console.log(response);
        if (response.header.code === 200) {
          this.openSnackBar('Haz creado correctamente el autor.');
        } else {
          this.openSnackBar('Algo salió mal.');
        }
      });
  }
}
