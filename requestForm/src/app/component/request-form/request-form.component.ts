import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';

// Angular Material
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-request-form',
  templateUrl: './request-form.component.html',
  styleUrls: ['./request-form.component.scss']
})
export class RequestFormComponent implements OnInit {

  displayedColumns: string[] = [ '#', 'requirement', 'description', 'img'];
  dataSource = new MatTableDataSource();

  title="request for requirements";
  today =  formatDate(new Date(), 'yyyy-MM-dd', 'en-US');
  subtitle= "applicant information ";
  subtitle2 = "informatoin about the request";
  subtitle3 = "general objective";

  constructor(){

  }

  ngOnInit(): void {
    
  }



}

