import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { ServicesService } from 'src/app/Services/services.service';

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private service : ServicesService, private router:Router) { }

  ngOnInit(): void {
  }
  controlName:FormControl = new FormControl();
  name? : string

  OnCreateGamer()
  {
   let userId: number;
   this.service.CreateUser(this.name).subscribe(x => {
     
      userId = (x.id || 0);
      localStorage.setItem("Id", userId.toString())

      if(userId != 0)
      (
         this.router.navigate(['play'])
      )
    })

   
  }
}
