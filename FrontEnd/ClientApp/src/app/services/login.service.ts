import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ILogin } from '../models/ILogin';

@Injectable({
    providedIn: 'root'
})

export class LoginService {
   private headers: HttpHeaders;

    constructor(private http: HttpClient) {
        this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });

    }
    
    public Login(login: ILogin, apiUrl : string) {
      return this.http.post(apiUrl + 'api/login/newlogin', login, { headers: this.headers });
     
    }
    public ValidateLogin() {
      var userId = sessionStorage.getItem('userId');
      if (userId != null) {
        return true;
      } else {
        return false;
      }
    }
}
