import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared';
import { EmployeeRoutingModule } from './employee-routing.module';

@NgModule({
  imports: [SharedModule, EmployeeRoutingModule],
  declarations: [EmployeeRoutingModule.components]
})
export class EmployeeModule {}
