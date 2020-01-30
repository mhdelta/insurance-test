import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AdminLayoutRoutes } from './admin-layout.routing';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {DxButtonModule, 
  DxSelectBoxModule, 
  DxDateBoxModule, 
  DxDropDownBoxModule,
  DxDataGridModule,
  DxPopupModule,
  DxTabsModule,
  DxTextBoxModule,
  DxTextAreaModule,
  DxNumberBoxModule,
  DxScrollViewModule,
  DxChartModule,
  DxBulletModule,
  DxAccordionModule,
  DxTemplateModule,
  DxCheckBoxModule} from 'devextreme-angular';
import  DataSource  from 'devextreme/data/data_source';
import { EditClientsComponent } from 'app/pages/clients/edit-clients/edit-clients.component';
import { ClientsComponent } from 'app/pages/clients/clients.component';
import { PolicyComponent } from 'app/pages/policy/policy.component';
import { EditPolicyComponent } from 'app/pages/policy/edit-policy/edit-policy.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    NgbModule,
    DxButtonModule,
    DxSelectBoxModule,
    DxDateBoxModule,
    DxDropDownBoxModule,
    DxDataGridModule,
    DxPopupModule,
    DxTabsModule,
    DxTextBoxModule,
    DxNumberBoxModule,
    DxTextAreaModule,
    DxScrollViewModule,
    DxChartModule,
    DxBulletModule,
    DxTemplateModule,
    DxAccordionModule,
    DxCheckBoxModule
  ],
  declarations: [
    ClientsComponent,
    EditClientsComponent,
    PolicyComponent,
    EditPolicyComponent
  ]
})

export class AdminLayoutModule {}
