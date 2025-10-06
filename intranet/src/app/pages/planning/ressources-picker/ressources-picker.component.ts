import { Component, computed, effect, inject, model, ModelSignal, signal, WritableSignal } from '@angular/core';
import { RessourcePickerComponent } from "../ressource-picker/ressource-picker.component";
import { CentreDTO, FlatProgrammeDTO, PlanningService, ProgrammeDTO2, RegistreService } from 'src/app/core/helios-api-client';
import { rxResource } from '@angular/core/rxjs-interop';
import { MatIconModule } from "@angular/material/icon";
import { flatMap } from 'rxjs/internal/operators/flatMap';

export interface SelectChip<T> {
  value: T;
  label: string;
  icon?: string;
  iconColor?: string;
  selected?: boolean;
}

@Component({
  selector: 'app-ressources-picker',
  imports: [RessourcePickerComponent, MatIconModule],
  templateUrl: './ressources-picker.component.html',
  styleUrl: './ressources-picker.component.scss'
})
export class RessourcesPickerComponent {
  deselectAll() {
    const picked = this._ressourcesPicked();
    for (const centreId in picked) {
      if (picked.hasOwnProperty(centreId)) {
        picked[centreId].set([]);
      }
    }
  }

  selectAll() {
    const centres = this.centres.value();
    const picked = this._ressourcesPicked();
    
    if (centres) {
      for (const centre of centres) {
        if (centre.id && picked[centre.id]) {
          picked[centre.id].set(centre.programmes ?? []);
        }
      }
    }
  }

  private readonly planningService = inject(PlanningService);
  private readonly registreService = inject(RegistreService);


  centres = rxResource({
    request: () => 0,
    loader: ({ request }) => this.planningService.apiPlanningCentresProgrammesGet()
  });
  
  private _ressourcesPicked = signal<RessourcesPicked>({});
  
  // Getter qui retourne la valeur actuelle pour le template
  ressourcesPicked = () => this._ressourcesPicked();
  
  // Signal privé pour les calculs internes
  private _ressources = computed(() => {
    const picked = this._ressourcesPicked();
    const centres = this.centres.value();
    const ressources: Ressources[] = [];
    
    for (const centreId in picked) {
      if (picked.hasOwnProperty(centreId)) {
        const programmes = picked[centreId]();
        if (programmes.length > 0) {
          ressources.push({
            centre: centres?.find(c => c.id === +centreId)!,
            programmes: programmes
          });
        }
      }
    }
    
    return ressources;
  });

  // Model public exposé au parent
  ressources = model<Ressources[]>([]);

  allprogrammesCount = computed(() => {
    const all = this.ressources().flatMap(r => r.programmes);
    return all.length;
  });


  constructor() {
    // Effect pour initialiser les signaux des centres
    effect(() => {
      const centres = this.centres.value();
      if (centres) {
        const current = this._ressourcesPicked();
        const map: RessourcesPicked = { ...current };
        let hasChanges = false;
        
        for (const centre of centres) {
          if (centre.id && !map[centre.id]) {
            map[centre.id] = signal<ProgrammeDTO2[]>([]);
            hasChanges = true;
          }
        }
        
        if (hasChanges) {
          this._ressourcesPicked.set(map);
        }
      }
    });

    // Effect pour synchroniser le signal privé avec le model public
    effect(() => {
      const newRessources = this._ressources();
      this.ressources.set(newRessources);
    });
  }
}

type RessourcesPicked = Record<number, WritableSignal<ProgrammeDTO2[]>>;



export interface Ressources {
  centre: CentreDTO;
  programmes: ProgrammeDTO2[];
}
