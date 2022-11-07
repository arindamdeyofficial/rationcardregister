// https://stackblitz.com/angular/brlxgpnjggjb?file=src%2Fapp%2Fconfig%2Fconfig.component.ts
// https://angular.io/guide/http
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpResponse, HttpClientModule, HttpHeaders, HttpParams } from '@angular/common/http';
import { MasterData } from './MasterData';
import { Customer } from './Customer';
import { MigrateResponse } from './MigrateResponse';

@Injectable()
export class FetchCustomerData {
    baseUrl = 'https://localhost:44330';
    httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
        //,'Access-Control-Allow-Origin': '*'
        //, Authorization: 'my-auth-token'
      })
    };
  constructor(private http: HttpClient) { }

  CopyCustomersFromOldDb() {
    return this.http.get<MigrateResponse>(this.baseUrl + '/Admin/CopyCustomersFromOldDb')
      .pipe(
        retry(3), // retry a failed request up to 3 times
        catchError(this.handleError) // then handle the error
      );
  }
  GetMasterData() {
    return this.http.get<MasterData>(this.baseUrl + '/Customer/GetMasterData')
      .pipe(
        retry(3), // retry a failed request up to 3 times
        catchError(this.handleError) // then handle the error
      );
  }
  FetchAllCustomers() {
    return this.http.get<Array<Customer>>(this.baseUrl + '/Customer/FetchAllCustomers')
      .pipe(
        retry(3), // retry a failed request up to 3 times
        catchError(this.handleError) // then handle the error
      );
  }
  DeleteCustomer(cust: Customer) {
    return this.http.post<Boolean>(this.baseUrl + '/Customer/DeleteCustomer', cust, this.httpOptions)
      .pipe(
        retry(3), // retry a failed request up to 3 times
        catchError(this.handleError) // then handle the error
      );
  }
  AddOrEditCustomer(cust: Customer) {
    return this.http.post<Boolean>(this.baseUrl + '/Customer/AddOrEditCustomer', cust, this.httpOptions)
      .pipe(
        retry(3), // retry a failed request up to 3 times
        catchError(this.handleError) // then handle the error
      );
  }
  DownloadCustomerData() {
    const httpOptionsDownload = {
      responseType: 'blob' as 'json'
    };
    return this.http.get<File>(this.baseUrl + '/Admin/DownloadCustomerData', httpOptionsDownload)
      .pipe(
        retry(3), // retry a failed request up to 3 times
        catchError(this.handleError) // then handle the error
      );
  }
  GetCustomerCount() {
    return this.http.get<number[]>(this.baseUrl + '/Admin/GetCustomerCount')
      .pipe(
        retry(3), // retry a failed request up to 3 times
        catchError(this.handleError) // then handle the error
      );
  }
  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // Return an observable with a user-facing error message.
    return throwError(
      'Something bad happened; please try again later.');
  }
}