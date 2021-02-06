import { Photo } from "./photo";

export interface User {
    id: number;
    username: string;
    knownAs: string;
    age: number;
    gender: string;
    created: Date;
    lastActive: Date;
    photoUrl: string;
    city: string;
    password: string;
    country: string;
    interests?: string;
    introduction?: string;
    lookingFor?: string;
    department: string;
    title: string;
    phone: string;
    photos?: Photo[];
}
