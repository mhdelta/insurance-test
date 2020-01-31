import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from "ngx-spinner";
import { Router } from '@angular/router';
import { PolicyService } from 'app/services/policy.service';

@Component({
  selector: 'app-policy',
  templateUrl: './policy.component.html',
  providers: [PolicyService],
})
export class PolicyComponent implements OnInit {

  policiesDataSource: any = []

  constructor(
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private policyService: PolicyService,
    private router: Router
  ) { }

  ngOnInit() {
    this.getPolicies();
  }

  getPolicies() {
    this.policyService.getAll().then(res => {
      this.policiesDataSource = res.body;
      console.log(this.policiesDataSource)
    }, err => {
      console.error(err)
    })
  }

  createClient() {
    this.router.navigate(["crear-poliza"])
  }

  editClient(e) {
    this.router.navigate(["polizas", e.data.id])
  }

  deleteEvent(e) {
    if (e.rowType == "data" && e.column.caption == "Eliminar") {
      this.policyService.remove(e.data.id).then(res => 
        {
          this.toastr.success("Se eliminó la poliza correctamente");
          this.getPolicies();
        })
    }
  } 
}
