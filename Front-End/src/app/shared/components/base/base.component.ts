import { Component, OnInit } from '@angular/core';
import { FormGroup, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-base',
  template: ''
})
export class BaseComponent implements OnInit {
  public form: FormGroup;
  public isFormSubmit = false;
  public isProcessRunning = false;

  constructor(protected router?: Router) {}

  ngOnInit() {}

  get isFormValid(): boolean {
    return this.form.valid;
  }

  hasError(control: string, errorType: string): boolean {
    const currentControl = this.form.get(control);
    return (
      ((currentControl.dirty || currentControl.touched) && currentControl.hasError(errorType)) ||
      ((currentControl.pristine || currentControl.untouched) &&
        this.isFormSubmit &&
        currentControl.hasError(errorType))
    );
  }

  hasNestedFormError(nestedForm: FormGroup | AbstractControl, control: string, errorType: string): boolean {
    const currentControl = nestedForm.get(control);
    return (
      ((currentControl.dirty || currentControl.touched) && currentControl.hasError(errorType)) ||
      ((currentControl.pristine || currentControl.untouched) &&
        this.isFormSubmit &&
        currentControl.hasError(errorType))
    );
  }

  getControlValue(control: string) {
    return this.form.get(control).value;
  }

  getNestedFormControlValue(nestedForm: FormGroup, control: string) {
    return nestedForm.get(control).value;
  }

  disableField(field: string) {
    this.form.get(field).disable();
  }

  disableNestedField(nestedForm: FormGroup, field: string) {
    nestedForm.get(field).disable();
  }

  enableField(field: string) {
    this.form.get(field).enable();
  }

  enableNestedField(nestedForm: FormGroup, field: string) {
    nestedForm.get(field).enable();
  }

  clearFieldsValidators(fields: string[]) {
    for (const field of fields) {
      this.form.controls[field].clearValidators();
      this.form.controls[field].updateValueAndValidity();
    }
  }

  addFieldValidator(fields: string, validators: []) {
    for (const field of fields) {
      this.form.controls[field].setValidators(validators);
      this.form.controls[field].updateValueAndValidity();
    }
  }

  navigateByUrl(routeUrl: string) {
    this.router.navigateByUrl(`/${routeUrl}`);
  }

  navigate(routeName: string, params?: any) {
    const parameters = params ? params : {};
    this.router.navigate([`/${routeName}`, parameters]);
  }
}
