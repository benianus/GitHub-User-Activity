﻿namespace GitHub_User_Activity.EventTypes;

public static class EventsEnum
{
    public enum enEventsType
    {
        CommitCommentEvent = 1,
        CreateEvent,
        DeleteEvent,
        ForkEvent,
        GollumEvent,
        IssueCommentEvent,
        IssuesEvent,
        MemberEvent,
        PublicEvent,
        PullRequestEvent,
        PullRequestReviewEvent,
        PullRequestReviewCommentEvent,
        PullRequestReviewThreadEvent,
        PushEvent,
        ReleaseEvent,
        SponsorshipEvent,
        WatchEvent
    }

    public static enEventsType eventType = enEventsType.PushEvent;
}


