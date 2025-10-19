import { computed, effect, inject, Injectable, signal } from '@angular/core';
import { UserInfo, UserService } from '../core/helios-api-client';
import { Router } from '@angular/router';
import { firstValueFrom, Observable, switchMap, tap } from 'rxjs';
import { rxResource, toSignal } from '@angular/core/rxjs-interop';
import { initialEnd } from '@syncfusion/ej2-angular-schedule';


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

  private readonly userService = inject(UserService)
  private userinfo$ = rxResource({
    loader: () => this.userService.apiUserInfosGet()
  });
  isLoading = computed(() => this.userinfo$.isLoading() || this._isloginLoading() || this._islogoutLoading());

  userInfosloading = computed(() => this.userinfo$.isLoading());
  userinfo = computed(() => this.userinfo$.value());
  _islogoutLoading = signal(false);
  _isloginLoading = signal(false);
  _isLoggedOut = signal(true);
  private readonly state = computed(() => {
    const info = this.userinfo();
    const isLoading = this.userInfosloading();
    const isLogoutLoading = this._islogoutLoading();
    const isLoggedOut = this._isLoggedOut();
    const isLoginLoading = this._isloginLoading();
    if (isLoginLoading) return State.LoggingIn;
    if (isLoggedOut) return State.LoggedOut;
    console.log("User is logged in:", info, isLoading, isLogoutLoading, isLoggedOut);
    if (isLogoutLoading) return State.LoggingOut;
    if (isLoading) return State.LoggingIn;
    if (!info || !info.isConnected) return State.LoggedOut;

    return State.LoggedIn;
  });


  private readonly router = inject(Router);

  readonly isLoggedIn = computed(() => this.state() === State.LoggedIn);
  readonly isLoggingIn = computed(() => this.state() === State.LoggingIn);
  readonly isLoggingOut = computed(() => this.state() === State.LoggingOut);
  readonly isLoggedOut = computed(() => this.state() === State.LoggedOut);
  readonly isProcessing = computed(() => this.state() === State.LoggingIn || this.state() === State.LoggingOut);

  login(email: string, password: string): Observable<any> {
    this._isloginLoading.set(true);
    this._isLoggedOut.set(false);
    return this.userService.apiUserLoginPost({ email: email, password }).pipe(
      tap(() => {
        this._isloginLoading.set(false);
        this.userinfo$.reload();
      })
    );
  }


  logout(): Observable<any> {
    this._islogoutLoading.set(true);
    return this.userService.apiUserLogoutPost().pipe(
      tap(() => {
        this.userinfo$.reload();
        this._islogoutLoading.set(false);
        this._isLoggedOut.set(true);
      })
    );
  }








}
