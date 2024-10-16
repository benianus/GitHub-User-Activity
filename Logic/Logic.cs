using GitHub_User_Activity.Data;
using GitHub_User_Activity.EventTypes;
using GitHub_User_Activity.FeaturesEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub_User_Activity.Logic;

public static class Logic
{
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
    public static void ChoosingOption()
    {
        Console.WriteLine("--- Choose Feature: ---");
        Console.WriteLine("1 - Get all user activities");
        Console.WriteLine("2 - Get user activities by Event type");
        Console.WriteLine("3 - Get user activities grouped by event type");
        Console.WriteLine("4 - Exit");
        Console.WriteLine("---------------------------------");
        Console.Write("Please, enter your choice [1] to [4]: ");
        int? choice = Convert.ToInt32(Console.ReadLine());
        PerformOptionChoice((Features.enFeatures?)IsNumberBewtween(choice));
    }
    private static void ChooseEventType()
    {
        Console.Clear();    
        Console.WriteLine("--- Event Types: ---");
        Console.WriteLine("1 - Commit Comment Event");
        Console.WriteLine("2 - Create Event");
        Console.WriteLine("3 - Delete Event");
        Console.WriteLine("4 - Fork Event");
        Console.WriteLine("5 - Gollum Event");
        Console.WriteLine("6 - Issue Comment Event");
        Console.WriteLine("7 - Issues Event");
        Console.WriteLine("8 - Member Event");
        Console.WriteLine("9 - Public Event");
        Console.WriteLine("10 - Pull Request Event");
        Console.WriteLine("11 - Pull Request Review Event");
        Console.WriteLine("12 - Pull Request Review Comment Event");
        Console.WriteLine("13 - Pull Request Review Thread Event");
        Console.WriteLine("14 - Push Event");
        Console.WriteLine("15 - Release Event");
        Console.WriteLine("16 - Sponsor ship Event");
        Console.WriteLine("17 - Watch Event");
        Console.WriteLine("18 - Return to Main Menu");
        Console.WriteLine("---------------------------------");
        Console.Write("Please enter your choice [1] to [18]: ");
        int? choice = Convert.ToInt32(Console.ReadLine());
        PerformEventOptionChoice((EventsEnum.enEventsType?)choice);
    }
    private static async void PerformEventOptionChoice(EventsEnum.enEventsType? eventType)
    {
        switch (eventType)
        {
            case EventsEnum.enEventsType.CommitCommentEvent:
                Console.Clear();
                await DataSource.GetUserActivityByEventType("CommitCommentEvent", GetUsername());
                break;
            case EventsEnum.enEventsType.CreateEvent:
                Console.Clear();
                await DataSource.GetUserActivityByEventType("CreateEvent", GetUsername());
                break;
            case EventsEnum.enEventsType.DeleteEvent:
                Console.Clear();
                await DataSource.GetUserActivityByEventType("DeleteEvent", GetUsername());
                break;
            case EventsEnum.enEventsType.ForkEvent:
                Console.Clear();
                await DataSource.GetUserActivityByEventType("ForkEvent", GetUsername());
                break;
            case EventsEnum.enEventsType.GollumEvent:
                Console.Clear();
                await DataSource.GetUserActivityByEventType("GollumEvent", GetUsername());
                break;
            case EventsEnum.enEventsType.IssueCommentEvent:
                Console.Clear();
                await DataSource.GetUserActivityByEventType("IssueCommentEvent", GetUsername());
                break;
            case EventsEnum.enEventsType.IssuesEvent:
                Console.Clear();
                await DataSource.GetUserActivityByEventType("IssuesEvent", GetUsername());
                break;
            case EventsEnum.enEventsType.MemberEvent:
                Console.Clear();
                await DataSource.GetUserActivityByEventType("MemberEvent", GetUsername());
                break;
            case EventsEnum.enEventsType.PublicEvent:
                Console.Clear();
                await DataSource.GetUserActivityByEventType("PublicEvent", GetUsername());
                break;
            case EventsEnum.enEventsType.PullRequestEvent:
                Console.Clear();
                await DataSource.GetUserActivityByEventType("PullRequestEvent", GetUsername());
                break;
            case EventsEnum.enEventsType.PullRequestReviewEvent:
                Console.Clear();
                await DataSource.GetUserActivityByEventType("PullRequestReviewEvent", GetUsername());
                break;
            case EventsEnum.enEventsType.PullRequestReviewCommentEvent:
                Console.Clear();
                await DataSource.GetUserActivityByEventType("PullRequestReviewCommentEvent", GetUsername());
                break;
            case EventsEnum.enEventsType.PullRequestReviewThreadEvent:
                Console.Clear();
                await DataSource.GetUserActivityByEventType("PullRequestReviewThreadEvent", GetUsername());
                break;
            case EventsEnum.enEventsType.PushEvent:
                Console.Clear();
                await DataSource.GetUserActivityByEventType("PushEvent", GetUsername());
                break;
            case EventsEnum.enEventsType.ReleaseEvent:
                Console.Clear();
                await DataSource.GetUserActivityByEventType("ReleaseEvent", GetUsername());
                break;
            case EventsEnum.enEventsType.SponsorshipEvent:
                Console.Clear();
                await DataSource.GetUserActivityByEventType("SponsorshipEvent", GetUsername());
                break;
            case EventsEnum.enEventsType.WatchEvent:
                await DataSource.GetUserActivityByEventType("WatchEvent", GetUsername());
                
                break;
            default:
                Console.Clear();
                ChoosingOption();
                break;
        }
    }
    private static async void PerformOptionChoice(Features.enFeatures? choice)
    {
        switch (choice)
        {
            case Features.enFeatures.getAll:
                Console.Clear();
                await DataSource.GetAllUserActivities(GetUsername());
                BackToMainMenu();
                break;
            case Features.enFeatures.getByEventType:
                Console.Clear();
                ChooseEventType();
                break;
            case Features.enFeatures.groupedByEventType:
                Console.Clear();
                GetEventsGroupedByEventType();
                Console.Clear();
                ChoosingOption();
                break;
            default:
                Console.Clear();
                break;
        }
    }
    private static void GetEventsGroupedByEventType()
    {
        Console.WriteLine("Feature not implemented yet!");
        Console.ReadLine();
    }
    private static void BackToEventsTypeMenu()
    {
        Console.WriteLine("\nPress any key to go back to main menu");
        Console.ReadKey();
        Console.Clear();
        ChoosingOption();
    }
    private static void BackToMainMenu()
    {
        Console.WriteLine("\nPress any key to go back to main menu");
        Console.ReadKey();
        Console.Clear();
        ChooseEventType();
    }
    private static int? IsNumberBewtween(int? choice)
    {
        if (choice <= 0 || choice > 4)
        {
            Console.WriteLine("Number is not between 1 to 4");
            return 0;
        }

        return choice;
    }
}

