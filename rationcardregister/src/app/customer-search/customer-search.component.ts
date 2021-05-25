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

  //validation start

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
//validation ends

  //list autocomplete start
  hofCtrl = new FormControl();
  filteredHofs: Observable<Hof[]>;
  selectedHof: Hof;
  //list autocomplete end

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
  dialogData: DialogData;
  newCustomer: Customer;

  constructor(
    private cd: ChangeDetectorRef,
    private fetchCustomerDataService: FetchCustomerData,
    public dialog: MatDialog,
    media: MediaMatcher
    , iconRegistry: MatIconRegistry, sanitizer: DomSanitizer
  ) { 
    iconRegistry
    .addSvgIcon(
      'add',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/add_circle_black_24dp.svg')) 
    .addSvgIcon(
      'call',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/call_black_24dp.svg')) 
    .addSvgIcon(
      'card',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/credit_card_black_24dp.svg')) 
    .addSvgIcon(
      'hof',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/supervisor_account_black_24dp.svg'))
    .addSvgIcon(
      'adhar',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/card_membership_black_24dp.svg')) 
    .addSvgIcon(
      'done',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/done_all_black_24dp.svg'))
    .addSvgIcon(
      'contact',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/assignment_ind_black_24dp.svg'))
    .addSvgIcon(
      'birthday',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/cake_black_24dp.svg'))      
    .addSvgIcon(
      'gaurdian',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/groups_black_24dp.svg'))
    .addSvgIcon(
      'relation',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/wc_black_24dp.svg'))
    .addSvgIcon(
      'address',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/menu/gite_black_24dp.svg'))
      ;

      //list autocomplete
      this.filteredHofs = this.hofCtrl.valueChanges
      .pipe(
        startWith(''),
        map(val => val ? this._filterHofs(val) : this.hofs.slice())
      );
  }
  //filter autocomplete list
  private _filterHofs(value: string): Hof[] {
    const filterValue = value.toLowerCase();

    return this.hofs.filter(h => h.HofName.toLowerCase().indexOf(filterValue) === 0);
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
  getAllCustomers(){
    this.fetchCustomerDataService.GetMasterData()
      .subscribe(        
        (data: MasterData) => {
        this.customers = data.Customers;
        console.log('successfully all customer data fetched.');
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
    if((cust != undefined) && (cust.CustomerSerial == undefined)){
      this.dataSource = new MatTableDataSource(this.customers);
    }
    else{
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
            //if deleted successfully
            if(data){
              console.log(cust.CardNumber + ' : ' + cust.Name + ' : delete successful');
              var custIndex = this.customers.findIndex(a => a == cust);
              if (custIndex > -1) {
                this.customers.splice(custIndex, 1);
              }
            //this.dataSource.data.splice(custIndex, 1);
            this.dataSource = new MatTableDataSource(this.customers); 
            this.dataSource.sort = this.sort;
            this.dataSource.paginator = this.paginator;
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
    + 'customer array length: ' + this.customers.length);
    this.newCustomer = new Customer();
    //this.newCustomer = this.customers[1];
    this.dataSource = new MatTableDataSource([this.newCustomer, ...this.customers]);
    console.log('after add || dataSource length: ' + this.dataSource.data.length.toString()
    + 'customer array length: ' + this.customers.length);
  }
  addOrEditCustomer(cust: Customer){
    console.log(cust);
    var isNewRecord = cust.CustomerRowId == undefined;
    if(isNewRecord){
      var relG = this.relations.find(r => r.RelationDesc == cust.GaurdianRelation);
      if(relG != undefined){
        cust.GaurdianRelId = relG.RelationId;
      }
      var relH = this.relations.find(r => r.RelationDesc == cust.RelationWithHof);
      if(relH != undefined){
        cust.RelationWithHofId = relH.RelationId;
      }
      var hof = this.hofs.find(r => r.HofName == cust.HofName);
      if(hof != undefined){
        cust.HofId = hof.HofId;
      }
      var cat = this.cardCats.find(r => r.CardCategoryDesc == cust.CardCategory);
      if(cat != undefined){
        cust.CardCategoryId = cat.CardCategoryId;
      }
    }
    this.dialogData = new DialogData();
    this.dialogData.Header = 'Add New Customer';
    this.dialogData.Body = 'Sure? you want to add this customer!';
    this.dialogData.DType = 'okcancel';
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '250px',
      data: { pageValue: this.dialogData}
    });
    dialogRef.afterClosed().subscribe(result => {
      if(result){
        this.fetchCustomerDataService.AddOrEditCustomer(cust)
      .subscribe(        
        (data: boolean) => {
          console.log(data);
          if(data && isNewRecord){
            this.customers = [cust, ...this.customers];
            this.dataSource = new MatTableDataSource(this.customers); 
            this.dataSource.sort = this.sort;
            this.dataSource.paginator = this.paginator;
          }
        }, (err) => {
          console.log('-----> err', err);
        });
      }      
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
