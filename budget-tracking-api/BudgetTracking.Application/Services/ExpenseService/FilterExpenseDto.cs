namespace BudgetTracking.Application.Services.ExpenseService;

public record FilterExpenseDto(int? DayAgo, int? SupCategoryId);
