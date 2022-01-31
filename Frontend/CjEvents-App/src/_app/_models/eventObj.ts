import { Batch } from "./batch";
import { SocialNetwork } from "./social-network";
import { SpeakerEvent } from "./speaker-event";

export interface EventObj {
  id: number;
  place: string;
  date?: Date;
  theme: string;
  maxPeople: number;
  imageURL: string;
  phone: string;
  email: string;
  batches: Batch[];
  socialNetworks: SocialNetwork[];
  speakerEvents: SpeakerEvent[];

}
