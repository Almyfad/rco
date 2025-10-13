import { Component, computed, forwardRef, inject, Injector, Input, ResourceRef, runInInjectionContext } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatSelectChange, MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatIconModule } from '@angular/material/icon';
import { ControlValueAccessor, FormBuilder, FormControl, NG_VALUE_ACCESSOR, ReactiveFormsModule } from '@angular/forms';
import { TablerIconsModule } from "angular-tabler-icons";
import { rxResource, RxResourceOptions, } from "@angular/core/rxjs-interop";
import { of } from 'rxjs';
interface SelectOption<T> {
    value: T;
    label: string;
    icon?: string;
    iconColor?: string;
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
export class AsyncSelectComponent<T> implements ControlValueAccessor {
    @Input() label: string = 'Sélectionner';
    @Input() placeholder: string = 'Choisissez une option';
    @Input() clearOption: boolean = false;
    @Input() clearOptionText: string = 'Aucun filtre';
    @Input() allOptions: boolean = false;
    @Input() allOptionsText: string = 'Tous les éléments';
    @Input() multiple: boolean = false;
    @Input() compareWith?: (a: T | null, b: T | null) => boolean;
    @Input() getLabel?: (a: T | null) => string;
    
    readonly fb = inject(FormBuilder);
    readonly injector = inject(Injector);

    // ControlValueAccessor callbacks
    private onChange = (value: T | T[] | null) => {};
    private onTouched = () => {};

    private _dataSource!: ResourceRef<T[]>;
    private rxsource!: ResourceRef<SelectOption<T>[]>;

    @Input({ required: true })
    get dataSource(): ResourceRef<T[]> {
        return this._dataSource;
    }

    set dataSource(value: ResourceRef<T[]>) {
        this._dataSource = value;
        runInInjectionContext(this.injector, () => {
            this.rxsource = rxResource({
                request: () => value.value(),
                loader: ({ request }) => {
                    const mappedData = request?.map((item) => this.toSelectOption(item)) || [];
                    return of(mappedData);
                }
            });
        });
    }

    loading = computed(() => { return this.rxsource?.isLoading() || false; });
    options = computed(() => {
        if (this.rxsource?.error()) return [];
        return this.rxsource?.value() || [];
    })
    selectControl = this.fb.control<T | T[] | null>(this.multiple ? [] : null);

    constructor() {
        // Déléguer les changements du FormControl interne vers le parent
        this.selectControl.valueChanges.subscribe(value => {
            this.onChange(value);
        });
    }

    // Implémentation de ControlValueAccessor

    writeValue(value: T | T[] | null): void {
        this.selectControl.setValue(value, { emitEvent: false });
    }

    registerOnChange(fn: (value: T | T[] | null) => void): void {
        this.onChange = fn;
    }

    registerOnTouched(fn: () => void): void {
        this.onTouched = fn;
    }

    setDisabledState(isDisabled: boolean): void {
        if (isDisabled) {
            this.selectControl.disable({ emitEvent: false });
        } else {
            this.selectControl.enable({ emitEvent: false });
        }
    }


    selectAll() {
        if (!this.multiple) return;
        const allValues = this.options().map(o => o.value);
        this.selectControl.setValue(allValues);
    }

    // Réinitialise la sélection
    clear(): void {
        const val = this.multiple ? [] : null;
        this.selectControl.setValue(val);
    }

    // à appeler depuis le template (ex: (blur))
    markTouched(): void {
        this.onTouched();
    }


    fnLabel(value: T): string {
        if (this.getLabel) return this.getLabel(value);
        const v = value as any;
        return v.label ?? v.libelle ?? v.name ?? v.nom ?? v.description;
    }
    fnIcon(value: T): string | undefined {
        return (value as any).icon;
    }
    fnIconColor(value: T): string | undefined {
        return (value as any).iconColor;
    }
    toSelectOption(value: T): SelectOption<T> {
        return {
            label: this.fnLabel(value),
            icon: this.fnIcon(value),
            iconColor: this.fnIconColor(value),
            value: value,
        };
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

