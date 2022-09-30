import { Address } from "./address";
import { Contact } from "./contact";

export interface Labor {
  department: string;
  business: string;
  job: string;
  address: Address;
  contact: Contact;
  isStudy: boolean;
  id: number;
}
