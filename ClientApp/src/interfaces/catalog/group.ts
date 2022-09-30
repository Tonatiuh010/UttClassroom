import { Asset } from "./asset";
import { Major } from "./major";
import { Student } from "./student";

export interface Group {
  code: string;
  key: string;
  quarter: number;
  description: string;
  major: Major;
  field: Asset;
  period: Asset;
  students?: Student[];
  id: number;
}
