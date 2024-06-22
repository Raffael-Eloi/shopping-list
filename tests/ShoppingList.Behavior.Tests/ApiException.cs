namespace ShoppingList.Behavior.Tests;

public partial class ApiException<TResult>
{
    public override string ToString()
    {
        if (Result is ProblemDetails problem)
        {
            if (problem.Detail != null)
                return problem.Detail;
            
            AddInformationFromException(problem);

            return problem.Detail!;
        }

        if (Result is ValidationProblemDetails problemDetails)
        {
            var messages = problemDetails.Errors.Select(error =>
             $"{error.Key} => {string.Join(":", error.Value)}");

            return string.Join(";", messages);
        }

        return string.Format("HTTP Response: \n\n{0}", Response);
    }

    private static void AddInformationFromException(ProblemDetails problem)
    {
        problem.Title = problem.AdditionalProperties["Message"].ToString();
        problem.Detail = problem.AdditionalProperties["Message"].ToString();
        problem.Status = int.Parse(problem.AdditionalProperties["StatusCode"].ToString()!);
    }

    public override string Message => ToString();
}