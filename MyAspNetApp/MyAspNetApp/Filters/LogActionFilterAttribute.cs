using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

public class LogActionFilterAttribute : ActionFilterAttribute
{
    private readonly string _filePath;

    public LogActionFilterAttribute(string filePath)
    {
        _filePath = filePath;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        LogToFile(context.ActionDescriptor.DisplayName, DateTime.Now);
        base.OnActionExecuting(context);
    }

    private void LogToFile(string actionName, DateTime timestamp)
    {
        string logMessage = $"Action '{actionName}' was accessed at {timestamp}";
        File.AppendAllText(_filePath, logMessage + Environment.NewLine);
    }
}
