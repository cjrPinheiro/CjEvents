import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { EventObj } from 'src/_app/_models/eventObj';

@Injectable()
export class EventService {

  constructor(private http: HttpClient) { }

  baseURL = 'https://localhost:5001/api/Event';



  public getEvents() : Observable<EventObj[]> {
    return this.http.get<EventObj[]>(this.baseURL).pipe(take(1));
  }

  public getEventsByTheme(theme: string) : Observable<EventObj[]> {
    return this.http.get<EventObj[]>(`${this.baseURL}/theme/${theme}`).pipe(take(1));;
  }

  public getEventById(id: number) : Observable<EventObj> {
    return this.http.get<EventObj>(`${this.baseURL}/${id}`).pipe(take(1));;
  }

  public post(event: EventObj) : Observable<EventObj> {
    return this.http.post<EventObj>(this.baseURL, event).pipe(take(1));;
  }

  public put(event: EventObj) : Observable<EventObj> {
    return this.http.put<EventObj>(`${this.baseURL}/${event.id}`,event).pipe(take(1));;
  }

  public delete(id: number) : Observable<string> {
    return this.http.delete<string>(`${this.baseURL}/${id}`).pipe(take(1));;
  }

}
