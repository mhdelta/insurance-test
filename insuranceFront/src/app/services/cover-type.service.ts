import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'environments/environment';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class CoverTypeService {

  constructor(
    private http: HttpClient,
    private toastr: ToastrService
  ) { }

  public getAll() {
    try {
      return this.http.get(environment.baseApiUrl + "tiposCubrimientos", {
        observe: "response"
      }).toPromise();
    } catch (error) {
      this.toastr.error('Ocurrió un error al obtener los registros de tiposCubrimientos');
      console.log(error);
    }
  }

  public getById(id = 0) {
    try {
      if (id == 0) {
        throw new Error("No se envió el id")
      }
      return this.http.get(environment.baseApiUrl + "tiposCubrimientos/" + id, {
        observe: "response"
      }).toPromise();
    } catch (error) {
      this.toastr.error('Ocurrió un error al obtener el tipo de cubrimiento');
      console.log(error);
    }
  }


  public Add(tipoCubrimiento: any) {
    try {
      return this.http.post(environment.baseApiUrl + "tiposCubrimientos", JSON.stringify(tipoCubrimiento), {
        headers: { "Content-Type": "application/json" }
      }).toPromise();
    } catch (error) {
      this.toastr.error('Ocurrió un error al agregar un tipo cubrimiento');
      console.log(error);
    }
  }

  public Modify(tipoCubrimiento: any) {
    try {
      let id = tipoCubrimiento.id.toString();
      let params = new HttpParams();
      Object.keys(tipoCubrimiento).forEach(p => {
        if (tipoCubrimiento[p] != null) {
          params = params.append(p.toString(), tipoCubrimiento[p].toString());
        }
      });
      return this.http.put(environment.baseApiUrl + "tiposcubrimientos/" + tipoCubrimiento.id, {}, {
        headers: { "Content-Type": "application/json" },
        params: params
      }).toPromise();
    } catch (error) {
      this.toastr.error('Ocurrió un error al obtener los registros de tipos cubrimientos');
      console.log(error);
    }
  }
}