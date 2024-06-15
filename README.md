# ASP.NET-Domain-Driven-Design-Template
ASP.NET domain driven design template based on the Clean Architecture project structure.

Migration script:
dotnet ef migrations add InitialMigration --context "ProductDbContext" --project Products/Products.Infrastructure --startup-project Products/Products.Startup

TODO: rename Product to ProductCatalog

Things to document:
1. internal properties in Domain. Only factories can instanciate domain objects.
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

Workflow:
1. Workflow to create a use case - starting from domain, controller, use case, repository, configuration etc..

How to define your bounded contexts - “Explicitly define the context within which a model applies. Explicitly set boundaries in terms of team organization, usage within specific parts of the application, and physical manifestations such as code bases and database schemas. Keep the model strictly consistent within these bounds, but don’t be distracted or confused by issues outside” - Eric Evans