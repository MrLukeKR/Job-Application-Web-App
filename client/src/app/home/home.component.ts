import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  adminMode = false;

  constructor() { }

  ngOnInit(): void {
  }

  // Simple switch between application form and existing applicant views
  applicantViewToggle(){
    this.adminMode = !this.adminMode;
  }
}