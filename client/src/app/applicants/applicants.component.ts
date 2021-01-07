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
  applicantEntities: Applicant[];
  earliestStartDate: Date;
  latestStartDate: Date;
  startDates: Date[];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getApplicants();
  }

  // Retrieve the database contents for applicant information from the ASP.NET API
  getApplicants() {
    this.http.get<Applicant[]>("https://localhost:5001/api/applicants").subscribe(response => 
    { 
      this.applicantEntities = response;
      this.processDates();
    }, 
    error => { console.log(error); }
    );
  }

  /*
  Convert all text information for start dates into C# Date objects, to allow
  for simpler and more effective date sorting
  */
  processDates(){    
    this.startDates = this.applicantEntities.map(x => x.startDate = new Date(x.startDate));
    
    this.earliestStartDate = new Date(this.startDates.reduce((a, b) => a < b ? a : b));
    this.latestStartDate = new Date(this.startDates.reduce((a, b) => a > b ? a : b));
  }

  /* 
  Method to format dates to a desired format, for example US or GB ordering,
  including day of the week, or a short-hand version such as dd/mm/yyyy
  */
  formatDate(date: Date){
    var pipe = new DatePipe('en-GB');

    return pipe.transform(date, 'mediumDate');
  }
}
