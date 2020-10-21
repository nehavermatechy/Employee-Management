import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {

  constructor(public accountService: AccountService) {}

  public get loggedInUser()
  {
    return this.accountService.loggedInUserInfo;
  }
  ngOnInit() {}
}
