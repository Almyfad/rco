import { computed, effect, inject, Injectable, signal } from '@angular/core';
import { UserInfo, UserService } from '../core/helios-api-client';
import { Router } from '@angular/router';
import { firstValueFrom, Observable, switchMap, tap } from 'rxjs';
import { toSignal } from '@angular/core/rxjs-interop';


enum State {
  LoggedOut,
  LoggingIn,
  LoggedIn,
  LoggingOut
}
@Injectable({
  providedIn: 'root'
})
export class AuthService {


  constructor() {
    effect(() => {
      const state = this.state();
      console.log("Auth state changed to", State[state]);

      this._currentUser.set({ isConnected: state === State.LoggedIn } as UserInfo);

      firstValueFrom(this.userService.apiUserInfosGet()).then(userInfo => {
        this._currentUser.set(userInfo);
      });
    });
  }

  private readonly userService = inject(UserService)
  private readonly router = inject(Router);
  private readonly state = signal<State>(State.LoggedOut);
  private readonly _currentUser = signal<UserInfo>({ isConnected: false } as UserInfo);
  readonly currentUser = computed(() => this._currentUser());
  readonly isLoggedIn = computed(() => this._currentUser().isConnected || false);
  readonly isLoggingIn = computed(() => this.state() === State.LoggingIn);
  readonly isLoggingOut = computed(() => this.state() === State.LoggingOut);
  readonly isLoggedOut = computed(() => this.state() === State.LoggedOut);
  readonly isProcessing = computed(() => this.state() === State.LoggingIn || this.state() === State.LoggingOut);

  login(email: string, password: string): Observable<any> {
    this.state.set(State.LoggingIn);
    return this.userService.apiUserLoginPost({ email: email, password }).pipe(
      tap(() => {
        this.state.set(State.LoggedIn);
      })
    );
  }


  logout(): Observable<any> {
    this.state.set(State.LoggingOut);
    return this.userService.apiUserLogoutPost().pipe(
      tap(() => {
        this.state.set(State.LoggedOut);
      })
    );
  }






}
