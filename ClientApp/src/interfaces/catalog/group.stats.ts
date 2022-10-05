import { ItemStat, ItemDisjunction } from "./item";

export interface GroupStats {
  students: number;
  personal_information: PersonalInformation;
  labor_data: LaborData;
  scholarlyData: ScholarlyData;
  grades: any;
}

export interface PersonalInformation {
  genre: ItemStat[];
  marital: ItemStat[];
  lives_with: ItemStat[];
  family_income: ItemStat[];
}

export interface LaborData {
  work: ItemDisjunction;
  workStudy: ItemDisjunction;
  workReason: ItemStat[];
}

export interface ScholarlyData {
  scholarlyType: ItemStat[];
  scholarly: ItemStat[];
}

