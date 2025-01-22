using BudgetTracking.Application.Services.ExpenseService;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BudgetTracking.API.Endpoints;

public static class ExpenseEndpoints
{
    public static RouteGroupBuilder AddExpenseEndpoints(this RouteGroupBuilder route)
    {
        var group = route.MapGroup("expenses");

        group.MapGet("", GetHandler);
        group.MapPost("", CreateHandler);
        group.MapPut("{id}", UpdateHandler);
        group.MapDelete("{id}", DeleteHandler);

        return group;
    }

    private static async Task<Ok<List<ExpenseDto>>> GetHandler(IExpenseService expenseService, CancellationToken ct)
    {
        var expenses = await expenseService.GetAllAsync(ct);
        return TypedResults.Ok(expenses);
    }
    private static async Task<Created<ExpenseDto>> CreateHandler(InputExpenseDto dto, IExpenseService expenseService, CancellationToken ct)
    {
        var expense = await expenseService.CreateOneAsync(dto, ct);
        return TypedResults.Created($"api/expenses/{expense.Id}", expense);
    }

    private static async Task<Ok<ExpenseDto>> UpdateHandler(int id , InputExpenseDto dto, IExpenseService expenseService, CancellationToken ct)
    {
        var expense = await expenseService.UpdateOneAsync(id, dto, ct);
        return TypedResults.Ok(expense);
    }

    private static async Task<Ok> DeleteHandler(int id , IExpenseService expenseService, CancellationToken ct)
    {
        await expenseService.DeleteOneAsync(id, ct);
        return TypedResults.Ok();
    }
}
