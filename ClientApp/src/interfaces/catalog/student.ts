import { Asset } from "./asset";
import { Location } from "./location";
import { Address } from "./address";
import { Contact } from "./contact";
import { Scholarly } from "./scholarly";
import { Labor } from "./labor";
import { ContactFamily } from "./contact.family";
import { Grades } from "./grades";

export interface Student {
  code: string;
  name: string;
  lastName: string;
  birth: Date;
  age: number;
  birthPlace: Location;
  genre: Asset;
  marital: Asset;
  contact: Contact;
  address: Address;
  scholarly: Scholarly;
  contacts?: ContactFamily[];
  stats?: Grades;
  labor?: Labor;
  id: number;
}
