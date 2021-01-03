import { Component, OnInit, Output } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
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

    ngOnInit(): void{
        this.initForm();
    }

    initForm(){
        this.applicationForm = new FormGroup({
            forename: new FormControl,
            surname: new FormControl(),
            emailAddress: new FormControl(),
            address1: new FormControl(),
            address2: new FormControl(),
            address3: new FormControl(),
            town: new FormControl(),
            county: new FormControl(),
            postcode: new FormControl(),
            mobilePhone: new FormControl(),
            homePhone: new FormControl(),
            startDate: new FormControl()
        });
    }

    applyToJob(){
        console.log(this.applicationForm.value);
    }

    cancel(){

    }
}