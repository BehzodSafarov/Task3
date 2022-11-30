import { Component, OnInit } from '@angular/core';
import {  Winner } from 'src/app/models/lider.model';
import { ServicesService } from 'src/app/Services/services.service';

@Component({
  selector: 'lider',
  templateUrl: './lider.component.html',
  styleUrls: ['./lider.component.css']
})
export class LiderComponent implements OnInit {

  constructor(private service:ServicesService) { }

  ngOnInit(): void {
    this.onOutLiders();
  }

  liders: Array<Winner> = new Array<Winner>();
  onOutLiders()
  {
    this.service.GetLiders().subscribe(result =>
      {
        console.log(result)
        this.liders = result;
        console.log(this.liders)
      })
  }

}
