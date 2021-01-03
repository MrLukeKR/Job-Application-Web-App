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
            forename: new FormControl("", [Validators.required, Validators.minLength(2), Validators.maxLength(20)]),
            surname: new FormControl("", [Validators.required, Validators.minLength(2), Validators.maxLength(20)]),
            emailAddress: new FormControl("", [Validators.required, Validators.email]),
            address1: new FormControl("", Validators.required),
            address2: new FormControl("", Validators.required),
            address3: new FormControl(),
            town: new FormControl("", Validators.required),
            county: new FormControl("", Validators.required),
            postcode: new FormControl("", [Validators.required, Validators.pattern("[a-z]{1,2}[0-9][a-z0-9]?\s?[0-9][a-z]{2}")]),
            homePhone: new FormControl("", [Validators.required, Validators.minLength(10), Validators.maxLength(11), Validators.pattern("[0-9]")]),
            mobilePhone: new FormControl("", [Validators.minLength(10), Validators.maxLength(11), Validators.pattern("[0-9]")]),
            startDate: new FormControl("", Validators.required)
        });
    }

    applyToJob(){
        console.log(this.applicationForm.value);
    }

    cancel(){

    }
}