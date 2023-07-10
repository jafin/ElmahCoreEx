using System.Collections.Generic;

namespace ElmahCore.WebUi.Notifiers
{
    internal class ErrorsList
    {
        public List<ErrorLogEntryWrapper> Errors { get; set; }
        public int TotalCount { get; set; }
    }
}