import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
})
export class NewsComponent {
  constructor(private router: Router, private LoginService: LoginService) {
  }

  ngOnInit() {
    if (this.LoginService.ValidateLogin()) {
    } else {
      this.router.navigate(['/']);
    }
  }
}



