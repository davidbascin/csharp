using System;
using System.Collections.Generic;
using System.Text;

public class StatusChangedEventArgs
{
    public string StatusMessage { get; }
    public bool IsBusy { get; }

    public StatusChangedEventArgs(string message, bool busy)
    {
        StatusMessage = message;
        IsBusy = busy;
    }
}
