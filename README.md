# ASP.NET-Domain-Driven-Design-Template
ASP.NET domain driven design template based on the Clean Architecture project structure.

Migration script:
dotnet ef migrations add InitialMigration --context "ProductDbContext" --project Products/Products.Infrastructure --startup-project Products/Products.Startup

Things to document:
1. internal properties in Domain. Only factories can instanciate domain objects.
2. Validation - can use custom exceptions if needed
3. Repositories - query and domain. Explain diff.
	Query repository is in Application because it needs to know about the response.
	Domain repository works purely with the domain objects, hence it should be in Domain.
4. Hangfire cron jobs
5. Domain events
6. Should add health checks? Consider it
7. Scrutor for DI
8. Migrations
9. How to run the project
10. Build with section
11 - AUTOMAPPER - automatic mapping profile

Workflow:
1. Using AI to generate common things
2. Workflow to create a use case - starting from domain, controller, use case, repository, configuration etc..