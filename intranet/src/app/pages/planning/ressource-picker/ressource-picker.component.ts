import { Component, computed, effect, input, model } from '@angular/core';
import { CentreProgrammeDTO, ProgrammeDTO2 } from 'src/app/core/helios-api-client/model/models';
import { MatMenuModule } from "@angular/material/menu";
import { ChipsComponent } from "src/app/components/chips/chips.component";
import { MatIconModule } from "@angular/material/icon";

@Component({
  selector: 'app-ressource-picker',
  imports: [MatMenuModule, ChipsComponent, MatIconModule],
  templateUrl: './ressource-picker.component.html',
  styleUrl: './ressource-picker.component.scss'
})
export class RessourcePickerComponent {
  programme = input<boolean>(false);
  deselectAll() {
    this.ressourcePicked.set([]);
  }
  selectAll() {
    this.ressourcePicked.set(this.centre().programmes ?? []);
  }
  picked(p: ProgrammeDTO2) {
    //si present dans la liste, on l'enlève, sinon on l'ajoute 
    if (this.isMenuSelected(p)) {
      this.ressourcePicked.set(this.ressourcePicked().filter(pr => pr.id !== p.id));
    } else {
      this.ressourcePicked.set([...(this.ressourcePicked() ?? []), p]);
    }

  }

  isMenuSelected(p: ProgrammeDTO2) {
    return this.ressourcePicked()?.some(pr => pr.id === p.id);
  }

  centre = input.required<CentreProgrammeDTO>();
  ressourcePicked = model<ProgrammeDTO2[]>([]);
  selected = computed(() => {
    const current = this.centre().programmes?.map(p => this.isMenuSelected(p)).filter(s => s);
    return (current?.length ?? 0) > 0;
  }
  );

  centreSelected = model<boolean>(false);
  /**
   *
   */
  constructor() {
    effect(() => {
      const centreSelected = this.centreSelected();
      if (centreSelected) {
        this.ressourcePicked.set(this.centre().programmes ?? []);
      } else {
        this.ressourcePicked.set([]);
      }
    });
    effect(() => {
      const allProgrammes = this.centre().programmes ?? [];
      const pickedProgrammes = this.ressourcePicked() ?? [];
      this.centreSelected.set(pickedProgrammes.length === allProgrammes.length && allProgrammes.length > 0);
    });
  }
}