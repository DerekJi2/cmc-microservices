# CMC Microservices

This project is trying to build a light microservice architecture for small or medium projects. In business, it is aiming to manage contractors (vendors? or providers?) with
* contractors' basic information
* contractors' licences & certificates (to make sure they are eligible to work on the specific areas)
* workers of contractors
* workers' licences & certificates
* jobs
* invoices
* payments
* tenants (sections? or departments?)
* property managers (project managers?)

Since it's only a proof-of-concept project, all the business models & workflows will be simplified.

Considering the risks during the whole life cycle with microservice architecture, I'd like to evolve gradually.

## Step 1. Build a monolithic project as we're familiar
In this traditional way, it's much easier for most developers. 
However, we should design the system considering possible changes in the following steps to gain benefits from microservice architecture.
For example, we could split the database into multiple ones. And, the services or controllers could be organised with more considerations.

## Step 2. Extract a part away
Build a separate project for the relevant domain. Then, we could deploy the projects onto Serverless (Azure Functions or Lambda)

## Step 3. Extract more parts
During the process, try to find out more problems and verify the whole architecture. 
If necessary, introduce mature (maybe heavier) frameworks or even migrate to a better platform.

## Step 4. Containerize the whole application
Start to dockerize the services one by one and then Kubernetes.

In one word, techniques are not important, business is. 
Hence, the fist thing we have to do for any project is to QUICKLY build a STABLE sytem to make our boss or customers happy.
