// https://code-maze.com/angular-material-table/
import { Component, ViewChild, ViewChildren, QueryList, ChangeDetectorRef, OnInit } from '@angular/core';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource, MatTable } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { FetchCustomerData, customer } from '../FetchCustomerData';

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
  dataSource: MatTableDataSource<customer>;
  expandedElement: customer | null;
  calColumns: string[] = [
  "Name",
  "Age",
  "Address",
  "Adhar_No",
  "Relation_With_Hof",
  "Mobile_No"
  ];
  displayedColumns: string[] = [...this.calColumns, 'Action'];  
  customers: Array<customer>;
  error: any;
  constructor(
    private cd: ChangeDetectorRef,
    private fetchCustomerDataService: FetchCustomerData
  ) { }

  ngOnInit() {    
    this.getAllCostomers();    
  }
  getAllCostomers(){
    this.fetchCustomerDataService.FetchAllCustomers()
      .subscribe(        
        (data: Array<customer>) => {
        this.customers = data;
        console.log(this.customers);
        this.dataSource = new MatTableDataSource(this.customers); 
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        }, (err) => {
          console.log('-----> err', err);
        });
  }
  public doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }
  ngAfterViewInit(): void {
    
  }
  toggleRow(element: customer) {
    this.expandedElement = this.expandedElement === element ? null : element;
    this.cd.detectChanges();
  }
  clear() {
    this.customers = undefined;
    this.error = undefined;
  }
  
}