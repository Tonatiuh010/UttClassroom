import { Contact } from "./contact";
import { Student } from "./student";

export interface ContactFamily {
  student?: Student;
  contact: Contact;
  name: string;
  kinship: string;
  work: string;
  isEmergency: boolean;
  id: number;
}
