import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { ILogin } from '../models/ILogin';
import { LoginService } from '../services/login.service';
import { UserService } from '../services/user.service';
declare var $;

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html'
})
export class UserListComponent {
  private model: any = {};
  private headers: HttpHeaders;
  private loginResult: any;
  private baseUrl: any;
  private errorMessage: string;
  private showErrors: boolean;
  private dataTable: any;
  private users: any;
  private messageAlert: boolean;
  private messageNotification: string;
  private userEditPerms: string;
  private userDeletePerms: string;

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private LoginService: LoginService, private UserService: UserService) {
    this.baseUrl = baseUrl;
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
    this.GetAllUsers()
  }


  ngOnInit() {
    if (this.LoginService.ValidateLogin()) {
      this.dataTable = $('#dataTable');
      this.userEditPerms = sessionStorage.getItem('userEditPermission');
      this.userDeletePerms = sessionStorage.getItem('userDeletePermission');
    } else {
      this.router.navigate(['/']);
    }
    
  }

  onEditUser(idUser) {
    sessionStorage.setItem('idUserEdit', idUser);
    this.router.navigate(['/user-edit']);
  }

  onDeleteUser(idUser) {
    debugger
    this.messageAlert = true
    sessionStorage.setItem('idUserDelete', idUser);
    this.messageNotification = "Debe elegir un usuario para editar, debe ir a la página de lista de usuarios";
    $("#messageNotification").show();
  }

  AcceptDelete() {
    debugger;
    var userId = sessionStorage.getItem('idUserDelete');
    this.messageAlert = false;
    this.UserService.Delete(userId, this.baseUrl).subscribe((resp: any) => {
      location.reload();
    });
    
  }

  CancelDelete() {
    sessionStorage.removeItem('idUserDelete');
    this.messageAlert = false;
  }

  GetAllUsers() {
    this.UserService.GetAll(this.baseUrl).subscribe((data: any) => {
      debugger;
      if (data.state == 200) {
        this.users = data.custom;
      } else {
        this.errorMessage = data.message;
        this.showErrors = true;
      }
    });
  }
}

