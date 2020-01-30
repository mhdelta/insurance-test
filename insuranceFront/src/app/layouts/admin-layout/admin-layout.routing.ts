import { Routes } from '@angular/router';

import { ClientsComponent } from 'app/pages/clients/clients.component';
import { EditClientsComponent } from 'app/pages/clients/edit-clients/edit-clients.component';
import { PolicyComponent } from 'app/pages/policy/policy.component';
import { EditPolicyComponent } from 'app/pages/policy/edit-policy/edit-policy.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'clientes',          component: ClientsComponent},
    { path: 'clientes/:id',      component: EditClientsComponent},
    { path: 'crear-cliente',      component: EditClientsComponent},
    { path: 'polizas',          component: PolicyComponent},
    { path: 'polizas/:id',      component: EditPolicyComponent},
    { path: 'crear-poliza',      component: EditPolicyComponent},
];
