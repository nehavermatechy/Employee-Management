import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { GridModule } from '@progress/kendo-angular-grid';
import { DialogsModule } from '@progress/kendo-angular-dialog';
import { ListViewModule } from '@progress/kendo-angular-listview';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';

import {
  BaseComponent,
  FieldErrorComponent,
  EmployeeListComponent,
} from './components';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    ReactiveFormsModule,
    GridModule,
    DialogsModule,
    ListViewModule,
    InputsModule,
    ToastrModule.forRoot({
      progressBar: true,
      positionClass: 'toast-bottom-right',
    }),
    NgxSpinnerModule,
  ],

  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    GridModule,
    DialogsModule,
    ListViewModule,
    InputsModule,
    ToastrModule,
    NgxSpinnerModule,

    BaseComponent,
    FieldErrorComponent,
    EmployeeListComponent,
  ],
  declarations: [BaseComponent, FieldErrorComponent, EmployeeListComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class SharedModule {}
