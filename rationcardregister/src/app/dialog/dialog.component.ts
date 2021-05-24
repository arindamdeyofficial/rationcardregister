import { Component, Inject, Input, OnInit, Optional } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Customer } from '../api/Customer';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent implements OnInit {
  @Input() dialogContent: DialogData;
  dialogData: DialogData;
  constructor(public dialog: MatDialog,
    public dialogRef: MatDialogRef<DialogComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: any) { 
      this.dialogData = data.pageValue;
  }

  ngOnInit(): void {
  }
}
export class DialogData {
  Header: string;
  Body: string;
  DType: string;
}
