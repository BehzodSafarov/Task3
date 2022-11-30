import { Component, OnInit } from '@angular/core';
import { FormControl,FormBuilder,Validators,FormGroup,Validator} from "@angular/forms";
import { Route, Router } from '@angular/router';
import { Attempt } from 'src/app/models/attempt.model';
import { ServicesService } from 'src/app/Services/services.service';

@Component({
  selector: 'play',
  templateUrl: './play.component.html',
  styleUrls: ['./play.component.css']
})
export class PlayComponent implements OnInit {

  constructor(private services : ServicesService,private router : Router) { }

  ngOnInit(): void {
  
  }
  
  contrloNumber : FormControl = new FormControl();

  number?:string
  
  ended:boolean = false;
  win: boolean = false;
  attempt:number = 8;
  attempts: Array<Attempt> = new Array<Attempt>();

  onClickCreateUser()
  {
    this.services.PlayGame(this.number??"2345",localStorage.getItem("Id")??"").subscribe(responce =>
      {
        if(responce[0].p == 4)
        {
          this.win = true;
        }
        if(responce.length == 8 || responce[0].p == 4)
        {
          this.ended = true;
        }
        else
        this.ended = false
        this.attempts = responce;
        this.attempt=8- responce.length;
        console.log(this.attempts)
      })
      
  }
}
