import { Component, OnInit } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { FetchCustomerData } from '../api/FetchCustomerData';
import { MigrateResponse } from '../api/MigrateResponse';

@Component({
  selector: 'app-adminpanel',
  templateUrl: './adminpanel.component.html',
  styleUrls: ['./adminpanel.component.css'],
  providers: [ FetchCustomerData ]
})
export class AdminpanelComponent implements OnInit {
dbCopyStatus: string = 'Not Started';
customerCountOld: number = 0;
customerCountNew: number = 0;
blob:Blob;

  constructor(private fetchCustomerDataService: FetchCustomerData) { }

  ngOnInit(): void {
    this.fetchCustomerDataService.GetCustomerCount()
      .subscribe(        
        (data: number[]) => {
          this.customerCountOld = data[0];
          this.customerCountNew = data[1];
        }, (err) => {
          console.log('-----> err', err);
        });
  }
  CopyCustomersFromOldDb(element: HTMLButtonElement){
    element.textContent = "Migrating all customers...Please wait!";

    this.dbCopyStatus = 'Started';
    this.fetchCustomerDataService.CopyCustomersFromOldDb()
      .subscribe(        
        (data: MigrateResponse) => {
          this.customerCountOld = data.CustomerCountOldDb;
          this.customerCountNew = data.CustomerCountNewDb;
          this.setMigrationStatus(element, data.MigrationStatus);
        }, (err) => {
          console.log('-----> err', err);
          this.setMigrationStatus(element, false);
        });
  }
  setMigrationStatus(element: HTMLButtonElement, isSuccess: boolean){
    if(isSuccess)
    {
          this.dbCopyStatus = 'Success';
          element.textContent = "Migrate all customers and Rationcard Information from old database to new database";
    }
    else
    {
          this.dbCopyStatus = 'Migration Failed';
          element.textContent = 'Migrate all customers and Rationcard Information from old database to new database';
    }
  }
  DownloadCustomerData(){
    this.fetchCustomerDataService.DownloadCustomerData()
      .subscribe(        
        (data: Blob) => {
          console.log('download complete');
          this.blob = new Blob([data], {type: data.type.toString()});

          var downloadURL = window.URL.createObjectURL(data);
          var link = document.createElement('a');
          link.href = downloadURL;
          link.download = "Customers.xlsx";
          link.click();
        }, (err) => {
          console.log('-----> err', err);          
        });
  }
}
