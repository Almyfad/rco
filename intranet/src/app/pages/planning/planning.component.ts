import { Component } from '@angular/core';
import { DayService, WeekService, WorkWeekService, MonthService, AgendaService, MonthAgendaService, TimelineViewsService, TimelineMonthService, ScheduleModule, EventSettingsModel } from '@syncfusion/ej2-angular-schedule';
import { MatCardModule } from "@angular/material/card";
import { L10n, loadCldr } from '@syncfusion/ej2-base';
import frNumberData from '@syncfusion/ej2-cldr-data/main/fr/numbers.json';
import frtimeZoneData from '@syncfusion/ej2-cldr-data/main/fr/timeZoneNames.json';
import frGregorian from '@syncfusion/ej2-cldr-data/main/fr/ca-gregorian.json';
import frNumberingSystem from '@syncfusion/ej2-cldr-data/supplemental/numberingSystems.json';
import { DataManager, ODataV4Adaptor, Query } from '@syncfusion/ej2-data';
// Chargez les données CLDR
loadCldr(frNumberData, frtimeZoneData, frGregorian, frNumberingSystem);
L10n.load({
  'fr': {
    'schedule': {
      'day': 'journée',
      'week': 'La semaine',
      'workWeek': 'Semaine de travail',
      'month': 'Mois',
      'today': 'Aujourd`hui'
    },
    'calendar': {
      'today': 'Aujourd`hui'
    }
  }
});
@Component({
  selector: 'app-planning',
  imports: [ScheduleModule, MatCardModule],
  standalone: true,
  templateUrl: './planning.component.html',
  styleUrl: './planning.component.scss',
    providers: [DayService, WeekService, WorkWeekService, MonthService, AgendaService, MonthAgendaService, TimelineViewsService, TimelineMonthService]
})
export class PlanningComponent {
  private dataManager: DataManager = new DataManager({
    url: 'https://services.odata.org/V4/Northwind/Northwind.svc/Orders/', 
    adaptor: new CustomAdaptor
  });

  public selectedDate: Date = new Date(1996, 6, 9);

  public eventSettings: EventSettingsModel = {
    dataSource: this.dataManager, fields: {
      id: 'Id',
      subject: { name: 'ShipName' },
      location: { name: 'ShipCountry' },
      description: { name: 'ShipAddress' },
      startTime: { name: 'OrderDate' },
      endTime: { name: 'RequiredDate' },
      recurrenceRule: { name: 'ShipRegion' }
    }
  };
}




class CustomAdaptor extends ODataV4Adaptor {
  override processResponse(): Object {
    let i: number = 0;
    // calling base class processResponse function
    let original: any = super.processResponse.apply(this, arguments as any);
    // adding employee id
    original.forEach((item: any) => item['EventID'] = ++i);
    return original;
  }
}