import { SocialNetwork } from "./SocialNetwork";
import { Event } from "./Event";

export interface Speaker {
    id: number;
    name: string;
    curriculum: string;
    imgUrl: string;
    phone: string;
    email: string;
    socialNetworks: SocialNetwork[];
    speakerEvents:  Event[];
}
