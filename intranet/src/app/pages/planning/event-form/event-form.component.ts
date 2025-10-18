import { Component, computed, effect, inject, Input, model, signal } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
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
import { ConfirmDialogComponent, ConfirmDialogData } from 'src/app/components/confirm-dialog/confirm-dialog.component';
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
  private dialog = inject(MatDialog);
  get centres() { return this.registre.$centres.value(); }

  modelCentreId = model<number | null>(null);

  get selectedEvent() { return this.planningModuleService.selectedEvent; }
  titre = computed(() => this.selectedEvent() ? this.selectedEvent()!.libelle : '');
  allday = computed(() => this.selectedEvent() ? this.selectedEvent()!.isAllday : false);
  typeActivity = computed(() => this.selectedEvent() ? this.selectedEvent()!.typeActivite : null);
  description = computed(() => this.selectedEvent() ? this.selectedEvent()!.description : '');
  centre = computed(() => this.selectedEvent() ? this.selectedEvent()!.centreId : null);
  programme = computed(() => this.selectedEvent() ? this.selectedEvent()!.programmeId : null);
  eventId = computed(() => this.selectedEvent() ? this.selectedEvent()!.id : undefined);
  isEditMode = computed(() => (this.eventId() ? true : false));

  start = computed(() => {
    const event = this.selectedEvent();
    const selectedstart = this.planningModuleService.startTime();
    if (event) return new Date(event.debut);
    if (selectedstart) return new Date(selectedstart);

    return null;
  });

  end = computed(() => {
    const event = this.selectedEvent();
    const selectedend = this.planningModuleService.endTime();

    if (event) return new Date(event.fin);
    if (selectedend) return new Date(selectedend);

    return null;
  });

  newEventForm = this.fb.group({
    libelle: ['', Validators.required],
    centre: [null as number | null, Validators.required],
    allday: [false, Validators.required],
    start: [null as Date | null, Validators.required],
    end: [null as Date | null, Validators.required],
    programme: [null as number | null, Validators.required],
    typeActivity: [null as TypeActiviteDTO | null, Validators.required],
    description: [''],
  });

  get eventforAPI() {
    return {
      libelle: this.newEventForm.get('libelle')?.value!,
      description: this.newEventForm.get('description')?.value,
      centreId: this.newEventForm.get('centre')?.value!,
      isAllDay: this.newEventForm.get('allday')?.value!,
      dateDebut: this.newEventForm.get('start')?.value!.toISOString(),
      dateFin: this.newEventForm.get('end')?.value!.toISOString(),
      programmeId: this.newEventForm.get('programme')?.value!,
      typeActiviteeId: this.newEventForm.get('typeActivity')?.value?.id!,
    } as CreateActivityDTO;
  }


  constructor() {
    effect(() => {
      const isEdit = this.isEditMode();
      if (isEdit == true) {
        this.sideNavService
          .setIconActions([{
            icon: 'trash',
            action: () => this.removeEvent(),
          }])
      }
    });
    effect(() => {
      this.newEventForm.patchValue({
        libelle: this.titre(),
        centre: this.centre(),
        allday: this.allday(),
        start: this.start(),
        end: this.end(),
        programme: this.programme(),
        typeActivity: this.typeActivity(),
        description: this.description(),
      });

    });
    this.newEventForm.get('centre')?.valueChanges.subscribe(value => {
      this.modelCentreId.set(value);
    });
    this.newEventForm.get('start')?.valueChanges.subscribe(value => {
      if (!value) return;
      var endDate = new Date(value);
      endDate.setHours(value.getHours() + 1);
      this.newEventForm.get('end')?.setValue(endDate);
    });
  }
  submit() {
    if (this.newEventForm.invalid) return;
    if (this.isEditMode()) {
      this.planningService.apiPlanningActivitieIdPut(this.eventforAPI, this.eventId()).subscribe({
        next: () => {
          this.snackBar.success("Événement modifié avec succès");
          this.newEventForm.reset();
          this.sideNavService.close();
          this.planningModuleService.refreshPlanning();
        },
        error: () => {
          this.snackBar.error("Erreur lors de la modification de l'événement");
        }
      });
      return;
    }

    this.planningService.apiPlanningCreatePost(this.eventforAPI).subscribe({
      next: () => {
        this.snackBar.success("Événement ajouté avec succès");
        this.newEventForm.reset();
        this.sideNavService.close();
        this.planningModuleService.refreshPlanning();
      },
      error: () => {
        this.snackBar.error("Erreur lors de l'ajout de l'événement");
      }
    });
  }

  removeEvent() {
    const id = this.eventId();
    const eventTitle = this.titre();

    if (!id) {
      this.snackBar.error("Aucun événement à supprimer");
      return;
    }

    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '450px',
      data: {
        title: 'Supprimer l\'événement',
        message: `Êtes-vous sûr de vouloir supprimer "${eventTitle}" ? Cette action est irréversible.`,
        confirmText: 'Supprimer',
        cancelText: 'Annuler',
        icon: 'delete'
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === true) {
        // L'utilisateur a confirmé la suppression
        this.planningService.apiPlanningActivitieIdDelete(id).subscribe({
          next: () => {
            this.snackBar.success("Événement supprimé avec succès");
            this.sideNavService.close();
            this.planningModuleService.refreshPlanning();
          },
          error: (error) => {
            console.error('Erreur lors de la suppression:', error);
            this.snackBar.error("Erreur lors de la suppression de l'événement");
          }
        });
      }
    });
  }
}
