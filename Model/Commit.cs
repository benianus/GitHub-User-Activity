using System;

namespace GitHub_User_Activity.Data;

public class Commit
{
    public string? sha { get; set; }
    public Author? author { get; set; }
    public string? message { get; set; }
    public bool distinct { get; set; }
    public string? url { get; set; }
}
