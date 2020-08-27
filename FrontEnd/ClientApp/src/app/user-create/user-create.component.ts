import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service';
import { UserService } from '../services/user.service';
import { RoleService } from '../services/role.service';
import { IUser } from '../models/IUser';
declare var $;

@Component({
  selector: 'app-user-create',
  templateUrl: './user-create.component.html'
})
export class UserCreateComponent {
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
      this.GetRoles();
    } else {
      this.router.navigate(['/']);
    }
  }


  GetRoles() {
    this.RoleService.GetAll(this.baseUrl).subscribe((data: any) => {
      debugger;
      if (data.state == 200) {
        this.roles = data.custom;
        this.model.rolesId = 1;
      } else {
        this.errorMessage = data.message;
        this.showErrors = true;
      }
    });
  }

  CheckCreate() {
    debugger;
    let userModel: IUser = {
      Username: this.model["username"],
      Password: this.model["password"],
      Fullname: this.model["fullname"],
      Address: this.model["address"],
      Phone: this.model["phone"],
      Email: this.model["email"],
      Age: Number(this.model["age"]),
      RolesId: Number(this.model["rolesId"])
    };
    return userModel;
  }

  onCreateUser(idUser) {
    debugger;
    let userModel = this.CheckCreate();
    debugger;
    this.UserService.Post(userModel, this.baseUrl).subscribe((data: any) => {
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

