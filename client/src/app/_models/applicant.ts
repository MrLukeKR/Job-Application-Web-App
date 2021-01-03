import { Address } from "./address";

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