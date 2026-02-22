using System;
using System.Collections.Generic;
using System.Text;

public interface IStatusProvider
{
    // Use the generic EventHandler to pass our custom data
    event EventHandler<StatusChangedEventArgs> StatusChanged;
}

