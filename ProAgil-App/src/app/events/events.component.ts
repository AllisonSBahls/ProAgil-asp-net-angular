import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Event } from 'src/app/_models/Event';
import { EventService } from 'src/app/_services/event.service';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
})
export class EventsComponent implements OnInit {
  eventFiltered: Event[];
  events: Event[];
  imageWidth = 50;
  imageMarge = 2;
  showImage = false;
  modalRef: BsModalRef;
  registerForm: FormGroup;

  _filterList: string;

  constructor(private eventService: EventService, private modalService: BsModalService) {}

  get filterList(): string {
    return this._filterList;
  }

  set filterList(value: string) {
    this._filterList = value;
    this.eventFiltered = this.filterList
      ? this.filterEvents(this.filterList)
      : this.events;
  }

  openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template);
  }

  ngOnInit() {
    this.validation();
    this.getEvents();
  }

  filterEvents(filterFor: string): Event[] {
    filterFor = filterFor.toLocaleLowerCase();
    let resultTheme = this.events.filter(
      (events) => events.theme.toLocaleLowerCase().indexOf(filterFor) !== -1
    );
    return resultTheme;
  }

  alternateImage() {
    this.showImage = !this.showImage;
  }

  validation(){
    this.registerForm = new FormGroup({
      theme: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]),
      local: new FormControl('', Validators.required),
      dateEvent: new FormControl('', Validators.required),
      imgUrl: new FormControl(''),
      phone: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      totalParticipants: new FormControl('', [Validators.required, Validators.max(120000)]),
    });
  }

  saveChanges(){

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
