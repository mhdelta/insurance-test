import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'environments/environment';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class RiskTypeService {

  constructor(
    private http: HttpClient,
    private toastr: ToastrService
  ) { }

  public getAll() {
    try {
      return this.http.get(environment.baseApiUrl + "tiposriesgos", {
        observe: "response"
      }).toPromise();
    } catch (error) {
      this.toastr.error('Ocurrió un error al obtener los registros de tipos riesgos');
      console.log(error);
    }
  }

  public getById(id = 0) {
    try {
      if (id == 0) {
        throw new Error("No se envió el id")
      }
      return this.http.get(environment.baseApiUrl + "tiposriesgos/" + id, {
        observe: "response"
      }).toPromise();
    } catch (error) {
      this.toastr.error('Ocurrió un error al obtener el tipo de riesgo');
      console.log(error);
    }
  }


  public Add(tipoRiesgo: any) {
    try {
      return this.http.post(environment.baseApiUrl + "tiposriesgos", JSON.stringify(tipoRiesgo), {
        headers: { "Content-Type": "application/json" }
      }).toPromise();
    } catch (error) {
      this.toastr.error('Ocurrió un error al agregar un tiposriesgos');
      console.log(error);
    }
  }

  public Modify(tipoRiesgo: any) {
    try {
      let id = tipoRiesgo.id.toString();
      let params = new HttpParams();
      Object.keys(tipoRiesgo).forEach(p => {
        if (tipoRiesgo[p] != null) {
          params = params.append(p.toString(), tipoRiesgo[p].toString());
        }
      });
      return this.http.put(environment.baseApiUrl + "tiposriesgos/" + tipoRiesgo.id, {}, {
        headers: { "Content-Type": "application/json" },
        params: params
      }).toPromise();
    } catch (error) {
      this.toastr.error('Ocurrió un error al modificar los tipos de resgos');
      console.log(error);
    }
  }
}