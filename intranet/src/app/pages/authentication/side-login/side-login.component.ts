import { Component, effect, inject, OnInit, signal } from '@angular/core';
import { CoreService } from 'src/app/services/core.service';
import {
  FormGroup,
  FormControl,
  Validators,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { MaterialModule } from '../../../material.module';
import { BrandingComponent } from '../../../layouts/full/vertical/sidebar/branding.component';
import { AuthService } from 'src/app/services/auth.service';
import { set } from 'date-fns';

@Component({
  selector: 'app-side-login',
  standalone: true,
  imports: [RouterModule, MaterialModule, FormsModule, ReactiveFormsModule, BrandingComponent],
  templateUrl: './side-login.component.html',
})
export class AppSideLoginComponent {
  options = this.settings.getOptions();
  isloading = signal(false);

  constructor(private settings: CoreService, private router: Router) {
    effect(() => {
      const isLoading = this.authService.isLoggingIn();
      this.isloading.set(isLoading);
      const isLoggedIn = this.authService.isLoggedIn();
      if (isLoggedIn) {
        this.router.navigate(['/']);
        return;

      }
    });
  }

  private readonly authService = inject(AuthService);



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
