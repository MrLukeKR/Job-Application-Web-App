import { formatDate } from "@angular/common";
import { analyzeAndValidateNgModules } from "@angular/compiler";
import { Component, OnInit, Output } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { EventEmitter } from "events";

@Component({
    selector: 'app-application',
    templateUrl: './application.component.html',
    styleUrls: ['./application.component.css']
  })
export class ApplicationComponent implements OnInit{
    @Output() cancelApplication = new EventEmitter();
    model: any = {};
    applicationForm: FormGroup;
    today: any;

    ngOnInit(): void{
        this.initForm();
        this.today = formatDate(new Date(), 'yyyy-MM-dd', 'en');
    }

    initForm(){
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

    applyToJob(){
        console.log(this.applicationForm.value);
    }

    cancel(){
        if(confirm("Are you sure you wish to cancel your application?"))
            this.initForm();
    }
}