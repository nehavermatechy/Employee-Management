import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared';
import { LoginRoutingModule } from './login-routing.module';

@NgModule({
  declarations: [LoginRoutingModule.components],
  imports: [SharedModule, LoginRoutingModule]
})
export class LoginModule {}
