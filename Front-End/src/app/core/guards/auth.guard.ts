import { Injectable } from '@angular/core';
import {
  CanActivate,
  Router,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  CanActivateChild
} from '@angular/router';

import { AccountService } from '../services/account.service';
import { Page } from '../../shared/constants';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate, CanActivateChild {
  constructor(private accountService: AccountService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    return this.checkLogin(state.url, route.data);
  }

  canActivateChild(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    return this.checkLogin(state.url, route.data);
  }

  checkLogin(url: string, routeData: any): boolean {
    if (!this.accountService.isUserLoggedIn) {
      this.redirectToLogin(url);
      return false;
    }
    else 
    {
      return true 
    }
  }

  private redirectToLogin(url: string) {
    this.accountService.redirectUrl = url;
    this.router.navigate([Page.login]);
  }

  private userHasPermissions(userRoles: string[], routeData: any) {
    return userRoles.some((userRole) => routeData.roles.indexOf(userRole) >= 0);
  }
}
