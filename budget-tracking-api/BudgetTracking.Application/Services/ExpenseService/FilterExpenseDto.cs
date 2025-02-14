namespace BudgetTracking.Application.Services.ExpenseService;

public record FilterExpenseDto(int? DaysAgo, int? SupCategoryId);
