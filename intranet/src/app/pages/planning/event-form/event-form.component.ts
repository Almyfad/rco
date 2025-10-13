import { Component, inject, model, signal } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { RegistreModuleService } from '../../registre/services/registre-module.service';
import { CentreSelectComponent, ProgrammeSelectComponent, TypeActivitiesSelectComponent } from "src/app/components/async-select";
import { DateTimePickerModule } from '@syncfusion/ej2-angular-calendars';
import { MatCheckbox } from "@angular/material/checkbox";
import { CentreDTO } from 'src/app/core/helios-api-client/model/centreDTO';
import { PlanningModuleService } from '../planning-module.service';
import { SnackBarService } from 'src/app/layouts/full/shared/snack-bar/snack-bar.service';
import { SidenavService } from 'src/app/services/sidenav.service';
import { PlanningService } from 'src/app/core/helios-api-client/api/api';
import { CreateActivityDTO, ProgrammeDTO, TypeActiviteDTO } from 'src/app/core/helios-api-client';
@Component({
  selector: 'app-event-form',
  imports: [DateTimePickerModule, ReactiveFormsModule, MatInputModule, MatFormFieldModule, MatIconModule, MatButtonModule,
    FormsModule, CentreSelectComponent, MatCheckbox, ProgrammeSelectComponent, TypeActivitiesSelectComponent],
  standalone: true,
  templateUrl: './event-form.component.html',
  styleUrl: './event-form.component.scss'
})
export class EventFormComponent {

  private fb = inject(FormBuilder);
  private registre = inject(RegistreModuleService)
  private planningModuleService = inject(PlanningModuleService);
  private planningService = inject(PlanningService);
  private sideNavService = inject(SidenavService);
  private snackBar = inject(SnackBarService);
  selectedCentre = model<CentreDTO | null>(null);
  get centres() { return this.registre.$centres; }

  newEventForm = this.fb.group({
    titre: ['', Validators.required],
    centre: [null, Validators.required],
    allday: [this.planningModuleService.isAllDay() || false],
    start: [this.planningModuleService.startTime() || null, Validators.required],
    end: [this.planningModuleService.endTime() || null, Validators.required],
    programme: [null, Validators.required],
    typeActivity: [null, Validators.required],
    description: [''],
  });

  /**
   *
   */
  constructor() {
    this.newEventForm.get('centre')?.valueChanges.subscribe(value => {
      this.selectedCentre.set(value);
    });
    this.newEventForm.get('start')?.valueChanges.subscribe(value => {
      var endDate = new Date(value! as Date);
      endDate.setHours(endDate.getHours() + 1);
      this.newEventForm.get('end')?.setValue(endDate);
    });



  }
  submit() {
    if (this.newEventForm.invalid) return;


    this.planningService.apiPlanningCreatePost({
      libelle: this.newEventForm.get('titre')?.value!,
      description: this.newEventForm.get('description')?.value,
      dateDebut: this.newEventForm.get('start')?.value!,
      dateFin: this.newEventForm.get('end')?.value!,
      typeActiviteeId: (this.newEventForm.get('typeActivity')?.value! as TypeActiviteDTO)?.id!,
      centreId: (this.newEventForm.get('centre')?.value! as CentreDTO)?.id!,
      programmeId: (this.newEventForm.get('programme')?.value! as ProgrammeDTO)?.id!,
    } as CreateActivityDTO).subscribe({
      next: () => {
        this.snackBar.success("Événement ajouté avec succès");
        this.newEventForm.reset();
        this.sideNavService.close();
      },
      error: () => {
        this.snackBar.error("Erreur lors de l'ajout de l'événement");
      }
    });
  }
}
