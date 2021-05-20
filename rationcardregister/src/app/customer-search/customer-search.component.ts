// https://code-maze.com/angular-material-table/
import { Component, ViewChild, ViewChildren, QueryList, ChangeDetectorRef, OnInit } from '@angular/core';
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
  "Name",
  "CardNumber",
  "AdharNo",
  "MobileNo",
  "IsHof",
  "HofId",
  "Active"
  ];
  displayedColumns: string[] = [...this.calColumns, 'Action'];  
  customers: Array<Customer>;
  hofs: Array<Hof>;
  cardCats: Array<CardCategory>;
  relations: Array<Relation>;
  error: any;
  constructor(
    private cd: ChangeDetectorRef,
    private fetchCustomerDataService: FetchCustomerData
  ) { }

  ngOnInit() {    
    this.getAllCustomers();    
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
    this.fetchCustomerDataService.DeleteCustomer(cust)
      .subscribe(        
        (data: boolean) => {
        console.log(data);
        }, (err) => {
          console.log('-----> err', err);
        });
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
  ngAfterViewInit(): void {
    
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