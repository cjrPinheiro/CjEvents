import { SocialNetwork } from "./social-network";
import { SpeakerEvent } from "./speaker-event";

export interface Speaker {
  name: string;
  description: string;
  photoUrl: string;
  phone: string;
  email: string;
  socialNetworks: SocialNetwork;
  speakerEvents: SpeakerEvent;
}
