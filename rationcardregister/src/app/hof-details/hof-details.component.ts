import { Component, Inject, Input, OnInit, Optional } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Hof } from '../api/Hof';

@Component({
  selector: 'app-hof-details',
  templateUrl: './hof-details.component.html',
  styleUrls: ['./hof-details.component.css']
})
export class HofDetailsComponent implements OnInit {
  @Input() dialogContent: Hof;
  hof: Hof;
  constructor(public dialog: MatDialog,
    public dialogRef: MatDialogRef<HofDetailsComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: any) { 
      this.hof = data.pageValue;
  }

  ngOnInit(): void {
  }

}
