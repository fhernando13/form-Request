import { Component,Inject,OnInit  } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';

@Component({
  selector: 'app-navigate',
  templateUrl: './navigate.component.html',
  styleUrls: ['./navigate.component.scss']
})
export class NavigateComponent implements OnInit  {

  isDarkThemeActive = this.statusBotton(false);

  constructor(
    @Inject(DOCUMENT)private document: Document,
    private router: Router){

  }

  ngOnInit() {
    this.theme();
  }
 
 statusBotton(themes: boolean){
   // const themes = localStorage.getItem('dark');
   if(localStorage.getItem('dark'))
   {
     return true
   }
   else{
     return false
   }
  }
 
  theme(){
   const dato = localStorage.getItem('dark');
   if(dato){
     this.onChange(true);
   }
   else{
     this.onChange(false);
   }
  }
  
  
   onChange(newValue: boolean){ 
    var dark = this.document.body.classList.add('darkMode');
    console.log(newValue);
    if(newValue){
      localStorage.setItem('dark', JSON.stringify(dark));
    }
    else{
      localStorage.removeItem('dark');
      this.document.body.classList.remove('darkMode');     
    }
  }

  requestForm(){
    console.log("form");
    this.router.navigate(['requestForm']);
  }

  requestlist(){
    console.log("list");
    this.router.navigate(['requestlist']);
  }

  logOut(){
    localStorage.removeItem('dark');
    this.onChange(false);
    this.router.navigate(["/login"]);
  }

}
