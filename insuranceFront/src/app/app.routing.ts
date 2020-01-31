import { Routes } from '@angular/router';

import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { CanActivateViaAuthGuard } from './guards/canactivate.guard';

export const AppRoutes: Routes = [
  {
    path: '',
    redirectTo: '/',
    pathMatch: 'full',
  }, {
    path: '',
    component: AdminLayoutComponent,
    children: [
        {
      path: '',
      loadChildren: './layouts/admin-layout/admin-layout.module#AdminLayoutModule',
      
  }]},
  {
    path: '**',
    redirectTo: '/'
  }
]
