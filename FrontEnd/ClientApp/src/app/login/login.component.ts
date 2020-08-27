import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { ILogin } from '../models/ILogin';
import { LoginService } from '../services/login.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  private model: any = {};
  private headers: HttpHeaders;
  private loginResult: any;
  private baseUrl: any;
  private errorMessage: string;
  private showErrors: boolean;
  

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private LoginService: LoginService) {
    this.baseUrl = baseUrl;
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  ngOnInit() {
    if (this.LoginService.ValidateLogin()) {
      this.router.navigate(['/home']);
    }
  }

  Login() {
    let User: ILogin = { UserName: this.model["userName"], Password: this.model["password"] };
    this.LoginService.Login(User, this.baseUrl).subscribe((data: any) => {
      debugger;
      if (data.state == 200) {
        sessionStorage.setItem('username', data.custom.username);
        sessionStorage.setItem('userId', data.custom.id);
        sessionStorage.setItem('permissions', JSON.stringify(data.custom.permissions));
        location.reload();
      } else {
        this.errorMessage = data.message;
        this.showErrors = true;
      }
    });
  }
}

