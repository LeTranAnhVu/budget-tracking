
### Create a migration script
```
dotnet ef migrations add [Name] --project ./BudgetTracking.Db --startup-project ./BudgetTracking.API
```

### Update db
```
dotnet ef database update --project ./BudgetTracking.Db --startup-project ./BudgetTracking.API
```