import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss']
})
export class EventsComponent implements OnInit {

  public events: any = [];
  public filteredEvents: any = [];
  widthImg : number = 150;
  marginImg : number = 2;
  showImage : boolean = true;
  _filterRows : string = "";

  public get filterRows(){
    return this._filterRows
  }
  public set filterRows(value){
    this._filterRows = value;
    this.filteredEvents = this._filterRows ? this.FilterEvents(this._filterRows) : this.events;
  }

  constructor(private http: HttpClient) { }



  ngOnInit(): void {
    this.getEventos();
  }

  public AlterImage() : void {
    this.showImage = !this.showImage;

  }
  public getEventos() : void {
    this.http.get('https://localhost:5001/api/Event').subscribe(
      response => {
        this.events = response,
        this.filteredEvents = response
      },
      error => console.log(error)
    );
  }
  public FilterEvents(filter : string) : any {
    filter = filter.toLocaleLowerCase();

    return this.events.filter(
      (event : any) => event.theme.toLocaleLowerCase().indexOf(filter) !== -1 ||
      event.place.toLocaleLowerCase().indexOf(filter) !== -1
    )


  }
}
