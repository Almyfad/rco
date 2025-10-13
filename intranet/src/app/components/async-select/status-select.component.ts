import { Component, forwardRef, inject, input } from '@angular/core';
import { RegistreModuleService } from 'src/app/pages/registre/services/registre-module.service';
import { AsyncSelectComponent } from "./async-select.component";
import { StatutMembreDTO } from 'src/app/core/helios-api-client/model/models';
import { ControlValueAccessor, FormControl, NG_VALUE_ACCESSOR, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-status-select',
  imports: [AsyncSelectComponent, ReactiveFormsModule],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => StatusSelectComponent),
      multi: true
    }
  ],
  template: '<app-async-select [dataSource]="statuts" [formControl]="control" placeholder="Statut" [multiple]="multiple()" clearOptionText="Tous les statuts" label="Filtrer par statut" placeholder="Sélectionnez un ou plusieurs statuts"></app-async-select>',
})
export class StatusSelectComponent implements ControlValueAccessor {
  private registre = inject(RegistreModuleService);
  multiple = input<boolean>(false);

  control = new FormControl<StatutMembreDTO | StatutMembreDTO[] | null>(null);

  private onChange = (value: StatutMembreDTO | StatutMembreDTO[] | null) => { };
  private onTouched = () => { };

  constructor() {
    this.control.valueChanges.subscribe(value => {
      this.onChange(value);
    });
  }

  writeValue(value: StatutMembreDTO | StatutMembreDTO[] | null): void {
    this.control.setValue(value, { emitEvent: false });
  }

  registerOnChange(fn: (value: StatutMembreDTO | StatutMembreDTO[] | null) => void): void {
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

  get statuts() { return this.registre.$statuts; }
}