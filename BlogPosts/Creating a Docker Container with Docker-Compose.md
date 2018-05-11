---
title: Creating a Docker Container with Docker-Compose
abstract: Creating docker-compose file, composing a docker service for a Asp .Net Core Website.
weblogName: MyWebsite
postId: 2
---
# Creating a Docker Container with Docker-Compose

### What is docker-compose?

Docker-compose allows for greater customisation and flexibility when creating containers. For instance you can create a normal DockerFile that defines your container image, the ports and App directory, then with the docker-compose you can define how to connect to the container (i.e you can map a different external port to the containers exposed port), the environment variables and install or set up other dependencies related to an environment or that particular instance of the container.

This is handy for creating a a container that can run locally on a development machine, on a Staging Server and finally on a Production server all while using the same initial Dockerfile. 

In my case the only things I change currently between environments for this website are the ports and environment variables.


### How to get started

To get start we first need a project to work with. The following commands are the same as the last Blog post, which creates a basic application that responds with Hello World when run in the browser.

```
mkdir HelloDocker
cd HelloDocker
dotnet new web
```

 Now that we have the project structure we will need to create a docker-compose.yml file. This needs to be one folder level above the dockerfile in this instance.

```
version: '3'
 
services:
  app:
    build:
      context:  ./HelloDocker
      dockerfile: Dockerfile
    ports:
      - "5000:5000"
```

* **version** First we declare which version of docker-compose we are going to use, to find out more about the different version [click here](https://docs.docker.com/compose/compose-file/compose-versioning/). 

* **services** This declares all of the services we will be creating, in this case we are composing the service app. If needed you can declare multiple services, such as a website and reverse proxy (more on that in future a post).

* **build** defines what is needed to create the service at build time. 
  * **context** is use to specify the location of the dockerfile
  * **dockerfile** can be used to specify an alternative dockerfile (i.e Dockerfile-staging)
* **ports** is used to map the docker hosts external port to exposed port on the container, which is currently specified in the dockerfile. You can alternatively expose the port in the docker-compose file by declare the following in the same scope as ports.

```
expose:
  - "5000"
ports:
  - "5000:5000"
```

Now that the file is finished we can now build and run our new service. Open CMD Prompt or Powershell and go to the directory of your compose file then run the following command.

```
docker-compose up
```
This command builds the service, creates the service container and starts the service container in attached mode all with one command. To run the service in Detached mode add the -d option.

Now you can go to http://localhost:5000 and see the response from your newly created service container.

You can also use "start" instead of "up" to create your service but to do so you will need to run the following commands first. This is due to start only being able to run up already created service containers.
 
```
docker-compose build
docker-compose create
docker-compose start
```

Once a service is running (if you are not in attached mode), you can stop the serivce and remove the service container by running:

```
docker-compose down
```

OR alternativly you can run:

```
docker-compose stop
docker-compose rm
```


### Summary

So far we've went through how to create a dockerfile to define the image of the container. 

How to create a docker-compose file for greater flexibity when creating and deploying containers.

And the various docker and docker-compose commands to help us create Docker Container services.

In the next post I will show you how you can use Docker along with the nginx reverse proxy to handle multiple services and load balance those services.