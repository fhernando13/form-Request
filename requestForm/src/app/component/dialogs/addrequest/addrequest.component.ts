import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';

@Component({
  selector: 'app-addrequest',
  templateUrl: './addrequest.component.html',
  styleUrls: ['./addrequest.component.scss']
})
export class AddrequestComponent implements OnInit {

  constructor(
    public dialogRef : MatDialogRef<AddrequestComponent>,
    @Inject(MAT_DIALOG_DATA) public message: string
  ){}

  ngOnInit() {
    
  }

  onCancel():void{
    this.dialogRef.close();
  }
}
