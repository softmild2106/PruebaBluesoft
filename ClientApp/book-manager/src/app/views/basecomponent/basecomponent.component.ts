import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-basecomponent',
  templateUrl: './basecomponent.component.html',
  styleUrls: ['./basecomponent.component.css'],
})
export class BasecomponentComponent implements OnInit {
  constructor(public http: HttpClient, public _snackBar: MatSnackBar) {}

  isLoading = true;
  baseUrl: string = environment.SITE_URL;
  ngOnInit(): void {}

  openSnackBar(message: string) {
    this._snackBar.open(message, 'ok', {
      duration: 2000,
    });
  }
}
