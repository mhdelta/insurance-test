import { Component, OnInit } from '@angular/core';


export interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}

export const ROUTES: RouteInfo[] = [
    { path: '/clientes',     title: 'Clientes',         icon:'nc-badge',       class: '' },
    { path: '/polizas',     title: 'Polizas',         icon:'nc-badge',       class: '' },
    { path: '/asignacion-polizas',     title: 'Asignación de polizas',         icon:'nc-badge',       class: '' },
];

@Component({
    moduleId: module.id,
    selector: 'sidebar-cmp',
    templateUrl: 'sidebar.component.html',
})

export class SidebarComponent implements OnInit {
    public menuItems: any[];
    ngOnInit() {
        this.menuItems = ROUTES.filter(menuItem => menuItem);
    }
}
