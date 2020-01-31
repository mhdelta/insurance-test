import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from "ngx-spinner";
import { ClientsService } from 'app/services/clients.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  providers: [ClientsService],
})
export class ClientsComponent implements OnInit {

  clientsDataSource: any = []

  constructor(
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private clientService: ClientsService,
    private router: Router
  ) { }

  ngOnInit() {
    this.getClients();
  }

  getClients() {
    this.clientService.GetAll().then(res => {
      this.clientsDataSource = res.body;
    }, err => {
      console.error(err)
    })
  }

  createClient() {
    this.router.navigate(["crear-cliente"])
  }

  editClient(e) {
    this.router.navigate(["clientes", e.data.id])
  }
}
