import { Routes } from '@angular/router';
import { BlankComponent } from './layouts/blank/blank.component';
import { FullComponent } from './layouts/full/full.component';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
  {
    path: '',
    component: FullComponent,
    canActivate: [authGuard],
    canActivateChild: [authGuard],
    children: [
      {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full',
      },
      {
        path: 'home',
        loadChildren: () =>
          import('./pages/pages.routes').then((m) => m.PagesRoutes),
      },
      {
        path: 'developpment',
        loadComponent: () =>
          import('./pages/starter/starter.component').then((m) => m.StarterComponent),
      },
      {
        path: 'sample-page',
        loadChildren: () =>
          import('./pages/pages.routes').then((m) => m.PagesRoutes),
      },
      {
        path:'registre',
        loadChildren: () =>
          import('./pages/registre/registre.route').then((m) => m.RegistreRoutes),
      },
      {
        path: 'planning',
        data: {
          title: 'Gestion des plannings',
          urls: [
            { title: 'Accueil', url: '/' },
            { title: 'Gestion des plannings' },
          ],
        },
        loadComponent: () =>
          import('./pages/planning/planning.component').then((m) => m.PlanningComponent),
      },
      {
        path: 'sidenav-demo',
        loadComponent: () =>
          import('./components/sidenav-demo/sidenav-demo.component').then(
            (m) => m.SidenavDemoComponent
          ),
      },
      {
        path: 'alternative-customizer',
        loadComponent: () =>
          import('./layouts/full/shared/alternative-customizer/alternative-customizer-page.component').then(
            (m) => m.AlternativeCustomizerPageComponent
          ),
      },
    ],
  },
  {
    path: '',
    component: BlankComponent,
    children: [
      {
        path: 'authentication',
        loadChildren: () =>
          import('./pages/authentication/authentication.routes').then(
            (m) => m.AuthenticationRoutes
          ),
      },
    ],
  },
  {
    path: 'public/planning',
    component: FullComponent,
    children: [
      {
        path: 'authentication',
        loadComponent: () =>
          import('./pages/planning/planning.component').then((m) => m.PlanningComponent),
      },
    ],
  },
  {
    path: '**',
    redirectTo: 'authentication/error',
  },
];
