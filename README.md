# ASP.NET-Domain-Driven-Design-Template
ASP.NET domain driven design template based on the Clean Architecture project structure.

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

Workflow:
1. Using AI to generate common things
2. Workflow to create a use case - starting from domain, controller, use case, repository, configuration etc..