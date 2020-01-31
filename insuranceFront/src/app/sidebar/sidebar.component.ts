import { Component, OnInit } from '@angular/core';
import { AuthService } from 'app/services/auth.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';


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
    providers: [AuthService]
})

export class SidebarComponent implements OnInit {
    public menuItems: any[];
    logged: boolean;
    constructor(
        private authService: AuthService,
        private toastr: ToastrService,
        private router: Router
    ) {}
    ngOnInit() {
        this.checkAuth();
    }
    checkAuth() {
        this.authService.IsAuthenticated().then((res: any) => {
            this.toastr.success("Autenticado exitosamente")
            this.menuItems =  ROUTES.filter(menuItem => menuItem);
            this.logged = true;
          }, err => {
            console.log(err)
            this.toastr.warning("Autenticación requerida")
            localStorage.removeItem("insuranceToken")
            this.logged = false;
            this.menuItems = []
          })
    }

    auth() {
        this.authService.Authenticate().then((res: any) => {
            localStorage.setItem("insuranceToken", res.body.token)
            this.checkAuth();    
        }, err => console.error(err))
    }

    logout() {
        this.logged = false;
        this.menuItems = [];
        this.router.navigate(["/"])
    }
}
