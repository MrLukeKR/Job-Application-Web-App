import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root',
})
export class ApplicationService{
    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) { }

    sendApplicantToAPI(applicant: any){
        return this.http.post(this.baseUrl + 'applications/apply', applicant).subscribe(next => {
            console.log("Submitted successfully");
        }, error => {
            console.log("Failed to submit");
        });
    }
}