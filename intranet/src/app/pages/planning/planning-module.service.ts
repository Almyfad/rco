import { computed, Injectable, signal } from '@angular/core';
import { CellClickEventArgs, EventClickArgs, PopupOpenEventArgs, SelectEventArgs } from '@syncfusion/ej2-angular-schedule';
import { ActivityDTO } from 'src/app/core/helios-api-client';

@Injectable({
  providedIn: 'root'
})
export class PlanningModuleService {
  cellsclick = signal<CellClickEventArgs | null>(null);
  eventclick = signal<EventClickArgs | null>(null);
  rangeselectevent = signal<SelectEventArgs | null>(null);
  popupopen = signal<PopupOpenEventArgs | null>(null);
  selectedEvent = signal<ActivityDTO | null>(null);
  refreshPlanning: () => void = () => {};
  startTime = computed(() => {
    const celltime = this.cellsclick()?.startTime;
    const selectevent = this.rangeselectevent();
    if (selectevent?.data) {
      const data = selectevent.data as any;
      const selecttime = data.debut || data.startTime || data.StartTime;
      return selecttime || celltime;
    }
    return celltime;
  });

  endTime = computed(() => {
    const celltime = this.cellsclick()?.endTime;
    // Pour SelectEventArgs, chercher dans différentes propriétés possibles
    const selectevent = this.rangeselectevent();
    if (selectevent?.data) {
      const data = selectevent.data as any;
      const selecttime = data.fin || data.endTime || data.EndTime;
      return selecttime || celltime;
    }
    return celltime;
  });
  isAllDay = computed(() => {
    const cellallDay = this.cellsclick()?.isAllDay || false;
    const selectevent = this.rangeselectevent();
    if (selectevent?.data) {
      const data = selectevent.data as any;
      const selecttime = data.IsAllDay;
      return selecttime || cellallDay;
    }
    return cellallDay;
  });

  reset() {
    this.cellsclick.set(null);
    this.eventclick.set(null);
    this.rangeselectevent.set(null);
    this.popupopen.set(null);
    this.selectedEvent.set(null);
    this.refreshPlanning = () => {};
  }
  constructor() { }
}
