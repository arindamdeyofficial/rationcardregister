import { Component, OnInit } from '@angular/core';
import { FetchCustomerData } from '../api/FetchCustomerData';

@Component({
  selector: 'app-adminpanel',
  templateUrl: './adminpanel.component.html',
  styleUrls: ['./adminpanel.component.css'],
  providers: [ FetchCustomerData ]
})
export class AdminpanelComponent implements OnInit {
dbCopyStatus: boolean = false;
  constructor(private fetchCustomerDataService: FetchCustomerData) { }

  ngOnInit(): void {
  }
  CopyCustomersFromOldDb(){
    this.dbCopyStatus = true;
    this.fetchCustomerDataService.CopyCustomersFromOldDb()
      .subscribe(        
        (data: boolean) => {
          console.log(data);
          this.dbCopyStatus = false;
        }, (err) => {
          console.log('-----> err', err);
          this.dbCopyStatus = false;
        });
  }
}
