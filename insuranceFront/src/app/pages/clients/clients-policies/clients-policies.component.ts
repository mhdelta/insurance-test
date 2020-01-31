import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from "ngx-spinner";
import { ClientsService } from 'app/services/clients.service';
import { Router } from '@angular/router';
import { PolicyService } from 'app/services/policy.service';

@Component({
  selector: 'app-clients-policies',
  templateUrl: './clients-policies.component.html',
  providers: [ClientsService, PolicyService],
})
export class ClientsPoliciesComponent implements OnInit {

  clientsDataSource: any = []
  showPopup = false;
  newPolicyAssignation = {
    idCliente: 0,
    idPoliza: 0
  }
  policiesDataSource: any;
  filteredPoliciesDataSource: any;
  assignedClientsDataSource: any;
  selectedClient: any = {};

  constructor(
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private clientService: ClientsService,
    private policyService: PolicyService,
    private router: Router
  ) { }

  ngOnInit() {
    this.getClients();
    this.getAssignedClients();
    this.getPolicies();
  }
  getAssignedClients() {
    this.clientService.GetAssigned().then(res => {
      this.assignedClientsDataSource = res.body;
      console.log("assigned", this.assignedClientsDataSource)
    }, err => {
      console.error(err)
    })
  }
  getPolicies() {
      this.policyService.getAll().then(res => {
        this.policiesDataSource = res.body;
        console.log(this.policiesDataSource)
      }, err => {
        console.error(err)
      })
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

  assignPolicy() {
    if (!this.newPolicyAssignation.idCliente || !this.newPolicyAssignation.idCliente) {
      this.toastr.warning("El cliente es obligatorio")
      return
    }

    if (!this.newPolicyAssignation.idPoliza || !this.newPolicyAssignation.idPoliza) {
      this.toastr.warning("La poliza es obligatoria")
      return
    }

    this.clientService.Assign(this.newPolicyAssignation).then(res => {
      this.toastr.success("Se asignó la poliza con éxito");
      console.log(res)
      this.getAssignedClients();
      this.showPopup = false;
      this.selectedClient = {};
    }, err => {
      console.error(err)
      this.toastr.error(err.error.text)
    })
  }

  deleteEvent(e) {
    if (e.rowType == "data" && e.column.caption == "Eliminar") {
      this.clientService.RemoveAssignation(e.data.idCliente, e.data.idPoliza).then(res => 
        {
          this.toastr.success("Se eliminó la asignación de poliza correctamente");
          this.selectedClient = {}
          this.getAssignedClients();
        })
    }
  }
}
