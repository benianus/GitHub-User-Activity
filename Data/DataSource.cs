using System.Net.Http.Json;

namespace GitHub_User_Activity.Data
{
    public class DataSource
    {

        public static readonly HttpClient client = new HttpClient();
        public static async Task GetUserActivities(string? username)
        {
            client.BaseAddress = new Uri("https://api.github.com/users/");
            client.DefaultRequestHeaders.Add("User-Agent", "CSharpApp");

            if (username == null) {
                Console.WriteLine("Error, username is required!");
                return;
            }

            try
            {
                var events = await client.GetFromJsonAsync<List<Activities>>($"{username}/events");

                if (events?.Count > 0)
                {
                    Console.WriteLine("\nOutput:");
                    foreach (var activity in events)
                    {
                        if(activity?.payload?.commits?[0].message == null)
                        {
                            System.Console.WriteLine($"- [Without commit message] to {activity?.repo?.name}");
                        }
                        else
                        {
                            System.Console.WriteLine($"- {activity?.payload?.commits?[0].message} to {activity?.repo?.name}");
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("List is empty");
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

       
    }
}
