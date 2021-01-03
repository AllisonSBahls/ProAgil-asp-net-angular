import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Event } from 'src/app/_models/Event';
import { EventService } from 'src/app/_services/event.service';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { EventManager } from '@angular/platform-browser';
defineLocale('pt-br', ptBrLocale);

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
})
export class EventsComponent implements OnInit {
  eventFiltered: Event[];
  events: Event[];
  event: Event;
  imageWidth = 50;
  imageMarge = 2;
  showImage = false;
  registerForm: FormGroup;
  modSave = 'post';
  bodyDeleteEvent = '';

  _filterList: string;

  constructor(
    private eventService: EventService,
    private modalService: BsModalService,
    private fb: FormBuilder,
    private localeService: BsLocaleService
  ) {
    this.localeService.use('pt-br');
  }

  get filterList(): string {
    return this._filterList;
  }

  set filterList(value: string) {
    this._filterList = value;
    this.eventFiltered = this.filterList
      ? this.filterEvents(this.filterList)
      : this.events;
  }

  openModal(template: any) {
    this.registerForm.reset();
    template.show(template);
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

  validation() {
    this.registerForm = this.fb.group({
      theme: [
        '',
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(50),
        ],
      ],
      local: ['', Validators.required],
      dateEvent: ['', Validators.required],
      imgUrl: [''],
      phone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      totalParticipants: ['', [Validators.required, Validators.max(120000)]],
    });
  }

  saveEvents(template: any) {
    if (this.registerForm.valid) {
      if (this.modSave === 'post') {
        this.event = Object.assign({}, this.registerForm.value);
        this.eventService.postEvent(this.event).subscribe(
          (newEvent: Event) => {
            console.log(newEvent);
            template.hide();
            this.getEvents();
          },
          (error) => {
            console.log(error);
          }
        );
      } else {
        this.event = Object.assign(
          { id: this.event.id },
          this.registerForm.value
        );
        this.eventService.putEvent(this.event).subscribe(
          () => {
            template.hide();
            this.getEvents();
          },
          (error) => {
            console.log(error);
          }
        );
      }
    }
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

  changeEvent(event: Event, template: any) {
    this.modSave = 'put';
    this.openModal(template);
    this.event = event;
    this.registerForm.patchValue(event);
  }

  newEvent(template: any) {
    this.modSave = 'post';
    this.openModal(template);
  }

  deleteEvent(event: Event, template: any){
    this.openModal(template);
    this.event = event;
    this.bodyDeleteEvent = `Tem certeza que deseja excluir o Evento: ${event.theme}, Código: ${event.id}`;;
  }

  confirmDelete(template: any){
    this.eventService.deleteEvent(this.event.id).subscribe(
      () =>{
        template.hide();  
        this.getEvents();
      }, error =>{
        console.log(error);
      }
    )
  }
}
