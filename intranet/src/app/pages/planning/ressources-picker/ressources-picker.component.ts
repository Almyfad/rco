import {  Component, computed, effect, inject, input, model,  signal, WritableSignal } from '@angular/core';
import { RessourcePickerComponent } from "../ressource-picker/ressource-picker.component";
import { CentreDTO,  PlanningService, ProgrammeDTO2, RegistreService } from 'src/app/core/helios-api-client';
import { rxResource } from '@angular/core/rxjs-interop';
import { MatIconModule } from "@angular/material/icon";

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

  // Nouvelle méthode pour désélectionner tout sauf maintenir une sélection minimale
  deselectAllButKeepOne() {
    this.deselectAll();
    // Après désélection, s'assurer qu'une ressource reste sélectionnée
    setTimeout(() => this.selectDefaultRessource(), 0);
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

  selectDefaultRessource() {
    const centres = this.centres.value();
    const picked = this._ressourcesPicked();
    const vprogramme = this.programme();

    if (centres && centres.length > 0) {
      const firstCentre = centres[0];
      
      if (firstCentre.id && picked[firstCentre.id]) {
        if (vprogramme && firstCentre.programmes && firstCentre.programmes.length > 0) {
          // En mode programme : sélectionner le premier programme du premier centre
          picked[firstCentre.id].set([firstCentre.programmes[0]]);
        } else if (!vprogramme) {
          // En mode centre : sélectionner tous les programmes du premier centre
          picked[firstCentre.id].set(firstCentre.programmes ?? []);
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
  programme = input<boolean>(false);
  allprogrammesCount = computed(() => {
    const all = this.ressources().flatMap(r => r.programmes);
    return all.length;
  });
  selectedCentresCount = computed(() => {
    return this.ressources().length;
  });


  constructor() {
    // Effect pour initialiser les signaux des centres
    effect(() => {
      const centres = this.centres.value();
      if (centres && centres.length > 0) {
        const current = this._ressourcesPicked();
        const map: RessourcesPicked = { ...current };
        let hasChanges = false;
        let shouldSelectDefault = Object.keys(current).length === 0; // Première initialisation

        for (const centre of centres) {
          if (centre.id && !map[centre.id]) {
            map[centre.id] = signal<ProgrammeDTO2[]>([]);
            hasChanges = true;
          }
        }

        if (hasChanges) {
          this._ressourcesPicked.set(map);
          
          // Sélectionner par défaut la première ressource
          if (shouldSelectDefault) {
            this.selectDefaultRessource();
          }
        }
      }
    });

    // Effect pour synchroniser le signal privé avec le model public
    effect(() => {
      const newRessources = this._ressources();
      this.ressources.set(newRessources);
    });

    // Effect pour changer de mode (centre/programme)
    effect(() => {
      const vprogramme = this.programme();
      this.deselectAll();
      // Après désélection, sélectionner la première ressource par défaut
      setTimeout(() => this.selectDefaultRessource(), 0);
    });

    // Effect pour s'assurer qu'au moins une ressource soit sélectionnée
    effect(() => {
      const ressources = this.ressources();
      const vprogramme = this.programme();
      
      // Si aucune ressource n'est sélectionnée, sélectionner la première par défaut
      if (ressources.length === 0) {
        setTimeout(() => this.selectDefaultRessource(), 0);
      }
      // Si en mode programme et qu'aucun programme n'est sélectionné
      else if (vprogramme && this.allprogrammesCount() === 0) {
        setTimeout(() => this.selectDefaultRessource(), 0);
      }    
    });
  }

}

type RessourcesPicked = Record<number, WritableSignal<ProgrammeDTO2[]>>;



export interface Ressources {
  centre: CentreDTO;
  programmes: ProgrammeDTO2[];
}
