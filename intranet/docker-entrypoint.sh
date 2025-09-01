#!/bin/sh
# Generate runtime environment file for Angular in nginx html folder
# Expects environment variables like API_URL to be present in the container
TARGET_DIR="/usr/share/nginx/html/assets"
mkdir -p "$TARGET_DIR"
cat > "$TARGET_DIR/env.js" <<EOF
window.__env = {
  API_URL: "${API_URL:-http://localhost:3000}",
};
EOF

# execute the original command (nginx)
exec "$@"
