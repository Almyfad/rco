# AsyncSelectComponent - Usage

## Refactorisation effectuée

Le composant `AsyncSelectComponent` a été refactorisé pour implémenter correctement `ControlValueAccessor` par délégation. 

### Changements principaux :

1. **Implémentation complète de ControlValueAccessor** :
   - `writeValue()` : Reçoit la valeur du formulaire parent
   - `registerOnChange()` : Enregistre le callback pour notifier les changements
   - `registerOnTouched()` : Enregistre le callback pour notifier les interactions
   - `setDisabledState()` : Gère l'état disabled/enabled

2. **Délégation propre** :
   - Le `FormControl` interne (`selectControl`) gère l'état local
   - Les changements sont propagés automatiquement au formulaire parent
   - Pas de double gestion d'état (suppression des `model` et `signal`)

3. **Simplification** :
   - Suppression de la logique complexe de gestion d'état
   - Code plus lisible et maintenable
   - Meilleure intégration avec les formulaires Angular

## Utilisation

### Avec Reactive Forms

```typescript
import { FormBuilder, FormGroup } from '@angular/forms';

export class MyComponent {
  form: FormGroup;
  
  constructor(private fb: FormBuilder) {
    this.form = this.fb.group({
      selectedItems: [null] // ou [] pour multiple
    });
  }
  
  // Resource pour les données asynchrones
  dataResource = rxResource({
    request: () => ({}),
    loader: () => this.myService.getData()
  });
}
```

```html
<form [formGroup]="form">
  <app-async-select
    formControlName="selectedItems"
    [dataSource]="dataResource"
    label="Sélectionner des éléments"
    placeholder="Choisissez..."
    [multiple]="true"
    [clearOption]="true"
    [allOptions]="true">
  </app-async-select>
</form>
```

### Avec Template-driven Forms

```html
<app-async-select
  [(ngModel)]="selectedValue"
  [dataSource]="dataResource"
  label="Sélectionner un élément"
  name="selection">
</app-async-select>
```

### Avec des validateurs

```typescript
this.form = this.fb.group({
  selectedItems: [null, [Validators.required]]
});
```

## Avantages de cette approche

1. **Intégration native** : Fonctionne parfaitement avec les formulaires Angular
2. **Validation automatique** : Support complet des validateurs Angular
3. **État synchronisé** : Pas de désynchronisation entre le composant et le formulaire
4. **Performance** : Moins de watchers et de logique complexe
5. **Maintenabilité** : Code plus simple et standard
6. **Accessibilité** : Meilleur support des fonctionnalités d'accessibilité

## Migration depuis l'ancienne version

Si vous utilisiez le composant avec `values` en tant que `model`, changez vers `formControlName` ou `ngModel` :

```typescript
// AVANT
<app-async-select [(values)]="myValues">

// APRÈS  
<app-async-select formControlName="myField">
// ou
<app-async-select [(ngModel)]="myValues">
```

## Composants dérivés (CentreSelectComponent, etc.)

Les composants dérivés (`CentreSelectComponent`, `TypeMembreSelectComponent`, `StatusSelectComponent`, `TimelineTypeSelectComponent`) ont été également mis à jour pour implémenter `ControlValueAccessor`. 

**L'API publique reste identique** - vous pouvez continuer à les utiliser exactement de la même manière :

```html
<!-- Toujours valide - l'API publique n'a pas changé -->
<app-centre-select formControlName="centre" [multiple]="true"></app-centre-select>
<app-status-select [(ngModel)]="selectedStatus"></app-status-select>
<app-type-timeline-select formControlName="eventType"></app-type-timeline-select>
```

Ces composants délèguent maintenant proprement à `AsyncSelectComponent` via `ControlValueAccessor`.