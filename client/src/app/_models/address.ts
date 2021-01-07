/*
Address model class to provide structure to frontend collected data
*/
export interface Address{
    id: number;
    address1: string;
    address2: string;
    address3: string;
    town: string;
    county: string;
    postcode:string;
}