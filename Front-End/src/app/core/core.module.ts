import { NgModule, Optional, SkipSelf } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AccountService } from './services/account.service';
import { EmployeeService } from './services/employee.service';
import { AuthInterceptor } from './interceptors';


@NgModule({
  imports: [CommonModule, HttpClientModule, RouterModule],
  exports: [CommonModule, HttpClientModule, RouterModule],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
    AccountService, EmployeeService],
  declarations: []
})
export class CoreModule {
  // Ensure that CoreModule is only loaded into AppModule
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    // Looks for the module in the parent injector to see if it's already been loaded (only want it loaded once)
    if (parentModule) {
      throw new Error(
        'CoreModule is already loaded. Import it in the AppModule only'
      );
    }
  }
}
