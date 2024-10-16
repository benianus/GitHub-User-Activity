using GitHub_User_Activity.EventTypes;
using System.Net.Http.Json;

namespace GitHub_User_Activity.Data;
public static class DataSource
{
    public static readonly HttpClient client = new HttpClient();
    public static async Task GetAllUserActivities(string? username)
    {
        client.DefaultRequestHeaders.Add("User-Agent", "CSharpApp");
        client.BaseAddress = new Uri("https://api.github.com/users/");

        if (username == null) {
            Console.WriteLine("Error, username is required!");
            return;
        }

        try
        {
            var response = await client.GetAsync($"{username}/events");

            if (response.IsSuccessStatusCode) 
            {
                var events = await response.Content.ReadFromJsonAsync<List<Activities>>();

                if (events != null)
                {
                    Console.WriteLine("\nOutput:");

                    foreach (var activity in events)
                    {
                        if (activity?.payload?.commits?[0].message == null)
                        {
                            System.Console.WriteLine($"- {activity?.type} to {activity?.repo?.name}");
                        }
                        else
                        {
                            System.Console.WriteLine($"- {activity?.type} {activity?.payload?.commits?[0].message} to {activity?.repo?.name}");
                        }
                    }
                }
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotModified)
            {
                Console.WriteLine("Not modified");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                Console.WriteLine("Forbidden");
            }
            else if(response.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable)
            {
                Console.WriteLine("Service Unavailable");
            }
            else
            {
                Console.WriteLine("Not Found");
            }

        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }
    }
    public static async Task GetUserActivityByEventType(string? eventType, string? username)
    {
        client.BaseAddress = new Uri("https://api.github.com/users/");
        client.DefaultRequestHeaders.Add("User-Agent", "CSharpApp");
        if (username == null)
        {
            Console.WriteLine("Error, username is required!");
            return;
        }

        try
        {
            var response = await client.GetAsync($"{username}/events");

            if (response.IsSuccessStatusCode)
            {
                var events = await response.Content.ReadFromJsonAsync<List<Activities>>();
                
                if (events != null)
                {
                    Console.WriteLine("\nOutput:");

                    foreach (var activity in events)
                    {
                        if (activity.type == eventType)
                        {
                            if (activity?.payload?.commits?[0].message == null)
                            {
                                System.Console.WriteLine($"- {eventType} to {activity?.repo?.name}");
                            }
                            else
                            {
                                System.Console.WriteLine($"- {eventType} {activity?.payload?.commits?[0].message} to {activity?.repo?.name}");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Event list empty");
                }
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotModified)
            {
                Console.WriteLine("Not modified");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                Console.WriteLine("Forbidden");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable)
            {
                Console.WriteLine("Service Unavailable");
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }

    }
}
