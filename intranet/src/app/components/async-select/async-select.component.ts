import { Component, computed, effect, EventEmitter, forwardRef, inject, Input, input, model, Output, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatSelectChange, MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatIconModule } from '@angular/material/icon';
import { FormBuilder, FormControl, NG_VALUE_ACCESSOR, ReactiveFormsModule } from '@angular/forms';
import { TablerIconsModule } from "angular-tabler-icons";

export interface SelectOption<T> {
    value: T;
    label: string;
    icon?: string;
    iconColor?: string;
}
export interface SelectedOption<T> {
    checked?: boolean;
    options: T;
}
@Component({
    selector: 'app-async-select',
    standalone: true,
    imports: [
        CommonModule,
        MatSelectModule,
        MatFormFieldModule,
        MatProgressSpinnerModule,
        MatIconModule,
        ReactiveFormsModule,
        TablerIconsModule
    ],
    providers: [
        {
            provide: NG_VALUE_ACCESSOR,
            useExisting: forwardRef(() => AsyncSelectComponent),
            multi: true
        }
    ],
    templateUrl: './async-select.component.html',
    styleUrl: './async-select.component.scss'
})
export class AsyncSelectComponent<T> {
    @Input() label: string = 'Sélectionner';
    @Input() placeholder: string = 'Choisissez une option';
    @Input() clearOptionText: string = 'Aucun filtre';
    @Input() multiple: boolean = false;
    @Input() compareWith?: (a: T | null, b: T | null) => boolean;
    @Output() selectionChange = new EventEmitter<SelectedOption<T>>();
    values = model<T | T[] | null>(this.multiple ? [] : null);
    lastValues = signal<T | T[] | null>(this.multiple ? [] : null);
    selectedValue = model<SelectedOption<T> | null>(null);
    readonly fb = inject(FormBuilder);

    loading = input(false);
    options = input.required<SelectOption<T>[] | null>();

    // FormControl interne utilisé par le template
    selectControl = this.fb.control<T | T[] | null>(this.multiple ? [] : null);
    private isDisabled = false;

    constructor() {
        // Propager les changements du FormControl interne vers le form control parent
        this.selectControl.valueChanges.subscribe(value => {
            this.values.set(value);

            if (!this.multiple) return;
            if (!Array.isArray(value)) return;

            const selectedOptions: T[] = value as T[];
            const lastValues = this.lastValues();
            const added = selectedOptions.filter(v => !(lastValues as (T[] | null))?.some(lv => this.compareWithFn(v, lv)));
            if (added.length > 0) {
                this.selectionChange.emit({ options: added[0], checked: true });
            }
            const removed = (lastValues as (T[] | null))?.filter(lv => !selectedOptions.some(v => this.compareWithFn(v, lv)));
            if (removed && removed.length > 0) {
                this.selectionChange.emit({ options: removed[0], checked: false });
            }
            this.lastValues.set(this.values());
        });
    }
    // ControlValueAccessor methods
    writeValue(value: any): void {
        // Ne pas émettre valueChanges lors de la mise à jour par writeValue
        this.selectControl.setValue(value, { emitEvent: false });
    }

    registerOnChange(fn: any): void {
    }

    registerOnTouched(fn: any): void {
    }

    setDisabledState(isDisabled: boolean): void {
        this.isDisabled = isDisabled;
        if (isDisabled) {
            this.selectControl.disable({ emitEvent: false });
        } else {
            this.selectControl.enable({ emitEvent: false });
        }
    }

    // méthodes utilitaires pour template / API externe
    // Permet de définir la valeur sélectionnée depuis l'extérieur
    setValue(value: T): void {
        this.writeValue(value);
        this.values.set(value);
    }

    // Réinitialise la sélection
    clear(): void {
        const val = this.multiple ? [] : null;
        this.writeValue(val);
        this.values.set(val);
    }

    // à appeler depuis le template (ex: (blur))
    markTouched(): void {
    }

    compareWithFn = (o1: T | null, o2: T | null): boolean => {
        if (this.compareWith) return this.compareWith(o1, o2);
        if (o1 === o2) return true;
        if (o1 && o2 && typeof o1 === 'object' && typeof o2 === 'object') {
            const a = o1 as any, b = o2 as any;
            if ('Id' in a && 'Id' in b) return a.Id === b.Id;
            if ('id' in a && 'id' in b) return a.id === b.id;
            if ('code' in a && 'code' in b) return a.code === b.code;
            if ('Code' in a && 'Code' in b) return a.Code === b.Code;
        }
        return false;
    }
}

