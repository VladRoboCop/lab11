using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;

public class UniqueUsersActionFilterAttribute : ActionFilterAttribute
{
    private readonly string _filePath;

    public UniqueUsersActionFilterAttribute(string filePath)
    {
        _filePath = filePath;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        CountUniqueUser();
        base.OnActionExecuting(context);
    }

    private void CountUniqueUser()
    {
        HashSet<string> uniqueUsers = LoadUniqueUsers();
        string ipAddress = GetIpAddress(); // Assume this method gets user's IP address

        if (!uniqueUsers.Contains(ipAddress))
        {
            uniqueUsers.Add(ipAddress);
            SaveUniqueUsers(uniqueUsers);
        }
    }

    private HashSet<string> LoadUniqueUsers()
    {
        if (!File.Exists(_filePath))
            return new HashSet<string>();

        string[] lines = File.ReadAllLines(_filePath);
        return new HashSet<string>(lines);
    }

    private void SaveUniqueUsers(HashSet<string> uniqueUsers)
    {
        File.WriteAllLines(_filePath, uniqueUsers);
    }

    private string GetIpAddress()
    {
        // Logic to get user's IP address
        return "127.0.0.1"; // Placeholder
    }
}
