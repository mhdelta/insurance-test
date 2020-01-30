import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'environments/environment';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class PolicyService {

  constructor(
    private http: HttpClient,
    private toastr: ToastrService
  ) { }

  public getAll() {
    try {
      return this.http.get(environment.baseApiUrl + "polizas", {
        observe: "response"
      }).toPromise();
    } catch (error) {
      this.toastr.error('Ocurrió un error al obtener los registros de polizas');
      console.log(error);
    }
  }

  public getById(id = 0) {
    try {
      if (id == 0) {
        throw new Error("No se envió el id")
      }
      return this.http.get(environment.baseApiUrl + "polizas/" + id, {
        observe: "response"
      }).toPromise();
    } catch (error) {
      this.toastr.error('Ocurrió un error al obtener la poliza');
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
}