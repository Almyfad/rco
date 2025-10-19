import { inject } from "@angular/core"
import { AuthService } from "../services/auth.service"
import { CanActivateFn, Router } from "@angular/router"


export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);
  //TODO : Check module access
  var isConnected = authService.isLoggedIn();
  if (!isConnected) {
    console.log("User not connected, redirect to login page");
    router.navigate(['/authentication/login'], { 
      queryParams: { returnUrl: state.url } 
    });
  }
  return isConnected;
};