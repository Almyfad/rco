import { Component, computed, forwardRef, inject, model } from '@angular/core';
import { AsyncSelectComponent } from "./async-select.component";
import { ProgrammeDTO } from 'src/app/core/helios-api-client/model/models';
import { ControlValueAccessor, FormControl, NG_VALUE_ACCESSOR, ReactiveFormsModule } from '@angular/forms';
import { rxResource } from '@angular/core/rxjs-interop';
import { PlanningService } from 'src/app/core/helios-api-client/api/api';

@Component({
  selector: 'app-programme-select',
  imports: [AsyncSelectComponent, ReactiveFormsModule],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => ProgrammeSelectComponent),
      multi: true
    }
  ],
  template: '<app-async-select [formControl]="control" label="Programme" placeholder="Sélectionnez un programme" [dataSource]="$programmes" ></app-async-select>',
})
export class ProgrammeSelectComponent implements ControlValueAccessor {
  private planning = inject(PlanningService);

  control = new FormControl<ProgrammeDTO | ProgrammeDTO[] | null>(null);
  centre = model<number | null | undefined>(null);
  test = computed(() => {
    console.log(this.centre()); return this.centre();
  });
  $programmes = rxResource({
    request: () => this.centre(),
    loader: ({ request }) => this.planning.apiPlanningCentresIdProgrammesGet(request ?? 0)
  });

  private onChange = (value: ProgrammeDTO | ProgrammeDTO[] | null) => { };
  private onTouched = () => { };

  constructor() {
    this.control.valueChanges.subscribe(value => {
      this.onChange(value);
    });
  }

  writeValue(value: ProgrammeDTO | ProgrammeDTO[] | null): void {
    this.control.setValue(value, { emitEvent: false });
  }

  registerOnChange(fn: (value: ProgrammeDTO | ProgrammeDTO[] | null) => void): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: () => void): void {
    this.onTouched = fn;
  }

  setDisabledState(isDisabled: boolean): void {
    if (isDisabled) {
      this.control.disable({ emitEvent: false });
    } else {
      this.control.enable({ emitEvent: false });
    }
  }
}