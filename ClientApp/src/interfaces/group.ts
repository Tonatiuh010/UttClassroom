import { Asset } from "./asset";
import { Major } from "./major";

export interface Group {
  code: string;
  key: string;
  quarter: number;
  description: string;
  major: Major;
  field: Asset;
  period: Asset;
  students: any[];
  id: number;
}
