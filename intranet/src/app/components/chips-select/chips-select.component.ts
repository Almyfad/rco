import { Component, Input, input, model, effect } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { SelectChip } from 'src/app/pages/planning/ressources-picker/ressources-picker.component';



@Component({
  selector: 'app-chips-select',
  imports: [CommonModule, MatIconModule],
  templateUrl: './chips-select.component.html',
  styleUrl: './chips-select.component.scss'
})
export class ChipsSelectComponent<T> {
  
  constructor() {
    // Synchroniser les valeurs sélectionnées dès que les chips changent
    effect(() => {
      const currentChips = this.chips();
      const selectedValues = currentChips.filter(chip => chip.selected).map(chip => chip.value);
      this.selectedValues.set(selectedValues);
    });
  }

  onChipClick(chip: SelectChip<T>) {
    chip.selected = !chip.selected;
    this.selectedValue.set(chip);
    
    const selectedValues = this.chips().filter(c => c.selected).map(c => c.value);
    this.selectedValues.set(selectedValues);
  }

  selectAll() {
    this.chips().forEach(chip => chip.selected = true);
    const selectedValues = this.chips().map(c => c.value);
    this.selectedValues.set(selectedValues);
  }

  deselectAll() {
    this.chips().forEach(chip => chip.selected = false);
    this.selectedValues.set([]);
  }

  chips = input.required<SelectChip<T>[]>();
  selectedValues = model<T[]>([]);
  selectedValue = model<SelectChip<T> | null>(null);
  @Input() emptyStateText = 'Aucun élément disponible';

}
