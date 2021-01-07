import { formatDate } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { ApplicationService } from "../_services/application.service";

@Component({
    selector: 'app-application',
    templateUrl: './application.component.html',
    styleUrls: ['./application.component.css']
  })
export class ApplicationComponent implements OnInit{
    model: any = {};
    applicationForm: FormGroup;
    today: any;
    applied = false;

    constructor(private applicationService: ApplicationService) { }

    ngOnInit(): void{
        this.initForm();
        this.today = formatDate(new Date(), 'yyyy-MM-dd', 'en');
    }

    /*
    Creates a new form control for the frontend application form, complete
    with all the necessary frontend validation needed for each field.
    The form will not submit unless all validations pass, and invalid forms
    are highlighted red using ng-invalid.
    */
    initForm(){
        this.applied = false;

        this.applicationForm = new FormGroup({
            forename: new FormControl(null, [Validators.required, Validators.minLength(2), Validators.maxLength(20), Validators.pattern("[a-zA-Z]*")]),
            surname: new FormControl(null, [Validators.required, Validators.minLength(2), Validators.maxLength(20), Validators.pattern("[a-zA-Z]*")]),
            emailAddress: new FormControl(null, [Validators.required, Validators.email]),
            address1: new FormControl(null, Validators.required),
            address2: new FormControl(null, Validators.required),
            address3: new FormControl(),
            town: new FormControl(null, Validators.required),
            county: new FormControl(null, Validators.required),
            postcode: new FormControl(null, [Validators.required, Validators.pattern("[a-zA-Z]{1,2}[0-9][a-zA-Z0-9]?\ ?[0-9][a-zA-Z]{2}")]),
            homePhone: new FormControl(null, [Validators.required, Validators.pattern("[0-9]{10,11}")]),
            mobilePhone: new FormControl(null, [Validators.pattern("[0-9]{10,11}")]),
            startDate: new FormControl(null, Validators.required)
        });
    }

    /*
    Submits the application form to the backend API, and toggles the 'applied'
    flag, which is used to show a post-submission confirmation message
    */
    applyToJob(){
        this.applied = true;
        this.applicationService.sendApplicantToAPI(this.applicationForm.value);
    }

    /*
    Cancels the application by re-initialising the form. A simple JavaScript
    confirmation dialogue box is displayed before the operation is performed
    */
    cancel(){
        if(confirm("Are you sure you wish to cancel your application?"))
            this.initForm();
    }
}