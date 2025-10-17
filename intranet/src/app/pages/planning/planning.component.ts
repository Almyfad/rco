import { Component, computed, effect, inject, model, Signal, signal, ViewChild } from '@angular/core';
import { DayService, WeekService, WorkWeekService, MonthService, AgendaService, MonthAgendaService, TimelineViewsService, TimelineMonthService, ScheduleModule, EventSettingsModel, TimelineYearService, GroupModel, ScheduleComponent, View, DragAndDropService, ResizeService, PopupOpenEventArgs, CellClickEventArgs, SelectEventArgs } from '@syncfusion/ej2-angular-schedule';
import { MatCardModule } from "@angular/material/card";
import { L10n, loadCldr } from '@syncfusion/ej2-base';

import { CheckBoxModule } from '@syncfusion/ej2-angular-buttons';
import frNumberData from '@syncfusion/ej2-cldr-data/main/fr/numbers.json';
import frtimeZoneData from '@syncfusion/ej2-cldr-data/main/fr/timeZoneNames.json';
import frGregorian from '@syncfusion/ej2-cldr-data/main/fr/ca-gregorian.json';
import frNumberingSystem from '@syncfusion/ej2-cldr-data/supplemental/numberingSystems.json';
import { DataManager, ODataV4Adaptor } from '@syncfusion/ej2-data';
import { RuntimeEnvService } from 'src/app/services/runtime-env.service';
import { DatePipe } from '@angular/common';
import { FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { AppBarModule, ToolbarModule, ContextMenuModule } from '@syncfusion/ej2-angular-navigations';
import { Ressources, RessourcesPickerComponent } from "./ressources-picker/ressources-picker.component";
import { MatIconModule } from "@angular/material/icon";
import { MatButtonModule } from '@angular/material/button';
import { MatDivider } from "@angular/material/divider";
import { TablerIconComponent, TablerIconsModule } from "angular-tabler-icons";
import { MatCheckbox } from "@angular/material/checkbox";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from '@angular/material/input';
import { SidenavService } from 'src/app/services/sidenav.service';
import { EventFormComponent } from './event-form/event-form.component';
import { PlanningModuleService } from './planning-module.service';
// Chargez les données CLDR
loadCldr(frNumberData, frtimeZoneData, frGregorian, frNumberingSystem);
L10n.load({
  'fr': {
    'schedule': {
      'day': 'journée',
      'week': 'La semaine',
      'workWeek': 'Semaine de travail',
      'month': 'Mois',
      'today': 'Aujourd`hui',
      'timelineMonth': 'Mois chronologique',
      'timelineYear': 'Année chronologique',
      'saveButton': 'Ajouter',
      'cancelButton': 'Fermer',
      'deleteButton': 'Supprimer',
      'newEvent': 'Ajouter un événement',
    },
    'calendar': {
      'today': 'Aujourd`hui'
    }
  }
});


@Component({
  selector: 'app-planning',
  imports: [ScheduleModule, MatCardModule, DatePipe, AppBarModule,
    ToolbarModule, ContextMenuModule, CheckBoxModule, RessourcesPickerComponent,
   ReactiveFormsModule, MatInputModule, MatIconModule,
    MatButtonModule, MatDivider, TablerIconsModule, MatCheckbox, FormsModule, MatFormFieldModule],
  standalone: true,
  templateUrl: './planning.component.html',
  styleUrl: './planning.component.scss',
  providers: [DragAndDropService, ResizeService, DayService, WeekService, WorkWeekService, MonthService, AgendaService, MonthAgendaService, TimelineViewsService, TimelineMonthService, TimelineYearService]
})
export class PlanningComponent {
  private sideNavService = inject(SidenavService);
  private planningModuleService = inject(PlanningModuleService);
  onCellclick($event: CellClickEventArgs): void {
    this.planningModuleService.cellsclick.set($event);
    this.scheduleObj.openEditor({}, 'Add');
  }
  
  onRangeSelect($event: SelectEventArgs): void {
    if ($event.requestType !== "cellSelect") return;
    if (!$event.data) return;
    this.planningModuleService.selectevent.set($event);
    this.scheduleObj.openEditor({}, 'Add');

  }
  
  public onPopupOpen(args: PopupOpenEventArgs): void {
    this.planningModuleService.popupopen.set(args);
    args.cancel = true;
    
    // Chaîner les appels pour éviter plusieurs cycles de détection de changement
    this.sideNavService
      .setTitle(args.type === 'Editor' ? (args.data as any).libelle || 'Nouvel événement' : 'Détails de l`événement')
      .setWidth('620px')
      .setComponent(EventFormComponent)
      .open()
      .onClosed(() => {
        this.scheduleObj.refresh();
      });
  }
  openNewEventDialog() {
    this.scheduleObj.openEditor({'newEvent': {}}, 'Add');
  }

  centreR = "Centre_rsrc";
  programmeR = "Programme_rsrc";
  @ViewChild('scheduleObj') scheduleObj: ScheduleComponent;


  constructor() {
    effect(() => {
      const currentView = this.currentView();
      const vchrono = this.vchrono();
      if (vchrono) {
        if (currentView === 'Agenda') {
          this.scheduleObj.currentView = 'MonthAgenda';
          return;
        }
        this.scheduleObj.currentView = ('Timeline' + currentView) as View;
      } else {
        this.scheduleObj.currentView = this.currentView();
      }
    });
  }

  readonly env = inject(RuntimeEnvService);
  private dataManager: DataManager = new DataManager({
    url: this.env.apiUrl + '/api/planning/activities/',
    adaptor: new ODataV4Adaptor
  });

  public enableAdaptiveUI = false;
  public startHour = '08:00';
  public endHour = '22:00';
  public virtualscroll = true;
  public eventSettings: EventSettingsModel = {
    dataSource: this.dataManager,
    spannedEventPlacement: 'TimeSlot',
    fields: {
      id: 'Id',
      subject: { name: 'libelle' },
      location: { name: 'centre' },
      description: { name: 'description' },
      startTime: { name: 'debut' },
      endTime: { name: 'fin' },
    },
  };

  selectedCentres = computed(() => this.resourcesPicked()?.map(r => r.centre));

  selectedProgrammes = computed(() => this.resourcesPicked()?.flatMap(r => r.programmes.map(p => ({ ...p, centreId: r.centre.id }))));
  public groupBy = computed(() => {
    const selectedCentres = this.selectedCentres();
    const selectedProgrammes = this.selectedProgrammes();
    const vprogramme = this.vprogramme();
    let res = [];
    if (selectedCentres && selectedCentres.length > 0) {
      res.push(this.centreR);
    }
    if (selectedProgrammes && selectedProgrammes.length > 0 && vprogramme) {
      res.push(this.programmeR);
    }
    return {
      resources: res,
      byDate: false,
      enableCompactView: false
    };
  });

  programmeRessourceEnable = signal(true);

  resourcesPicked = model<Ressources[]>([]);
  vchrono = model(false);
  vprogramme = model(false);
  currentView = signal<View>('Month');
  changeview(view: View) {
    this.currentView.set(view);
  }



}
