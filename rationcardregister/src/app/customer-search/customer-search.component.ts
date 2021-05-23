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
import {Subject} from 'rxjs';
import { books } from 'googleapis/build/src/apis/books';
import {MatDialog, MatDialogModule} from '@angular/material/dialog';
import { DialogComponent } from '../dialog/dialog.component';

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
  phNo = new FormControl('', [Validators.required, Validators.pattern(/^[0-9]{10}$/)]);
  dt = new FormControl('', [Validators.required, Validators.pattern(/^([1-9]|0[1-9]|1[0-2])\/([1-9]|0[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/)]);
  agev = new FormControl('', [Validators.required, Validators.pattern(/^[0-9]{1,3}$/)]);

  getPhErrMsg() {
    if (this.phNo.hasError('required')) {
      return 'You must enter a value';
    }
    return this.phNo.hasError('pattern') ? 'Not a valid Phone Number' : '';
  }
  getDtErrMsg() {
    if (this.dt.hasError('required')) {
      return 'You must enter a value';
    }
    return this.dt.hasError('pattern') ? 'Not a valid date' : '';
  }
  getAgeErrMsg() {
    if (this.agev.hasError('required')) {
      return 'You must enter a value';
    }
    return this.agev.hasError('pattern') ? 'Not a valid Age' : '';
  }

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
  customers: Array<Customer>;
  hofs: Array<Hof>;
  cardCats: Array<CardCategory>;
  relations: Array<Relation>;
  error: any;
  constructor(
    private cd: ChangeDetectorRef,
    private fetchCustomerDataService: FetchCustomerData,
    public dialog: MatDialog
  ) { }
  

  ngOnInit() {    
    this.getAllCustomers();    
  }
  openDialog(cust: Customer) {
    const dialogRef = this.dialog.open(DialogComponent);

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }
  getAllCustomers(){
    this.fetchCustomerDataService.GetMasterData()
      .subscribe(        
        (data: MasterData) => {
        this.customers = data.Customers;
        console.log(data);
        this.cardCats = data.CardCategories;
        this.relations = data.Relations;
        this.hofs = data.Hofs;
        this.dataSource = new MatTableDataSource(this.customers); 
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        }, (err) => {
          console.log('-----> err', err);
        });
  }

  deleteCustomer(cust: Customer){
    let todelete: Boolean;
    if(cust.IsHof){
      var noOfFamilyMembers = this.customers.filter(a => a.FamilyId == cust.FamilyId);
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
          console.log(cust.CardNumber + ' : ' + cust.Name + ' : delete successful');
          var custIndex = this.customers.findIndex(a => a == cust);
          if (custIndex > -1) {
            this.customers.splice(custIndex, 1);
          }
        //this.dataSource.data.splice(custIndex, 1);
        this.dataSource = new MatTableDataSource(this.customers); 
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        }, (err) => {
          console.log('-----> err', err);
        });
    }      
    else{
      alert('There are other memebers in this family under this Head of the family. Please delete them or assign another head of the family.');
    }
  }
  addCustomer(cust: Customer){
    this.fetchCustomerDataService.AddCustomer(cust)
      .subscribe(        
        (data: boolean) => {
          console.log(data);
        }, (err) => {
          console.log('-----> err', err);
        });
  }
  updateCustomer(cust: Customer){
    this.fetchCustomerDataService.UpdateCustomer(cust)
      .subscribe(        
        (data: boolean) => {
          console.log(data);
        }, (err) => {
          console.log('-----> err', err);
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
    this.customers = undefined;
    this.error = undefined;
  }
  
}

function DialogContentExampleDialog(DialogContentExampleDialog: any) {
  throw new Error('Function not implemented.');
}
