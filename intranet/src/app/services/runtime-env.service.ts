import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class RuntimeEnvService {
  private env = (window as any).__env || {};

  get(key: string, fallback: any = null) {
    return this.env[key] ?? fallback;
  }

  get apiUrl(): string {
    return this.get('API_URL', 'http://localhost:32771');
  }
}
