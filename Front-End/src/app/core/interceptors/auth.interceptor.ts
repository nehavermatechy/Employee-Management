import { Injectable } from '@angular/core';
import {
  HttpEvent,
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
  HttpErrorResponse,
  HttpResponse,
  HttpClient,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, finalize, tap } from 'rxjs/operators';
import { Router } from '@angular/router';

import { HttpStatus } from 'src/app/shared/enums/http-status';
import { Page } from 'src/app/shared';
import { AccountService } from '../services/account.service';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(
    private accountService: AccountService,
    private router: Router,
    private http: HttpClient,
    private toastr: ToastrService
  ) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const authRequest = this.addAuthToken(request);
    return next.handle(authRequest).pipe(
      tap((event: HttpEvent<any>) => {
        return event;
      }),
      catchError((error: HttpErrorResponse) => {
        let errorMessage = 'An error occurred';
        const isUnAuthorizedRequest =
          error.status === HttpStatus.UnAuthorized ||
          error.status === HttpStatus.Forbidden;

        if (isUnAuthorizedRequest) {
          this.router.navigate([Page.login]);
          this.accountService.logout();
        }

        if (error.error instanceof ErrorEvent) {
          errorMessage = `Error: ${error.error.message}`;
        }

        if (error.status !== HttpStatus.StatusZero) {
          if (error.error) {
            if (error.error.message) {
              errorMessage = error.error.message;
            } else {
              errorMessage = error.error.detail;
            }
          } else {
            errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
          }
        }

        if (!isUnAuthorizedRequest) {
          this.toastr.error(errorMessage, error.statusText);
        }
      
        return throwError(errorMessage);
      })
    );
  }

private addAuthToken(request: HttpRequest<any>) {
    const currentUser = this.accountService.loggedInUserInfo;
    const token = currentUser ? currentUser.userToken : '';

    const authRequest = request.clone({
      headers: request.headers
        .set('Authorization', `Bearer ${token}`)
        .set('X-Requested-With', 'XMLHttpRequest')
        .set('X-Requested-From', 'XHRClient')
    });

    return authRequest;
  }
}
