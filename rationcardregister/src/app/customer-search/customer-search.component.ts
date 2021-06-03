// https://code-maze.com/angular-material-table/
import { animate, state, style, transition, trigger } from '@angular/animations';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource, MatTable } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { FetchCustomerData } from '../api/FetchCustomerData';
import { MasterData } from '../api/MasterData';
import { Customer } from '../api/Customer';
import { CardCategory } from '../api/CardCategory';
import { Relation } from '../api/Relation';
import { Hof } from '../api/Hof';
import {FocusMonitor} from '@angular/cdk/a11y';
import {BooleanInput, coerceBooleanProperty} from '@angular/cdk/coercion';
import {
  Component,
  ElementRef,
  Inject,
  Input,
  OnDestroy,
  Optional,
  Self,
  ViewChild, ViewChildren, QueryList, ChangeDetectorRef, OnInit 
} from '@angular/core';
import {
  AbstractControl,
  ControlValueAccessor,
  FormBuilder,
  FormControl,
  FormGroup,
  NgControl,
  Validators,
  FormsModule, 
  ReactiveFormsModule
} from '@angular/forms';
import {MAT_FORM_FIELD, MatFormField, MatFormFieldControl} from '@angular/material/form-field';
import {Subject, Observable} from 'rxjs';
import { books } from 'googleapis/build/src/apis/books';
import {MatDialog, MatDialogModule} from '@angular/material/dialog';
import { DialogComponent, DialogData } from '../dialog/dialog.component';
import {DomSanitizer} from '@angular/platform-browser';
import {MatIconRegistry} from '@angular/material/icon';
import {MediaMatcher} from '@angular/cdk/layout';
import {map, startWith} from 'rxjs/operators';
import { HofDetailsComponent } from '../hof-details/hof-details.component';

@Component({
  selector: 'app-customer-search',
  templateUrl: './customer-search.component.html',
  styleUrls: ['./customer-search.component.css'],
  providers: [ FetchCustomerData ],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class CustomerSearchComponent implements OnInit {
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  dataSource: MatTableDataSource<Customer>;
  expandedElement: Customer | null;
  calColumns: string[] = [
  "FamilyId",
  "CustomerSerial",
  "Name",
  "CardNumber",
  "AdharNo",
  "MobileNo",  
  "HofName"
  ];
  displayedColumns: string[] = ["Details", ...this.calColumns,
  "IsHof",
  "Active",
  'Action'];  
  error: any;
  dialogData: DialogData;
  newCustomer: Customer;  
  masterData: MasterData = new MasterData();

  constructor(
    private cd: ChangeDetectorRef,
    private fetchCustomerDataService: FetchCustomerData,
    public dialog: MatDialog,
    media: MediaMatcher
    , iconRegistry: MatIconRegistry, sanitizer: DomSanitizer
  ) { 
    iconRegistry
    .addSvgIcon(
      'search',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/search_black_24dp.svg'))
    ;
  }
  

  ngOnInit() {    
    this.getAllCustomers();    
  }
  openDeleteDialog(cust: Customer) {
    this.dialogData = new DialogData();
    this.dialogData.Header = 'Delete Customer';
    this.dialogData.Body = 'You sure want to delete the customer!';
    this.dialogData.DType = 'okcancel';
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '250px',
      data: { pageValue: this.dialogData}
    });
    dialogRef.afterClosed().subscribe(result => {
      if(result){
        this.deleteCustomer(cust);
      }      
    });
  }  
  getAllCustomers(){
    this.fetchCustomerDataService.GetMasterData()
      .subscribe(        
        (data: MasterData) => {
            this.masterData.Customers = data.Customers;
            console.log('successfully all customer data fetched.');
            this.masterData.CardCategories = data.CardCategories;
            this.masterData.Relations = data.Relations;
            this.masterData.Hofs = data.Hofs;
            this.masterData.Customers.forEach(a =>{ 
              a.SelectedHof = this.masterData.Hofs.find(h => h.HofId == a.HofId);             
            });
            this.masterData.CategoryWiseCount = data.CategoryWiseCount;
            this.bindTableData(this.masterData.Customers);
        }, (err) => {
          console.log('-----> err', err);
        });
  }
  bindTableData(customersToBind: Customer[])
  {
        this.dataSource = new MatTableDataSource(customersToBind); 
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
  }

  deleteCustomer(cust: Customer){
    if((cust != undefined) && (cust.CustomerSerial == undefined)){
      this.dataSource = new MatTableDataSource(this.masterData.Customers);
    }
    else{
      let todelete: Boolean;
      if(cust.IsHof){
        var noOfFamilyMembers = this.masterData.Customers.filter(a => a.FamilyId == cust.FamilyId);
        console.log(cust.CardNumber + ' : ' + cust.Name + ' : HOF : noOfFamilyMembers: ' + noOfFamilyMembers.length);
        if(noOfFamilyMembers.length > 1){
          todelete = false;
        }
        else{
          todelete = true;
        }      
      } else
      {
        todelete = true;
      }
      if(todelete){
        console.log(cust.CardNumber + ' : ' + cust.Name + ' : delete started ');
        this.fetchCustomerDataService.DeleteCustomer(cust)
        .subscribe(        
          (data: boolean) => {
            //if deleted successfully
            if(data){
              console.log(cust.CardNumber + ' : ' + cust.Name + ' : delete successful');
              var custIndex = this.masterData.Customers.findIndex(a => a == cust);
              if (custIndex > -1) {
                this.masterData.Customers.splice(custIndex, 1);
              }
            //this.dataSource.data.splice(custIndex, 1);
            this.bindTableData(this.masterData.Customers);
            }          
          }, (err) => {
            console.log('-----> err', err);
          });
      }      
      else{
        this.openInfoDialog('There are other memebers in this family under this Head of the family. Please delete them or assign another head of the family.',
        'Delete Not Allowed!');
      }
    }
  }
  addNewCustomer(){
    console.log('add new customer || dataSource length: ' + this.dataSource.data.length.toString()
    + 'customer array length: ' + this.masterData.Customers.length);
    this.newCustomer = new Customer();
    this.bindTableData([this.newCustomer, ...this.masterData.Customers]);
    console.log('after add || dataSource length: ' + this.dataSource.data.length.toString()
    + 'customer array length: ' + this.masterData.Customers.length);
  }
  openInfoDialog(info: string, header:string) {
    this.dialogData = new DialogData();
    this.dialogData.Header = header;
    this.dialogData.Body = info;
    this.dialogData.DType = 'ok';
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '250px',
      data: { pageValue: this.dialogData}
    });
  }
  public doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }
  toggleRow(element: Customer) {
    this.expandedElement = this.expandedElement === element ? null : element;
    this.cd.detectChanges();
  }
  clear() {
    this.masterData.Customers = undefined;
    this.error = undefined;
  }
  
}
