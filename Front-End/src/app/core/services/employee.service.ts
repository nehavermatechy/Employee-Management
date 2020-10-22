import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { apiEndPoint, url } from '../../shared/constants';
import { Router } from '@angular/router';
import { AccountService } from './account.service';

@Injectable()
export class EmployeeService {

  constructor(private http: HttpClient, private router: Router, private accountService: AccountService) {  }
  
  getEmployees = () => {
    return this.http.get(`${apiEndPoint}${url.getEmployees}`)
  }
}
