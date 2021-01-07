import { Address } from "./address";

/*
Applicant model class to provide structure to frontend collected data
*/
export interface Applicant{
    id: number;
    forename: string;
    surname: string;
    emailAddress: string;
    address: Address;   
    homePhone: string;
    mobilePhone: string;
    startDate: Date;
}