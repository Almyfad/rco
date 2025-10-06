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

  private readonly STORAGE_KEY = 'auth_isConnected';

  constructor() {
    effect(() => {
      const state = this.state();
      console.log("🔒 Auth state is ", State[state]);
      console.log("checking server connection state...");
      firstValueFrom(this.userService.apiUserInfosGet()).then(userInfo => {
        this._currentUser.set(userInfo);
        this.saveConnectionState(userInfo.isConnected || false);
        this.state.set(userInfo.isConnected ? State.LoggedIn : State.LoggedOut);
        
        if (state === State.LoggedOut) {
          this.router.navigate(['/authentication/login']);
        }
      });

    });
  }

  private readonly userService = inject(UserService)
  private readonly router = inject(Router);
  private readonly state = signal<State>(this.getStoredConnectionState() ? State.LoggedIn : State.LoggedOut);
  private readonly _currentUser = signal<UserInfo>({ isConnected: this.getStoredConnectionState() } as UserInfo);
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
        // Effacer l'état de connexion du localStorage lors de la déconnexion
        this.saveConnectionState(false);
      })
    );
  }

  /**
   * Sauvegarde l'état de connexion dans le localStorage
   */
  private saveConnectionState(isConnected: boolean): void {
    try {
      localStorage.setItem(this.STORAGE_KEY, JSON.stringify(isConnected));
    } catch (error) {
      console.warn('Impossible de sauvegarder l\'état de connexion dans le localStorage:', error);
    }
  }

  /**
   * Récupère l'état de connexion depuis le localStorage
   */
  private getStoredConnectionState(): boolean {
    try {
      const stored = localStorage.getItem(this.STORAGE_KEY);
      return stored ? JSON.parse(stored) : false;
    } catch (error) {
      console.warn('Impossible de récupérer l\'état de connexion depuis le localStorage:', error);
      return false;
    }
  }






}
