import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { EventObj } from '@app/_models/eventObj';
import { EventService } from '@app/_services/event.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-event-detail',
  templateUrl: './event-detail.component.html',
  styleUrls: ['./event-detail.component.scss']
})
export class EventDetailComponent implements OnInit {
  public form: FormGroup = new FormGroup({});
  public saveModule: string = 'post';
  event = {} as EventObj;
  get f(): any{
    return this.form.controls;
  }
  get bsConfig(): any{
    return { isAnimated: true,
      adaptivePosition: true,
      dateInputFormat: 'MM/DD/YYYY hh:mm a',
      containerClass: 'theme-default',
      showWeekNumbers: false

    };
  }
  constructor(private fb: FormBuilder, private router: ActivatedRoute, private eventService: EventService, private spinner: NgxSpinnerService, private toastr: ToastrService) {}

  public loadEvent(): void{
    const eventIdParam = this.router.snapshot.paramMap.get('id');

    if(eventIdParam != null){
      this.spinner.show();
      this.saveModule = 'put';
      this.eventService.getEventById(+eventIdParam).subscribe({
        next: (event: EventObj) =>{
          this.event = {...event};
          this.form.patchValue(this.event);
        },
        error: (error: any) => {
          console.error(error);
          this.spinner.hide();
          this.toastr.error('Error on load Event', 'Error!')
        },
        complete: () => this.spinner.hide()
      });
    }

  }

  ngOnInit(): void {
    this.validation();
    this.loadEvent();
  }

  public validation(): void {
    this.form = this.fb.group({
      theme: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      place: ['', Validators.required],
      date: ['', Validators.required],
      maxPeople: ['', [Validators.required, Validators.max(120000)]],
      phone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      imageURL: ['', Validators.required],
    });

  }

  public clearForm(): void{
    this.form.reset();

  }

  public logConsole(): boolean{
    console.log("teste aqui");

    return true;
  }

  public cssValidator(field: FormControl): any{
    return {'is-invalid': field!.errors && field!.touched }

  }

  public saveChanges(): void {
    this.spinner.show();
    if(this.form.valid){

      this.event = this.saveModule === 'post'
                 ? {...this.form.value}
                 : {id: this.event.id, ...this.form.value}

      this.eventService[this.saveModule](this.event).subscribe(
        () => this.toastr.success('Event successfully saved!','Success!'),
        (error: any) => {
          console.error(error);
          this.toastr.error('Error on save the Event!','Error!')
        }
      ).add(() => this.spinner.hide());
    }
  }

}
