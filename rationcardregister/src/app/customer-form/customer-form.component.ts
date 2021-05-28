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
  ViewChild, ViewChildren, QueryList, ChangeDetectorRef, OnInit, Output, EventEmitter 
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
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent implements OnInit {
  @Input() customers: Array<Customer>;
  @Input() hofs: Array<Hof>;
  @Input() cardCats: Array<CardCategory>;
  @Input() relations: Array<Relation>;
  @Input() element: Customer;
  @Output() bindTableDataEvent = new EventEmitter();

  //list autocomplete start
  hofCtrl = new FormControl();
  filteredHofs: Observable<Hof[]>;
  //list autocomplete end
  dialogData: DialogData;

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

  ngOnInit(): void {
  }
  //filter autocomplete list
  private _filterHofs(value: Hof): Hof[] {
    const filterValue = value;

    return this.hofs.filter(h => h == filterValue);
  }
  showHofDialog(hof: Hof){
    const dialogRef = this.dialog.open(HofDetailsComponent, {
      width: '250px',
      data: { pageValue: hof}
    });
  }
  hofSelected(hof: Hof, customerSerial: number){
      console.log('hofName: ' + hof.HofName + 'customerSerial: ' + customerSerial);
      var selecetedCust = this.customers.find(c => c.CustomerSerial == customerSerial);
      selecetedCust.SelectedHof = this.hofs.find(h => h == hof);
      selecetedCust.HofId = selecetedCust.SelectedHof.HofId;
      selecetedCust.HofName = selecetedCust.SelectedHof.HofName;
  }
  displayHofSelect(hof: Hof){
      let displayText = ""; 
      displayText = 'FamilyId: ' + hof.FamilyId + ' HofId: ' + hof.HofId + ' Name: ' + hof.HofName;
      return displayText;
  }
  bindTableData(custoMersToBind: Customer[]){
      this.bindTableDataEvent.emit(custoMersToBind);
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
              this.bindTableData(this.customers);
          }
        }, (err) => {
          console.log('-----> err', err);
        });
      }      
    });
  }
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
}
