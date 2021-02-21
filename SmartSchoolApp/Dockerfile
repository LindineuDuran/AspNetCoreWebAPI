FROM node:latest as angular
WORKDIR /app
COPY package.json /app
COPY package-lock.json /app
RUN npm install --silent
COPY . .
RUN npm run build

# We move our builded application into a nginx container
FROM nginx:alpine
VOLUME /var/cache/nginx

# we can take the value of our "outputPath" into angular.json file
COPY --from=angular app/dist/SmartSchoolFrontEnd /usr/share/nginx/html
COPY ./config/nginx.conf /etc/nginx/conf.d/default.conf

# docker build -t lduran355/smart-school-front-end .
# docker run -d --restart=always -p 5000:80 --network=smartschoolwebapi_smartschoolNET lduran355/smart-school-front-end
