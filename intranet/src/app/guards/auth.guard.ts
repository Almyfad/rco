import { inject } from "@angular/core"
import { AuthService } from "../services/auth.service"
import { CanActivateFn, Router } from "@angular/router"
import { map, tap } from "rxjs";


export const authGuard: CanActivateFn = () => {
  const authService = inject(AuthService);
  const router = inject(Router);
  //TODO : Check module access
  var isConnected = authService.isLoggedIn();
  if (!isConnected) {
    router.navigate(['/authentication/login']);
  }
  return isConnected;
};