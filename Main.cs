using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using GitHub_User_Activity.Data;
using Hypermedia.JsonApi.Client;
using JsonLite;
using Microsoft.AspNetCore.Http;

public class GithubUserActivity
{

    public static async Task Main()
    {

        await DataSource.GetUserActivities(GetUsername());
        
        Console.ReadLine();
        
    }

    private static string? GetUsername()
    {
        Console.WriteLine("--- Get Github User Actvity ---");
        Console.Write("Please, Enter your Github Username: ");

        string? username = Console.ReadLine();

        if (username != null)
        {
            return username;
        }

        return null;
    }

}

