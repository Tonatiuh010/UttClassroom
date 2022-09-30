import { Location } from "./location";

export interface Address {
  street: string;
  number: string;
  neighborhood: string;
  location: Location;
  id: number;
}
