import { Component, effect, inject, OnInit, signal } from '@angular/core';
import { CoreService } from 'src/app/services/core.service';
import {
  FormGroup,
  FormControl,
  Validators,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { MaterialModule } from '../../../material.module';
import { BrandingComponent } from '../../../layouts/full/vertical/sidebar/branding.component';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-side-login',
  standalone: true,
  imports: [RouterModule, MaterialModule, FormsModule, ReactiveFormsModule, BrandingComponent],
  templateUrl: './side-login.component.html',
})
export class AppSideLoginComponent {
  private readonly settings = inject(CoreService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);
  private readonly authService = inject(AuthService);
  private readonly returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  options = this.settings.getOptions();
  get isLoading() {
    return this.authService.isLoading();
  }
  constructor() {
    effect(() => {
      const isLoggedIn = this.authService.isLoggedIn();
      if (isLoggedIn) {
        this.router.navigate([this.returnUrl]);
        return;
      }
    });
  }


  form = new FormGroup({
    uname: new FormControl('', [Validators.required, Validators.minLength(6)]),
    password: new FormControl('', [Validators.required]),
  });

  get f() {
    return this.form.controls;
  }

  submit() {
    if (this.form.invalid) return;
    this.authService.login(this.f.uname!.value!, this.f.password!.value!).subscribe({
      next: (response) => {
      },
      error: (error) => {
        console.error('Login failed', error);
      }
    });
  }
}
