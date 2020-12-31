import { Lot } from "./Lot";
import { SocialNetwork } from "./SocialNetwork";
import { Speaker } from "./Speaker";

export interface Event {
    id: number ;
    local: string; 
    dateEvent: Date; 
    theme: string;
    totalParticipants: number; 
    imgUrl: string; 
    phone: string;
    email: string;
    lots:  Lot[];
    socialNetworks:  SocialNetwork[];
    speakerEvents:  Speaker[];
}
