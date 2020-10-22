import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

import { PagerSettings } from '@progress/kendo-angular-grid';
import { AccountService } from 'src/app/core';
import { EmployeeService } from 'src/app/core/services/employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss'],
})
export class EmployeeComponent implements OnInit {
  employees: any[];
  employeesFilterationData: any[];
  isModalOpened = false;
  selectedEmployee;
  public pagerSettings: PagerSettings = {
    previousNext: false,
    buttonCount: 9,
  };
  public pageSize = 6;
  constructor(
    private employeeService: EmployeeService,
    private accountService: AccountService,
    private spinner: NgxSpinnerService
  ) {}

  ngOnInit() {
    this.getEmployees();
  }

  openEmployeeDetailModalPopup = (id) => {
    this.selectedEmployee = this.employees.find((x) => x.id === id);
    this.isModalOpened = true;
  };

  closeModalPopup = () => {
    this.isModalOpened = false;
  };

  getEmployees = () => {
    this.spinner.show();
    this.employeeService.getEmployees().subscribe((resp: any) => {
      const { employeeId } = this.accountService.loggedInUserInfo;
      this.employees = resp.filter((x) => x.id !== parseInt(employeeId));
      this.employeesFilterationData = this.employees;
      this.spinner.hide();
    });
  };

  public handleFilterChange(query: string): void {
    const normalizedQuery = query.toLowerCase();
    const filterExpession = (item) =>
      item.name.toLowerCase().indexOf(normalizedQuery) !== -1;

    this.employees = JSON.parse(
      JSON.stringify(this.employeesFilterationData.filter(filterExpession))
    );
  }
}
