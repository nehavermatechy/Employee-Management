import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { of, Subject } from 'rxjs';
import { finalize, takeUntil } from 'rxjs/operators';

import { AccountService } from 'src/app/core';
import { BaseComponent, Page } from 'src/app/shared';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent extends BaseComponent implements OnInit, OnDestroy {
  private unsubscribe$ = new Subject<void>();

  constructor(
    private formBuilder: FormBuilder,
    protected router: Router,
    private accountService: AccountService,
    private toastr: ToastrService
  ) {
    super();
    this.createForm();
  }

  private createForm(): FormGroup {
    this.form = this.formBuilder.group({
      email: ['', Validators.compose([Validators.required, Validators.email])],
      password: ['', Validators.required],
    });

    return this.form;
  }

  ngOnInit() {}

  onSubmit() {
    this.isFormSubmit = true;
    if (this.form.valid) {
      const observable = of('').pipe();
      observable.pipe(takeUntil(this.unsubscribe$)).subscribe(() => {
        const { email, password } = this.form.value;
        this.accountService
          .login(email, password)
          .pipe(finalize(() => {}))
          .subscribe((user) => {
            if (user) {
              this.navigate(Page.dashboard);
              this.toastr.success("Login Successfull!");
            } else {
              this.toastr.error("Login Failed!", "Invalid Credentials");
            }
          });
      });
    }
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
