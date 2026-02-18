FROM node:20-alpine AS build

WORKDIR /app

ARG DOCS_BASE_URL=/
ENV DOCS_BASE_URL=${DOCS_BASE_URL}

COPY package.json package-lock.json ./
RUN npm ci

COPY . .
RUN npm run build

FROM nginx:1.27-alpine

COPY --from=build /app/build /usr/share/nginx/html

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
