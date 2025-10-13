import { Component, inject, OnInit, OnDestroy, computed, Signal, Input, signal, effect } from '@angular/core';
import { MembreDTO, RegistreService, DataPagerOfMembreDTO, MembreFiltre, TypeMembreDTO, NullableOfStatutsMembres, CentreDTO, StatutMembreDTO } from 'src/app/core/helios-api-client';
import { MatTableDataSource } from '@angular/material/table';
import { SidenavService } from 'src/app/services/sidenav.service';
import { EleveDetailComponent } from '../eleve-detail/eleve-detail.component';
import { Router, ActivatedRoute } from '@angular/router';

import { MatTableModule } from '@angular/material/table';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { ReactiveFormsModule, FormsModule, FormControl } from '@angular/forms';
import { MaterialModule } from 'src/app/material.module';
import { CommonModule } from '@angular/common';
import { StatutMembreComponent,getStatusColor,getStatusIcon } from '../statut-membre/statut-membre.component';
import { AsyncSelectComponent } from 'src/app/components/async-select/async-select.component';
import { debounceTime, distinctUntilChanged, Subject, takeUntil, Observable } from 'rxjs';
import { RegistreModuleService } from '../services/registre-module.service';
import { TablerIconsModule } from "angular-tabler-icons";
import { EleveFormComponent } from '../form/eleve-form/eleve-form.component';
import { CentreSelectComponent, TypeMembreSelectComponent, StatusSelectComponent } from "src/app/components/async-select";
import { rxResource } from "@angular/core/rxjs-interop";

