import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { ClientsService as ClientesService } from 'app/services/clients.service';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-edit-policy',
  templateUrl: './edit-policy.component.html',
  providers: [ClientesService]
})
export class EditPolicyComponent implements OnInit {
  
  modesEnum = modesEnum;
  currentMode = modesEnum.Creation;
  id: any;
  client: any = {};
  
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private clientService: ClientesService,
    private cdRef: ChangeDetectorRef,
    private activatedRoute: ActivatedRoute
  ) {
    this.id = activatedRoute.snapshot.params.id
    this.currentMode = !this.id ? modesEnum.Creation : modesEnum.Edition;
   }

  ngOnInit() {
    if (this.id) {
      this.clientService.getById(+this.id).then(res => {
        this.client = res.body;
      }, err => console.error(err))
    }
  }

  saveClient() {
    if (this.currentMode == modesEnum.Creation) {
      this.clientService.Add(this.client).then(res => {
        this.toastr.success("El cliente se guardó satisfactoriamente")
        this.router.navigate(["clientes"])
      }, err => console.error(err))
    }
    if (this.currentMode == modesEnum.Edition) {
      this.clientService.Modify(this.client).then(res => {
        this.toastr.success("El cliente se modificó satisfactoriamente")
        this.router.navigate(["clientes"])
      }, err => console.error(err))
    }
  }
}

export enum modesEnum {
  Creation,
  Edition
}