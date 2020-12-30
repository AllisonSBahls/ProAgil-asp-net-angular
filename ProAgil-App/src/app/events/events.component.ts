import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

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

  eventFiltered: any = [];
  events: any = {};
  imageWidth = 50;
  imageMarge = 2;
  showImage = false;

  
  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getEvents();
  }

  filterEvents(filterFor: string): any {
    filterFor = filterFor.toLocaleLowerCase();
    let resultTheme = this.events.filter(events => events.theme.toLocaleLowerCase().indexOf(filterFor) !== -1);
    return resultTheme;
  }
  
  alternateImage() {
    this.showImage = !this.showImage;
  }

  getEvents() {
    this.http.get('http://localhost:5000/events').subscribe(
      (response) => {
        this.events = response;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
