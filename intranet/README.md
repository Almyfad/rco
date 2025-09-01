# Spike-Angular-pro
Spike Angular Admin Dashboard

Runtime environment variables
-----------------------------

This project supports runtime environment variables for Docker deployments using an `assets/env.js` file generated at container start.

How it works:
- `docker-entrypoint.sh` writes `/usr/share/nginx/html/assets/env.js` from container env vars (example: `API_URL`).
- `src/index.html` loads `assets/env.js` before the Angular bundle.
- Use `RuntimeEnvService` (providedIn: 'root') to read `API_URL` at runtime.

Usage example (docker-compose):

	environment:
		- API_URL=https://api.example.org

The container entrypoint will generate `assets/env.js` and start nginx.
