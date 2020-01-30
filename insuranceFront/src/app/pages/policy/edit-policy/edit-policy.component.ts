import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { ClientsService as ClientesService } from 'app/services/clients.service';
import { formatDate } from '@angular/common';
import { PolicyService } from 'app/services/policy.service';
import { CoverTypeService } from 'app/services/cover-type.service';
import { RiskTypeService } from 'app/services/risk-type.service';
import { Policy } from 'app/models/policy.model';

@Component({
  selector: 'app-edit-policy',
  templateUrl: './edit-policy.component.html',
  providers: [PolicyService, CoverTypeService, RiskTypeService]
})
export class EditPolicyComponent implements OnInit {
  
  modesEnum = modesEnum;
  currentMode = modesEnum.Creation;
  id: any;
  policy: Policy = new Policy;
  coverItems: any = [];
  filteredCoverItems: any = [];
  riskItems: any = [];
  coverLoaded = false;
  riskLoaded = false;
  
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private policyService: PolicyService,
    private riskService: RiskTypeService,
    private coverService: CoverTypeService,
    private cdRef: ChangeDetectorRef,
    private activatedRoute: ActivatedRoute
  ) {
    this.id = activatedRoute.snapshot.params.id
    this.currentMode = !this.id ? modesEnum.Creation : modesEnum.Edition;
   }

  ngOnInit() {
    this.loadSelectDomains()
    if (this.id) {
      this.policyService.getById(+this.id).then(res => {
        this.policy = res.body;
        console.log(this.policy)
      }, err => console.error(err))
    }
  }

  save() {
    if (this.validateFields()) {
      if (this.currentMode == modesEnum.Creation) {
        this.policyService.Add(this.policy).then(res => {
          this.toastr.success("La poliza se guardó satisfactoriamente")
          console.log(res)
          this.router.navigate(["polizas"])
        }, err => console.error(err))
      }
      if (this.currentMode == modesEnum.Edition) {
        this.policyService.Modify(this.policy).then(res => {
          this.toastr.success("La poliza se modificó satisfactoriamente")
          console.log(res)
          this.router.navigate(["polizas"])
        }, err => console.error(err))
      }
    }
  }
  loadSelectDomains() {
    this.coverService.getAll().then(res => {
      this.coverItems = res.body
      this.filteredCoverItems = res.body;
      this.coverLoaded = true;
    }, err => console.error(err))
    
    this.riskService.getAll().then(res => {
      this.riskItems = res.body
      this.riskLoaded = true
    }, err => console.error(err))
  }

  getPercentage() {
    if (this.policy && this.policy.tipoCubrimiento) {
      let value = this.coverItems.find(x => x.id == this.policy.tipoCubrimiento).porcentaje;
      return value+"%"
    }
  }

  changeCoverDataSource() {
    this.policy.tipoCubrimiento = 0;
    let riskValue = this.riskItems.find(x => x.id == this.policy.tipoRiesgo);
    if (riskValue && riskValue.descripcion == "Alto") {
      this.filteredCoverItems = this.coverItems.filter(x => x.porcentaje < 50);
    } else {
      this.filteredCoverItems = this.coverItems;
    }
  }

  validateFields() {
    let valid = true;
    let missingParams = "";

    if (!this.policy.nombre || this.policy.nombre == "") {
      valid = false
      missingParams = missingParams.concat("\n nombre de la poliza ")
    }

    if (!this.policy.descripcion || this.policy.descripcion == "") {
      valid = false
      missingParams = missingParams.concat("\n Descripción ")
    }

    if (!this.policy.inicioVigencia || this.policy.inicioVigencia == "") {
      valid = false
      missingParams = missingParams.concat("\n Fecha inicio vigencia ")
    }

    if (!this.policy.mesesCobertura) {
      valid = false
      missingParams = missingParams.concat("\n Meses cobertura ")
    }

    if (!this.policy.precio) {
      valid = false
      missingParams = missingParams.concat("\n Precio ")
    }

    if (!this.policy.tipoRiesgo) {
      valid = false
      missingParams = missingParams.concat("\n Tipo riesgo ")
    }

    if (!this.policy.tipoCubrimiento) {
      valid = false
      missingParams = missingParams.concat("\n Tipo cubrimiento ")
    }
    
    if (!valid) {
      this.toastr.warning("Los siguiente parámetros son obligatorios " + missingParams)
    }

    return valid
  }
}

export enum modesEnum {
  Creation,
  Edition
}