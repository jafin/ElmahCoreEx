using System;
using System.Collections.Generic;

namespace ElmahCore.Mvc.Observers;

public interface IElmahDiagnosticObserver : IObserver<KeyValuePair<string, object>>
{
}
