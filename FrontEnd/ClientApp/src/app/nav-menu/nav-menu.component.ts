import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  private permissionsSession: any;
  private usernameSession: any;
  constructor(private router: Router) {
  }

  ngOnInit() {
    debugger;
    var permissionsStorage = sessionStorage.getItem('permissions');
    if (typeof permissionsStorage !== "undefined" && permissionsStorage != null) {
      this.permissionsSession = JSON.parse(permissionsStorage);
      this.SaveSessionPermission();
    }
    this.usernameSession = sessionStorage.getItem('username');
    
  }
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  onDestroySession() {
    sessionStorage.clear();
    location.reload();
  }


  SaveSessionPermission() {
    debugger;
    for (let x in this.permissionsSession) {
      switch (this.permissionsSession[x].name) {
        case "user_edit": {
          sessionStorage.setItem('userEditPermission', "true");
          break;
        }
        case "user_delete": {
          sessionStorage.setItem('userDeletePermission', "true");
          break;
        }
      }
    }
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
