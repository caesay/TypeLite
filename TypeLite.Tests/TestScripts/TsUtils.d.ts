 
 

interface Address {
  Street: string;
  Town: string;
}
interface Person {
  Name: string;
  YearOfBirth: number;
  PrimaryAddress: Address;
  Addresses: Address[];
}
interface Employee extends Person {
  Salary: number;
}
