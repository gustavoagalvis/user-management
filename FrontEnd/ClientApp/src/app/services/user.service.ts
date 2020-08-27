import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IUser } from '../models/IUser';

@Injectable({
    providedIn: 'root'
})

export class UserService {
   private headers: HttpHeaders;

    constructor(private http: HttpClient) {
        this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
    }
    
    public GetAll(apiUrl : string) {
      return this.http.get(apiUrl + 'api/user/get');
     
  }

    public GetUser(userId, apiUrl: string) {
      debugger;
      return this.http.get(apiUrl + 'api/user/get/' + userId);

    }
    public Delete(userId, apiUrl: string) {
      debugger;
      return this.http.delete(apiUrl + 'api/user/delete/' + userId);

    }

    public Put(userId, user: IUser, apiUrl: string) {
      debugger;
      var url = apiUrl + 'api/user/put/' + userId;
      return this.http.put(url, user, { headers: this.headers });
    }


    public Post(user: IUser, apiUrl: string) {
      debugger;
      var url = apiUrl + 'api/user/post';
      return this.http.post(url, user, { headers: this.headers });
    }
}
