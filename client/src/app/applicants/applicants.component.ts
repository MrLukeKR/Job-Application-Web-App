import { DatePipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Applicant } from '../_models/applicant';

@Component({
  selector: 'app-applicants',
  templateUrl: './applicants.component.html',
  styleUrls: ['./applicants.component.css']
})
export class ApplicantsComponent implements OnInit {
  applicantEntities: any;
  earliestStartDate: Date;
  latestStartDate: Date;
  startDates: Date[];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getApplicants();
  }
  // Retrieve the database contents for applicant information from the ASP.NET API
  getApplicants() {
    this.http.get("https://localhost:5001/api/applicants").subscribe(response => 
    { 
      this.applicantEntities = response;
      this.processDates();
    }, 
    error => { console.log(error); }
    );
  }

  processDates(){
    var pipe = new DatePipe('en-GB');


    this.startDates = this.applicantEntities.map(x => x.startDate = pipe.transform(new Date(x.startDate), 'mediumDate'));
    this.earliestStartDate = this.startDates.reduce((a, b) => a < b ? a : b);
    this.latestStartDate = this.startDates.reduce((a, b) => a > b ? a : b);
  }
}
