FROM node:latest
COPY serve.js package.json package-lock.json ./
RUN ["npm", "i"]
EXPOSE 3000
ENTRYPOINT ["node", "serve"]