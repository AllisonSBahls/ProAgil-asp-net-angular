import { Component, OnInit } from '@angular/core';
import { Event } from 'src/_models/Event';
import { EventService } from 'src/_services/event.service';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
})
export class EventsComponent implements OnInit {

  _filterList: string;
  get filterList(): string {
    return this._filterList;
  }
  
  set filterList(value: string) {
    this._filterList = value;
    this.eventFiltered = this.filterList ? this.filterEvents(this.filterList) : this.events;
  }

  eventFiltered: Event[];
  events: Event[]
  imageWidth = 50;
  imageMarge = 2;
  showImage = false;

  
  constructor(private eventService: EventService) {}

  ngOnInit() {
    this.getEvents();
  }

  filterEvents(filterFor: string): Event[] {
    filterFor = filterFor.toLocaleLowerCase();
    let resultTheme = this.events.filter(events => events.theme.toLocaleLowerCase().indexOf(filterFor) !== -1);
    return resultTheme;
  }
  
  alternateImage() {
    this.showImage = !this.showImage;
  }

  getEvents() {
    this.eventService.getAllEvent().subscribe(
      (_events: Event[]) => {
        this.events = _events;
        this.eventFiltered = this.events;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
