import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'environments/environment';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';

@Injectable()
export class AuthService {
  
  constructor(
    private http: HttpClient,
    private toastr: ToastrService,
    ) { }
      
    IsLogged() {
      return localStorage.getItem("insuranceToken") != null;
    }

  IsAuthenticated() {
    return this.http.get(
      environment.baseApiUrl + "auth",{
      withCredentials: true,
      headers: 
        { "Content-Type": "application/json", 'Access-Control-Allow-Credentials': 'true',
      "Authorization": "Bearer " + localStorage.getItem("insuranceToken")}
      }
      ).toPromise();
    // return new Promise((resolve, reject) => { 
    //   if (localStorage.getItem('InsuranceTestCookie')) {
    //      resolve()
    //   } else {
    //     reject()
    //   }
    // })
  }

  Authenticate() {
    let user = {
      Id: 0,
      Name: "test"
    }
    return this.http.post(environment.baseApiUrl + "auth/authenticate", JSON.stringify(user), {
      observe: "response",
      withCredentials: true,
      headers: { "Content-Type": "application/json", 'Access-Control-Allow-Credentials': 'true' }
    }).toPromise();
  }
  
}