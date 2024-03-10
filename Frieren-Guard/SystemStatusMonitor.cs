namespace Frieren_Guard;

using Frieren_Guard.Events;
using Microsoft.Extensions.Diagnostics.HealthChecks;

public class SystemStatusMonitor
{
    public event EventHandler<SystemStatusChangedEvent>? SystemStatusChanged;

    public void UpdateSystemStatus(HealthReport newHealthReport)
    {
        OnSystemStatusChanged(new SystemStatusChangedEvent(newHealthReport));
    }

    protected virtual void OnSystemStatusChanged(SystemStatusChangedEvent e)
    {
        SystemStatusChanged?.Invoke(this, e);
    }
}
