# .NET Domain Driven Design implemented with Clean Architecture and Vertical slices.
The goal of this template is to provide a template for building highly decoupled monolithic .NET applications that can be easily extracted into microservices if the required by your business needs.
Bounded Contexts separation - each bounded context is separated into its own separate project, hence highly reducing the probability of coupling between domains. To avoid having to deal with the overhead of managing multiple micro service deployments for each domain, the solution builds all of the contexts through the StartupProject, that way your development teams can gain the rapid development speed of using a monolith, while at the same time restricting the domains to be coupled with each other due to the domain separation by project.

<div align="center">
  <img src="./architecture-diagram.png" alt="Description of Image" style="width:80%;">
</div>

Migration script:
dotnet ef migrations add InitialMigration --context "ProductDbContext" --project Products/Products.Infrastructure --startup-project Products/Products.Startup

Key benefits to this template:
1. Complete separation of bounded contexts via API and Event Sourcing while still being part of a single solution and a single database. Allows for very quick development and a very easy migration to microservices. Making bounded context violations is very difficult due to the separation of the contexts in different projects.

Things to document:
1. internal proeperties in Domain. Only factories can instanciate domain objects.
2. Validation - can use custom exceptions if needed
3. Repositories - query and domain. Explain diff.
	Query repository return Response objects. They must reside in Application because it needs to know about the response. 
	Domain repository works purely with the domain objects, hence it should be in Domain.
4. Hangfire cron jobs
5. Domain events
6. Should add health checks? Consider it
7. Scrutor for DI
8. Migrations
9. How to run the project
10. Build with section
11 - AUTOMAPPER - automatic mapping profile
12. Each project is responsible for registering its services via an 'Add' abstraction. (For example AddDomain)
13. Bounded context separation via Repository
14. TODO: remove secrets and explain where to set secret
15. Resolve issue with DBInitializer comment
16. Rename solution
17 Create aggregator solution if there is a solution that can't fit existing context, or just merge contexts.
18. Bounded contests - think of them like microservices within a single solution.
19. add unit tests
20. Rename ProjectStartup to Startup

TODO: consider renaming back to Product and Orders because it's more intuitive.

Workflow:
1. Workflow to create a use case - starting from domain, controller, use case, repository, configuration etc..

How to define your bounded contexts - “Explicitly define the context within which a model applies. Explicitly set boundaries in terms of team organization, usage within specific parts of the application, and physical manifestations such as code bases and database schemas. Keep the model strictly consistent within these bounds, but don’t be distracted or confused by issues outside” - Eric Evans
