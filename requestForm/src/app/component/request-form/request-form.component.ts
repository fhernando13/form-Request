import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddrequestComponent } from '../dialogs/addrequest/addrequest.component';

// Angular Material
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-request-form',
  templateUrl: './request-form.component.html',
  styleUrls: ['./request-form.component.scss']
})
export class RequestFormComponent implements OnInit {

  displayedColumns: string[] = [ '#', 'requirement', 'description'];
  dataSource = new MatTableDataSource();

  title="request for requirements";
  today =  formatDate(new Date(), 'yyyy-MM-dd', 'en-US');
  subtitle= "applicant information ";
  subtitle2 = "information about the request";
  subtitle3 = "general objective";
  subtitle4 = "Requirements";

  constructor(
    public dialog: MatDialog
  ){

  }

  ngOnInit(): void {
    
  }

  openDialog(){
    const dialogRef = this.dialog.open(AddrequestComponent)
  }


}

