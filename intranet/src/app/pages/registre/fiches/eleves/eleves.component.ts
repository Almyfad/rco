import { Component, inject } from '@angular/core';
import { ElevesDataTableComponent } from "../../eleves-datatable/eleves-datatable.component";
import { MembreFiltre, RegistreService } from 'src/app/core/helios-api-client';

@Component({
  selector: 'app-eleves',
  imports: [ElevesDataTableComponent],
  templateUrl: './eleves.component.html',
  styleUrl: './eleves.component.scss'
})
export class ElevesComponent {
  readonly rs = inject(RegistreService);
  fetchEleves = (page?: number, size?: number, filtre?: MembreFiltre) => this.rs.apiRegistreMembresSearchPost(page, size, filtre);
}
