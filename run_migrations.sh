#!/bin/bash

dotnet ef migrations add InitialMigration --context "StatisticsDbContext" --project Statistics/Statistics.Infrastructure --startup-project ProjectStartup
dotnet ef migrations add InitialMigration --context "ProductDbContext" --project ProductCatalog/ProductCatalog.Infrastructure --startup-project ProjectStartup
dotnet ef migrations add InitialMigration --context "OrderManagementDbContext" --project OrderManagement/OrderManagement.Infrastructure --startup-project ProjectStartup
dotnet ef migrations add InitialMigration --context "IdentityDbContext" --project Identity/Identity.Infrastructure --startup-project ProjectStartup
