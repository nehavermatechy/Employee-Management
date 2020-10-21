import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {

  @Input() public employee: {
    name: string,
    employeeId: string
};

@Output() onClickList = new EventEmitter();
  constructor() { }

  ngOnInit() {
  }

  onClick = () =>{
    this.onClickList.emit(this.employee.employeeId);
  }

  

}
