import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-landingpage',
  templateUrl: './landingpage.component.html',
  styleUrls: ['./landingpage.component.css']
})
export class LandingpageComponent implements OnInit {
  rationcardPicPath= "assets/img/rationcard.jpg";
  constructor() { }

  ngOnInit(): void {
  }

}
