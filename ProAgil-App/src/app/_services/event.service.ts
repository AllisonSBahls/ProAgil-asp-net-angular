import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Event } from 'src/app/_models/Event';

//Decorator injectable

@Injectable({
  providedIn: 'root',
})
export class EventService {
  baseUrl = 'http://localhost:5000/events';
  constructor(private http: HttpClient) {}

  getAllEvent(): Observable<Event[]> {
    return this.http.get<Event[]>(this.baseUrl);
  }

  getEventByTheme(theme: string): Observable<Event[]> {
    return this.http.get<Event[]>(`${this.baseUrl}/theme/${theme}`);
  }

  getEventById(id: number): Observable<Event> {
    return this.http.get<Event>(`${this.baseUrl}/${id}`);
  }

  postEvent(event: Event){
    return this.http.post(this.baseUrl, event);
  }

  putEvent(event:Event){
    return this.http.put(`${this.baseUrl}/${event.id}`, event);
  }

  deleteEvent(id: number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
