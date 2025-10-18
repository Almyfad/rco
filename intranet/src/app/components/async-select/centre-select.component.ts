import { Component, computed, forwardRef, inject, Input, input } from '@angular/core';
import { RegistreModuleService } from 'src/app/pages/registre/services/registre-module.service';
import { AsyncSelectComponent } from "./async-select.component";
import { CentreDTO } from 'src/app/core/helios-api-client/model/models';
import { ControlValueAccessor, FormControl, NG_VALUE_ACCESSOR, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-centre-select',
  imports: [AsyncSelectComponent, ReactiveFormsModule],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => CentreSelectComponent),
      multi: true
    }
  ],
  template: `<app-async-select [dataSource]="centres" [formControl]="control" placeholder="Centre" 
            [multiple]="multiple()" 
            [setValueId]="true"
            [clearOption]="clearOption()" clearOptionText="Aucun centre" 
            [allOptions]="allOptions()" allOptionsText="Tous les centres"
            label="Filtrer par centre" [placeholder]="placeholder()">
            </app-async-select>`,
})
export class CentreSelectComponent implements ControlValueAccessor {
  @Input() setValueId: boolean = false;
  private registre = inject(RegistreModuleService);
  multiple = input<boolean>(false);
  clearOption = input<boolean>(false);
  allOptions = input<boolean>(false);
  placeholder = computed(() => this.multiple() ? 'Sélectionnez un ou plusieurs centres' : 'Sélectionnez un centre');

  control = new FormControl<CentreDTO | CentreDTO[] | null>(null);

  private onChange = (value: CentreDTO | CentreDTO[] | null) => { };
  private onTouched = () => { };

  constructor() {
    this.control.valueChanges.subscribe(value => {
      this.onChange(value);
    });
  }

  writeValue(value: CentreDTO | CentreDTO[] | null): void {
    this.control.setValue(value, { emitEvent: false });
  }

  registerOnChange(fn: (value: CentreDTO | CentreDTO[] | null) => void): void {
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

  get centres() { return this.registre.$centres; }
}