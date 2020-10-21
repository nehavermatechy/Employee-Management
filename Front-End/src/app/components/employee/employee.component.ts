import {
  AfterContentChecked,
  AfterViewChecked,
  AfterViewInit,
  Component,
  DoCheck,
  OnChanges,
  OnInit,
} from '@angular/core';
import { AccountService } from 'src/app/core';
import { EmployeeService } from 'src/app/core/services/employee.service';

import { employees } from '../../shared/constants/employees';

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
  constructor(
    private employeeService: EmployeeService,
    private accountService: AccountService) {}

  ngOnInit() {
    this.getEmployees();
  }

  openEmployeeDetailModalPopup = (employeeId) => {
    this.selectedEmployee = this.employees.find(x => x.employeeId === employeeId);
    this.isModalOpened = true;
  };

  closeModalPopup = () => {
    this.isModalOpened = false;
  };

  getEmployees = () => {
    this.employeeService.getEmployees().subscribe((resp: any) => {
      const {employeeId} = this.accountService.loggedInUserInfo;
      this.employees = resp.filter(x => x.employeeId !== parseInt(employeeId));
      this.employeesFilterationData = this.employees;
    });
  };

  public handleFilterChange(query: string): void {
    const normalizedQuery = query.toLowerCase();
    const filterExpession = item =>
        item.name.toLowerCase().indexOf(normalizedQuery) !== -1

    this.employees = JSON.parse(JSON.stringify(this.employeesFilterationData.filter(filterExpession)));
}

}
