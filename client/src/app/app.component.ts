import { HttpClient, HttpClientJsonpModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'ACME CORP - Job Application';
  applicants: any;

  constructor(private http: HttpClient) {}
  
  ngOnInit() {
    this.getApplicants();
  }

  // Retrieve the database contents for applicant information from the ASP.NET API
  getApplicants() {
    this.http.get("https://localhost:5001/api/applicants").subscribe(response => 
    { this.applicants = response; }, 
    error => { console.log(error); }
    );
  }
}
