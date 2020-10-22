import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from '../core';

@Component({
  selector: 'app-account-layout',
  templateUrl: './account-layout.component.html',
  styleUrls: ['./account-layout.component.scss'],
})
export class AccountLayoutComponent implements OnInit {
  isSidebarClosed: boolean = false;

  constructor(public router: Router, private accountService: AccountService) {}

  public get loggedInUser()
  {
    return this.accountService.loggedInUserInfo;
  }

  ngOnInit() {}

  onToggleSideBar = () => {
    this.isSidebarClosed = !this.isSidebarClosed;
  };

  onLogout = () => {
    this.accountService.logout();
  };
}
