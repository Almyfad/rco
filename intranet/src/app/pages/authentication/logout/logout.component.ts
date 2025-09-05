import { Component, effect, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import {  MatProgressSpinnerModule } from "@angular/material/progress-spinner";

@Component({
  selector: 'app-logout',
  imports: [MatProgressSpinnerModule],
  templateUrl: './logout.component.html',
  styleUrl: './logout.component.scss'
})
export class LogoutComponent implements OnInit {
  private readonly authService = inject(AuthService);
private readonly router = inject(Router);
  constructor() {
    effect(() => {
      const isLoggedOut = this.authService.isLoggedOut();
      if(isLoggedOut) {
        setTimeout(() => {
          this.router.navigate(['/authentication/login']);
        }, 1000);
      }
    });

  }

  loggingOut = this.authService.isLoggingOut;
  loggedOut = this.authService.isLoggedOut;
  ngOnInit(): void {
    this.authService.logout().subscribe();
  }

}
