import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'environments/environment';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ClientsService {
  

  constructor(
    private http: HttpClient,
    private toastr: ToastrService
  ) { }

  public GetAll() {
    try {
      return this.http.get(environment.baseApiUrl + "clientes", {
        observe: "response"
      }).toPromise();
    } catch (error) {
      this.toastr.error('Ocurrió un error al obtener los registros de clientes');
      console.log(error);
    }
  }

  public GetAssigned() {
    try {
      return this.http.get(environment.baseApiUrl + "clientes/asignados", {
        observe: "response"
      }).toPromise();
    } catch (error) {
      this.toastr.error('Ocurrió un error al obtener los registros de clientes');
      console.log(error);
    }
  }

  public GetById(id = 0) {
    try {
      if (id == 0) {
        throw new Error("No se envió el id")
      }
      return this.http.get(environment.baseApiUrl + "clientes/" + id, {
        observe: "response"
      }).toPromise();
    } catch (error) {
      this.toastr.error('Ocurrió un error al obtener el cliente');
      console.log(error);
    }
  }


  public Add(client: any) {
    try {
      return this.http.post(environment.baseApiUrl + "clientes", JSON.stringify(client), {
        headers: { "Content-Type": "application/json" }
      }).toPromise();
    } catch (error) {
      this.toastr.error('Ocurrió un error al agregar un cliente');
      console.log(error);
    }
  }

  public Assign(newAssign: {idCliente: number, idPoliza: number}) {
    try {
      return this.http.post(environment.baseApiUrl + "polizasclientes", JSON.stringify(newAssign), {
        headers: { "Content-Type": "application/json" }
      }).toPromise();
    } catch (error) {
      this.toastr.error('Ocurrió un error al asignar la poliza');
      console.log(error);
    }
  }

  public Modify(client: any) {
    try {
      let id = client.id.toString();
      let params = new HttpParams();
      Object.keys(client).forEach(p => {
        if (client[p] != null) {
          params = params.append(p.toString(), client[p].toString());
        }
      });
      return this.http.put(environment.baseApiUrl + "clientes/" + client.id, {}, {
        headers: { "Content-Type": "application/json" },
        params: params
      }).toPromise();
    } catch (error) {
      this.toastr.error('Ocurrió un error al obtener los registros de pbc');
      console.log(error);
    }
  }

  public RemoveAssignation(idCliente: number, idPoliza: number) {
    try {
      if (idCliente == 0 || idPoliza == 0) {
        throw new Error("No se envió el id")
      }
      return this.http.delete(environment.baseApiUrl + "polizasclientes", {
        params: new HttpParams()
        .append("idCliente", idCliente.toString())
        .append("idPoliza", idPoliza.toString())
      }).toPromise();
    } catch (error) {
      this.toastr.error('Ocurrió un error al eliminar la asignación');
      console.log(error);
    }
  }
}