import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PageNotFoundComponent } from '../app/shared/components';
import { AccountLayoutComponent } from '../app/layouts';

import { DashboardComponent, LoginComponent } from '../app/components';
import { Page } from '../app/shared';
import { AuthGuard } from './core/guards';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/dashboard' },
  { path: 'login', component: LoginComponent },
  {
    path: '',
    component: AccountLayoutComponent,
    data: { shouldAuthorized: true },
    canActivate: [AuthGuard],
    children: [
      {
        canActivateChild: [AuthGuard],
        data: { shouldAuthorized: true},
        path: Page.dashboard,
        component: DashboardComponent,
      },
      {
        canActivateChild: [AuthGuard],
        path: Page.employee,
        data: {
          preload: true,
          // roles: [Role.SuperAdmin],
          title: 'Employee',
        },
        loadChildren: () =>
          import('./components/employee/employee.module').then(
            (mod) => mod.EmployeeModule
          ),
      }
    ],
  },
  { path: '**', component: PageNotFoundComponent },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      // preloadingStrategy: PreloadModuleStrategy
      //enableTracing: true
    }),
  ],
  exports: [RouterModule],
  // providers: [PreloadModuleStrategy]
})
export class AppRoutingModule {}
