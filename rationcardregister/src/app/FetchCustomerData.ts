// https://stackblitz.com/angular/brlxgpnjggjb?file=src%2Fapp%2Fconfig%2Fconfig.component.ts
// https://angular.io/guide/http
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpResponse, HttpClientModule } from '@angular/common/http';

export interface customer {
    Customer_Id: number;
    Name: string;
    Age: number;
    Address: string;
    Adhar_No: string;
    Relation_With_Hof: string;
    Mobile_No: string;
  }
@Injectable()
export class FetchCustomerData {
    url = 'https://localhost:5001/Customer';
  constructor(private http: HttpClient) { }
  FetchAllCustomers() {
    return this.http.get<Array<customer>>(this.url)
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