@Component({
  selector: 'app-eleves-datatable',
  imports: [
    CommonModule,
    MatTableModule,
    MatProgressBarModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    ReactiveFormsModule,
    FormsModule,
    MaterialModule,
    StatutMembreComponent,
    TablerIconsModule,
    CentreSelectComponent,
    TypeMembreSelectComponent,
    StatusSelectComponent
],
  templateUrl: './eleves-datatable.component.html',
  styleUrl: './eleves-datatable.component.scss'
})
export class ElevesDataTableComponent implements OnInit, OnDestroy {

  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);
  private readonly rs = inject(RegistreService);
  private readonly sidenavService = inject(SidenavService);
  private readonly registre = inject(RegistreModuleService);
  private readonly destroy$ = new Subject<void>();
  @Input({ required: true }) fetch!: (page?: number, size?: number, filtre?: MembreFiltre) => Observable<DataPagerOfMembreDTO>;


  displayedColumns: string[] = ['statut', 'nom', 'prenom', 'email', 'telephone', 'adresse', 'ville', 'pays'];
  pageSizeOptions = [10, 25, 50, 100];

  // Contrôles de filtrage
  nomFilterControl = new FormControl('');
  prenomFilterControl = new FormControl('');
  emailFilterControl = new FormControl('');
  villeFilterControl = new FormControl('');
  paysFilterControl = new FormControl('');
  
  // Signaux pour les filtres de sélection (writable signals)
  centres = signal<CentreDTO[] | null>(null);
  typesmembres = signal<TypeMembreDTO[] | null>(null);
  status = signal<StatutMembreDTO[] | null>(null);
  
  // Computed pour récupérer les valeurs sélectionnées
  selectedCentres = computed(() => {
    return this.centres() || [];
  });

  selectedAspects = computed(() => {
    return this.typesmembres() || [];
  });

  selectedStatuts = computed(() => {
    return this.status() || [];
  });

  // Signals pour la pagination
  currentPageSignal = signal(0);
  pageSizeSignal = signal(50);

  // Signals pour les filtres de texte avec debounce
  nomFilter = signal('');
  prenomFilter = signal('');
  emailFilter = signal('');
  villeFilter = signal('');
  paysFilter = signal('');

  // Computed pour le filtre complet
  filter = computed(() => {
    const filter: MembreFiltre = {};
    
    const nom = this.nomFilter().trim();
    const prenom = this.prenomFilter().trim();
    const email = this.emailFilter().trim();
    const ville = this.villeFilter().trim();
    const pays = this.paysFilter().trim();
    
    if (nom) filter.nom = nom;
    if (prenom) filter.prenom = prenom;
    if (email) filter.email = email;
    if (ville) filter.ville = ville;
    if (pays) filter.pays = pays;
    
    const centres = this.selectedCentres();
    const aspects = this.selectedAspects();
    const statuts = this.selectedStatuts();
    
    if (centres.length > 0) filter.l_centres = centres.map(c => c.libelle || '').filter(c => c);
    if (aspects.length > 0) filter.l_aspects = aspects.map(a => a.id || 0).filter(a => a);
    if (statuts.length > 0) filter.l_statuts = statuts.map(s => s.id || 0).filter(s => s);
    
    return filter;
  });

  // Request parameters pour rxResource
  requestParams = computed(() => ({
    page: this.currentPageSignal() + 1,
    size: this.pageSizeSignal(),
    filter: this.filter()
  }));

  // rxResource pour les données
  elevesResource = rxResource({
    request: () => this.requestParams(),
    loader: ({ request }) => this.fetch(request.page, request.size, request.filter)
  });

  // Computed properties pour l'affichage
  dataSource = computed(() => {
    const data = this.elevesResource.value()?.data || [];
    const matTableDataSource = new MatTableDataSource<MembreDTO>(data);
    return matTableDataSource;
  });

  totalElements = computed(() => this.elevesResource.value()?.total || 0);
  loading = computed(() => this.elevesResource.isLoading());
  currentPage = computed(() => this.currentPageSignal());
  pageSize = computed(() => this.pageSizeSignal());

  // Propriété pour le collapse des filtres
  filtersExpanded = false;

  constructor() {
    // Effect pour reset la page lors du changement de filtres
    effect(() => {
      // Écouter tous les changements de filtres
      this.filter();
      // Reset à la première page
      this.currentPageSignal.set(0);
    }, { allowSignalWrites: true });
  }

  ngOnInit(): void {
    this.setupFilters();
    
    // Écouter les changements de paramètres d'URL pour détecter l'ID
    this.route.params.pipe(takeUntil(this.destroy$)).subscribe(params => {
      const eleveId = params['id'];
      if (eleveId) {
        this.openEleveDetailById(Number(eleveId));
      }
    });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  setupFilters(): void {
    // Configuration du debounce pour le filtre nom
    this.nomFilterControl.valueChanges
      .pipe(
        debounceTime(300),
        distinctUntilChanged(),
        takeUntil(this.destroy$)
      )
      .subscribe(value => {
        if (!value || value.trim().length === 0 || value.trim().length >= 3) {
          this.nomFilter.set(value || '');
        }
      });

    // Configuration du debounce pour le filtre prénom
    this.prenomFilterControl.valueChanges
      .pipe(
        debounceTime(300),
        distinctUntilChanged(),
        takeUntil(this.destroy$)
      )
      .subscribe(value => {
        if (!value || value.trim().length === 0 || value.trim().length >= 3) {
          this.prenomFilter.set(value || '');
        }
      });

    // Configuration du debounce pour le filtre email
    this.emailFilterControl.valueChanges
      .pipe(
        debounceTime(300),
        distinctUntilChanged(),
        takeUntil(this.destroy$)
      )
      .subscribe(value => {
        if (!value || value.trim().length === 0 || value.trim().length >= 3) {
          this.emailFilter.set(value || '');
        }
      });

    // Configuration du debounce pour le filtre ville
    this.villeFilterControl.valueChanges
      .pipe(
        debounceTime(300),
        distinctUntilChanged(),
        takeUntil(this.destroy$)
      )
      .subscribe(value => {
        if (!value || value.trim().length === 0 || value.trim().length >= 3) {
          this.villeFilter.set(value || '');
        }
      });

    // Configuration du debounce pour le filtre pays
    this.paysFilterControl.valueChanges
      .pipe(
        debounceTime(300),
        distinctUntilChanged(),
        takeUntil(this.destroy$)
      )
      .subscribe(value => {
        if (!value || value.trim().length === 0 || value.trim().length >= 3) {
          this.paysFilter.set(value || '');
        }
      });

    // Les signaux se mettent à jour automatiquement avec ngModel
    // et déclenchent la mise à jour du rxResource via l'effect existant
  }
  addNewEleve() {
    this.registre.clearEleve();
    this.sidenavService
      .setComponent(EleveFormComponent)
      .setTitle('Ajouter un élève')
      .setWidth('500px')
      .open();
  }



  /**
   * Gère les changements de pagination
   * @param event - Événement de pagination Material
   */
  onPageChange(event: PageEvent): void {
    this.currentPageSignal.set(event.pageIndex);
    this.pageSizeSignal.set(event.pageSize);
  }



  openEleveDetailById(id: number): void {

      this.rs.apiRegistreMembresIdGet(id).subscribe({
        next: (response: MembreDTO) => {
          this.openEleveDetail(response);
        },
        error: (error) => {
          console.error('Erreur lors de la recherche de l\'élève:', error);
          this.router.navigate(['/registre/fiches/eleves']);
        }
      });
  }

  /**
   * Ouvre effectivement la sidenav avec le détail de l'élève
   * @param eleve - L'élève dont on veut afficher le détail
   */
  openEleveDetail(eleve: MembreDTO): void {
    this.registre.setEleve(eleve);
    this.sidenavService
      .setComponent(EleveDetailComponent)
      .setTitle('🧾 Détail de l\'élève id: ' + eleve.id)
      .setWidth('500px')
      .open();
  }

  /**
   * Bascule l'état d'expansion du panneau de filtres
   */
  toggleFilters(): void {
    this.filtersExpanded = !this.filtersExpanded;
  }
}
