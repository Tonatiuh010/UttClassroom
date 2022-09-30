import { Asset } from "./asset";
import { Location } from "./location";
import { Address } from "./address";
import { Contact } from "./contact";
import { Scholarly } from "./scholarly";
import { Labor } from "./labor";

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
  labor: Labor;
  id: number;
}
