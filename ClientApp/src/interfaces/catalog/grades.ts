export interface Grades {
  tsu: Tsu;
  eng: Eng;
}

export interface Tsu {
  scholarly?: number;
  english?: string;
  preExam?: number;
  tsuGrades: number[];
  tsuAvg: number;
}

export interface Eng {
  engGrades: number[];
  engAvg: number;
}
