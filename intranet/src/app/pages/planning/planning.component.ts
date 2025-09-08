import { Component, computed, inject, ViewChild } from '@angular/core';
import { DayService, WeekService, WorkWeekService, MonthService, AgendaService, MonthAgendaService, TimelineViewsService, TimelineMonthService, ScheduleModule, EventSettingsModel, EventRenderedArgs, TimelineYearService, GroupModel, ScheduleComponent, ResourcesModel } from '@syncfusion/ej2-angular-schedule';
import { MatCardModule } from "@angular/material/card";
import { L10n, loadCldr } from '@syncfusion/ej2-base';
import frNumberData from '@syncfusion/ej2-cldr-data/main/fr/numbers.json';
import frtimeZoneData from '@syncfusion/ej2-cldr-data/main/fr/timeZoneNames.json';
import frGregorian from '@syncfusion/ej2-cldr-data/main/fr/ca-gregorian.json';
import frNumberingSystem from '@syncfusion/ej2-cldr-data/supplemental/numberingSystems.json';
import { DataManager, ODataV4Adaptor, Query } from '@syncfusion/ej2-data';
import { RuntimeEnvService } from 'src/app/services/runtime-env.service';
import { DatePipe } from '@angular/common';
import { PlanningService, ProgrammeDTO2 } from 'src/app/core/helios-api-client';
import { toSignal } from '@angular/core/rxjs-interop';
import { AsyncSelectComponent, SelectedOption } from "src/app/components/async-select/async-select.component";
import { map, take } from 'rxjs';
import { V } from '@angular/cdk/keycodes';
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
    },
    'calendar': {
      'today': 'Aujourd`hui'
    }
  }
});
@Component({
  selector: 'app-planning',
  imports: [ScheduleModule, MatCardModule, DatePipe, AsyncSelectComponent],
  standalone: true,
  templateUrl: './planning.component.html',
  styleUrl: './planning.component.scss',
  providers: [DayService, WeekService, WorkWeekService, MonthService, AgendaService, MonthAgendaService, TimelineViewsService, TimelineMonthService, TimelineYearService]
})
export class PlanningComponent {

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
  public groupBy: GroupModel = {
    resources: ['Programme'],
    byDate: false,
    enableCompactView: false
  };
  planningService = inject(PlanningService);
  Programme: string;
  selectedProgrammeId: any;

  programmes = toSignal(
    this.planningService.apiPlanningProgrammesGet().pipe(
      map(x => ({ data: x, loading: false })),
      take(1)
    ),
    { initialValue: { data: [], loading: true } }
  );
  programmeDataSource = computed(() => this.programmes().data);
  programmeOptions = computed(() => this.programmes().data.map(p => ({ label: p.libelle, value: p })));
  programmeLoading = computed(() => this.programmes().loading);
  @ViewChild('scheduleObj')
  public scheduleObj?: ScheduleComponent;



  onProgrammeSelection(value: SelectedOption<ProgrammeDTO2>) {
    if (!this.scheduleObj) return;

    if (value.checked == true) {
      console.log("add resource", value);
      this.scheduleObj.addResource(value.options, 'Programme', 0);
    }
    else {
      console.log("remove resource", value);
      this.scheduleObj.removeResource(value.options.id, 'Programme');
    }


  }

}