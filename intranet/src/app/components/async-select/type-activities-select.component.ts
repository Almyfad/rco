import { Component, forwardRef, inject } from '@angular/core';
import { AsyncSelectComponent } from "./async-select.component";
import { TypeActiviteDTO } from 'src/app/core/helios-api-client/model/models';
import { ControlValueAccessor, FormControl, NG_VALUE_ACCESSOR, ReactiveFormsModule } from '@angular/forms';
import { rxResource } from '@angular/core/rxjs-interop';
import { PlanningService } from 'src/app/core/helios-api-client/api/api';

@Component({
  selector: 'app-type-activities-select',
  imports: [AsyncSelectComponent, ReactiveFormsModule],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => TypeActivitiesSelectComponent),
      multi: true
    }
  ],
  template: '<app-async-select [formControl]="control" label="Type d\'activité" placeholder="Sélectionnez un type d\'activité" [dataSource]="$typeActivites" ></app-async-select>',
})
export class TypeActivitiesSelectComponent implements ControlValueAccessor {
  private planning = inject(PlanningService);

  control = new FormControl<TypeActiviteDTO | TypeActiviteDTO[] | null>(null);
  
  $typeActivites = rxResource({
    loader: () => this.planning.apiPlanningTypeactivitiesGet()
  });

  private onChange = (value: TypeActiviteDTO | TypeActiviteDTO[] | null) => { };
  private onTouched = () => { };

  constructor() {
    this.control.valueChanges.subscribe(value => {
      this.onChange(value);
    });
  }

  writeValue(value: TypeActiviteDTO | TypeActiviteDTO[] | null): void {
    this.control.setValue(value, { emitEvent: false });
  }

  registerOnChange(fn: (value: TypeActiviteDTO | TypeActiviteDTO[] | null) => void): void {
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