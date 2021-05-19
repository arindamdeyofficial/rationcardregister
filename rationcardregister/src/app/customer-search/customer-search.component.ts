// https://code-maze.com/angular-material-table/
import { Component, ViewChild, ViewChildren, QueryList, ChangeDetectorRef, OnInit } from '@angular/core';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource, MatTable } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { FlexLayoutModule } from '@angular/flex-layout';
import {MatFormFieldModule} from '@angular/material/form-field';

@Component({
  selector: 'app-customer-search',
  templateUrl: './customer-search.component.html',
  styleUrls: ['./customer-search.component.css'],
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

  constructor(
    private cd: ChangeDetectorRef
  ) { }

  ngOnInit() {    
    this.dataSource = new MatTableDataSource(customers); 
  }
  public doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }
  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }
  toggleRow(element: customer) {
    this.expandedElement = this.expandedElement === element ? null : element;
    this.cd.detectChanges();
  }
}
export interface customer {
  Name: string;
  Age: number;
  Address: string;
  Adhar_No: number;
  Relation_With_Hof: string;
  Mobile_No: number;
}

const customers: customer[] = [
  {
    "Name": "MINATI GHOSE",
    "Age": 57,
    "Address": "PRAGATI PALLI, RAJPUR SONARPUR,24(s)-700147",
    "Adhar_No": 56464564,
    "Relation_With_Hof": "Self",
    "Mobile_No": 7278481425
  },
  {
    "Name": "ABHIJT GHOSE",
    "Age": 24,
    "Address": "PRAGATI PALLI, RAJPUR SONARPUR,24(s)-700147",
    "Adhar_No": 333956000000,
    "Relation_With_Hof": "Son",
    "Mobile_No": 7278481425
  },
  {
    "Name": "RAMENDRA BHHATTACHRYA",
    "Age": 70,
    "Address": "MN BASU ROAD, WARD NO-2, SONARPUR,S24 PGS",
    "Adhar_No": 268838000000,
    "Relation_With_Hof": "Self",
    "Mobile_No": 8582852728
  },
  {
    "Name": "KAISAR ALAM",
    "Age": 28,
    "Address": "GANIMA ROAD, NEAR SALEHA MASJID MALLICKPUR HABIB CHAWK, MALLIKPORE RSM WARD NO-21",
    "Adhar_No": 425522000000,
    "Relation_With_Hof": "Self",
    "Mobile_No": 7044188543
  }
];