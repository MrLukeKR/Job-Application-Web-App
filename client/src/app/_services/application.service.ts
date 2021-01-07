import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { Applicant } from "../_models/applicant";

// Injected in root to allow global access to the application service
@Injectable({
  providedIn: 'root',
})
export class ApplicationService{
    // API URL taken from environment variables to allow for portability
    // to a new server if necessary
    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) { }

    /*
    Service method to allow frontend to transfer applicant data to backend
    */
    sendApplicantToAPI(applicant: Applicant){
        return this.http.post(this.baseUrl + 'applications/apply', applicant).subscribe(next => {
            console.log("Submitted successfully");
        }, error => {
            console.log("Failed to submit");
        });
    }
}