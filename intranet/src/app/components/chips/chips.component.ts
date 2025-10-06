import { Component, Input, model } from '@angular/core';
import { MatIconModule } from "@angular/material/icon";




@Component({
  selector: 'app-chips',
  imports: [MatIconModule],
  templateUrl: './chips.component.html',
  styleUrl: './chips.component.scss'
})
export class ChipsComponent {
  onChipClick() {
    if (this.autoupdate)
      this.selected.set(!this.selected());
  }
  selected = model.required<boolean>();
  @Input() label: string = '';
  @Input() icon?: string;
  @Input() autoupdate: boolean = true;
}
