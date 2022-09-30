import { Address } from "./address";
import { Asset } from "./asset";

export interface Scholarly {
  name: string;
  type: Asset;
  address: Address;
  id: number;
}
