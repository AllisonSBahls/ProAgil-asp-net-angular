import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Event } from 'src/_models/Event';

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
}
