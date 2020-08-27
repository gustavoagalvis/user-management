import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service';
import { UserService } from '../services/user.service';
import { RoleService } from '../services/role.service';
import { IUser } from '../models/IUser';
declare var $;

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html'
})
export class UserEditComponent {
  private model: any = {};
  private headers: HttpHeaders;
  private baseUrl: any;
  private errorMessage: string;
  private showErrors: boolean;
  private user: any;
  private roles: any;
  private messageAlert: boolean;
  private messageNotification: string;
  private idUserEdit: string;

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private LoginService: LoginService, private UserService: UserService, private RoleService: RoleService) {
    this.baseUrl = baseUrl;
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
    
  }

  
  ngOnInit() {
    if (this.LoginService.ValidateLogin()) {
      var idUser = sessionStorage.getItem('idUserEdit');
      this.idUserEdit = idUser;
      if (idUser != null) {
        this.GetInfoUser(idUser);
      } else {
        this.showErrors = true
        this.errorMessage = "Debe elegir un usuario para editar, debe ir a la página de lista de usuarios";
        $("#errorMessage").show();
      }
    } else {
      this.router.navigate(['/']);
    }
  }


  GetInfoUser(idUser) {
    this.UserService.GetUser(idUser, this.baseUrl).subscribe((data: any) => {
      debugger;
      if (data.state == 200) {
        this.user = data.custom;
        this.model.rolesId = this.user.rolesId;
        this.GetRoles();
      } else {
        this.errorMessage = data.message;
        this.showErrors = true;
      }
    });
  }

  GetRoles() {
    this.RoleService.GetAll(this.baseUrl).subscribe((data: any) => {
      debugger;
      if (data.state == 200) {
        this.roles = data.custom;

      } else {
        this.errorMessage = data.message;
        this.showErrors = true;
      }
    });
  }

  CheckUpdates(idUser) {
    debugger;
    var idUserNum = Number(idUser);
    let userModel: IUser = {
      Id: idUserNum,
      Username: this.model["username"] != null ? this.model["username"] : this.user.username,
      Fullname: this.model["fullname"] != null ? this.model["fullname"] : this.user.fullname,
      Address: this.model["address"] != null ? this.model["address"] : this.user.address,
      Phone: this.model["phone"] != null ? this.model["phone"] : this.user.phone,
      Email: this.model["email"] != null ? this.model["email"] : this.user.email,
      Age: this.model["age"] != null ? Number(this.model["age"]) : Number(this.user.age),
      RolesId: this.model["rolesId"] != null ? Number(this.model["rolesId"]) : Number(this.user.rolesId)
    };
    return userModel;
  }

  onEditUser() {
    debugger;
    var idUser = sessionStorage.getItem('idUserEdit');
    let userModel = this.CheckUpdates(idUser);
    debugger;
    this.UserService.Put(idUser, userModel, this.baseUrl).subscribe((data: any) => {
      debugger;
      if (data.state == 200) {
        
        this.router.navigate(['/user-list']);
      } else {
        this.errorMessage = data.message;
        this.showErrors = true;
      }
    });
  }
}

