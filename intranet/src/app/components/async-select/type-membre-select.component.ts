import { Component, forwardRef, inject, input } from '@angular/core';
import { RegistreModuleService } from 'src/app/pages/registre/services/registre-module.service';
import { AsyncSelectComponent } from "./async-select.component";
import { TypeMembreDTO } from 'src/app/core/helios-api-client/model/models';
import { ControlValueAccessor, FormControl, NG_VALUE_ACCESSOR, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-type-membre-select',
  imports: [AsyncSelectComponent, ReactiveFormsModule],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => TypeMembreSelectComponent),
      multi: true
    }
  ],
  template: '<app-async-select [dataSource]="membres" [formControl]="control" placeholder="Membre" [multiple]="multiple()" clearOptionText="Tous les membres" label="Filtrer par membre" placeholder="Sélectionnez un ou plusieurs membres"></app-async-select>',
})
export class TypeMembreSelectComponent implements ControlValueAccessor {
  private registre = inject(RegistreModuleService);
  multiple = input<boolean>(false);

  control = new FormControl<TypeMembreDTO | TypeMembreDTO[] | null>(null);

  private onChange = (value: TypeMembreDTO | TypeMembreDTO[] | null) => { };
  private onTouched = () => { };

  constructor() {
    this.control.valueChanges.subscribe(value => {
      this.onChange(value);
    });
  }

  writeValue(value: TypeMembreDTO | TypeMembreDTO[] | null): void {
    this.control.setValue(value, { emitEvent: false });
  }

  registerOnChange(fn: (value: TypeMembreDTO | TypeMembreDTO[] | null) => void): void {
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

  get membres() { return this.registre.$aspects; }
}