# Shared Authentication

This project was created to learn how you can use a single Identity Database to work with multiple Websites and so that I could learn how to use PostgresSQL and Docker together with ASPNET Core.

To run this example you will need Docker and VS2017 preinstalled. You can then clone the repositry and run the solution. To run the applications you can Debug the Docker-Compose Project*. 

*As of writing this you cannot debug the project. This is due to a VS2017 bug with the "build:" section in the docker compose file for identitydatalayer service. If you would still like to run it up to have a look, you can run the following command in the How-To/Projects/SharedAuthentication/SharedAuthentication/ directory:*

    docker-compose -f docker-compose.yml -f docker-compose.override.yml up --build