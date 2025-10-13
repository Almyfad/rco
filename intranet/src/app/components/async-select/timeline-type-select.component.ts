import { Component, forwardRef, inject } from '@angular/core';
import { RegistreModuleService } from 'src/app/pages/registre/services/registre-module.service';
import { AsyncSelectComponent } from "./async-select.component";
import { TimelineMembreType } from 'src/app/core/helios-api-client/model/models';
import { ControlValueAccessor, FormControl, NG_VALUE_ACCESSOR, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-type-timeline-select',
  imports: [AsyncSelectComponent, ReactiveFormsModule],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => TimelineTypeSelectComponent),
      multi: true
    }
  ],
  template: '<app-async-select [formControl]="control" label="Type" placeholder="Sélectionnez un évènement" [dataSource]="typeoptions" ></app-async-select>',
})
export class TimelineTypeSelectComponent implements ControlValueAccessor {
  private registre = inject(RegistreModuleService);

  control = new FormControl<TimelineMembreType | TimelineMembreType[] | null>(null);

  private onChange = (value: TimelineMembreType | TimelineMembreType[] | null) => { };
  private onTouched = () => { };

  constructor() {
    this.control.valueChanges.subscribe(value => {
      this.onChange(value);
    });
  }

  writeValue(value: TimelineMembreType | TimelineMembreType[] | null): void {
    this.control.setValue(value, { emitEvent: false });
  }

  registerOnChange(fn: (value: TimelineMembreType | TimelineMembreType[] | null) => void): void {
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

  get typeoptions() { return this.registre.$timelineTypes; }
}