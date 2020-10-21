import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

import { apiEndPoint, url, commonConstant, Page } from '../../shared/constants';
import { User } from '../../shared/models';
import { Router } from '@angular/router';

@Injectable()
export class AccountService {
  private loggedInUserSubject: BehaviorSubject<any>;
  public loggedInUserObservable$: Observable<User>;
  redirectUrl: string;
  jwtHelper: JwtHelperService;

  constructor(private http: HttpClient, private router: Router) {
    this.jwtHelper = new JwtHelperService();
    const userInfoToken = JSON.parse(
      localStorage.getItem(commonConstant.tokenContainer)
    );
    this.init(userInfoToken);
  }

  init(userInfoToken: string) {
    if (userInfoToken) {
      const userData = this.getUserInfo(userInfoToken);
      this.loggedInUserSubject = new BehaviorSubject<User>(userData);
      this.loggedInUserObservable$ = this.loggedInUserSubject.asObservable();
    } else {
      this.loggedInUserSubject = new BehaviorSubject<User>(null);
      this.loggedInUserObservable$ = this.loggedInUserSubject.asObservable();
    }
  }

  public get loggedInUserInfo() {
    return this.loggedInUserSubject.value;
  }

  public get isUserLoggedIn(): boolean {
    return !!this.loggedInUserSubject.value;
  }

  login(email, password): Observable<any> {
    const params = new HttpParams()
      .set('email', email)
      .set('password', password);

    return this.http.get(`${apiEndPoint}${url.login}`, { params, responseType:'text' }).pipe(
      map((userToken) => {
        if (userToken) {
          localStorage.setItem(
            commonConstant.tokenContainer,
            JSON.stringify(userToken)
          );
          const userData = this.getUserInfo(userToken);
          this.loggedInUserSubject.next(userData);
          return userToken;
        } else {
          return false;
        }
      })
    );
  }

  logout() {
    localStorage.removeItem(commonConstant.tokenContainer);
    this.loggedInUserSubject.next(null);
    this.router.navigate([Page.login]);
  }

  getUserInfo(userToken) {
    const userInfo = this.jwtHelper.decodeToken(userToken);
    const {
      employeeId,
      name,
      email,
      phoneNumber,
      designation,
      supervisorId,
      role,
      address
    } = userInfo;
    const loggedInUser = {
      employeeId,
      name,
      email,
      phoneNumber,
      designation,
      supervisorId,
      role,
      address,
      userToken
    };
    return loggedInUser;
  }

}
