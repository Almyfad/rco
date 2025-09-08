export * from './helios.service';
import { HeliosService } from './helios.service';
export * from './planning.service';
import { PlanningService } from './planning.service';
export * from './registre.service';
import { RegistreService } from './registre.service';
export * from './user.service';
import { UserService } from './user.service';
export const APIS = [HeliosService, PlanningService, RegistreService, UserService];
