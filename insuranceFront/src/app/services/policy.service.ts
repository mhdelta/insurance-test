import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'environments/environment';
import { ToastrService } from 'ngx-toastr';
import { Policy } from 'app/models/policy.model';

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
      return this.http.get<Policy>(environment.baseApiUrl + "polizas/" + id, {
        observe: "response"
      }).toPromise();
    } catch (error) {
      this.toastr.error('Ocurrió un error al obtener la poliza');
      console.log(error);
    }
  }


  public Add(policy: any) {
    try {
      return this.http.post(environment.baseApiUrl + "polizas", JSON.stringify(policy), {
        headers: { "Content-Type": "application/json" }
      }).toPromise();
    } catch (error) {
      this.toastr.error('Ocurrió un error al agregar una poliza');
      console.log(error);
    }
  }

  public Modify(poliza: any) {
    try {
      let params = new HttpParams();
      Object.keys(poliza).forEach(p => {
        if (poliza[p] != null) {
          params = params.append(p.toString(), poliza[p].toString());
        }
      });
      return this.http.put(environment.baseApiUrl + "polizas/" + poliza.id, {}, {
        headers: { "Content-Type": "application/json" },
        params: params
      }).toPromise();
    } catch (error) {
      this.toastr.error('Ocurrió un error al modificar la poliza');
      console.log(error);
    }
  }

  public remove(id = 0) {
    try {
      if (id == 0) {
        throw new Error("No se envió el id")
      }
      return this.http.delete(environment.baseApiUrl + "polizas/" + id, {
        observe: "response"
      }).toPromise();
    } catch (error) {
      this.toastr.error('Ocurrió un error al eliminar la poliza');
      console.log(error);
    }
  }
}