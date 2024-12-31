namespace ElectricChainSim.Models;

public abstract class ElectricComponentBase : IElectricComponent
{
    protected readonly HashSet<IElectricComponent> _connections;

    public Guid Id { get; }

    public IReadOnlySet<IElectricComponent> Connections => _connections;
    public bool IsGrounded => CheckIsGrounded();

    protected ElectricComponentBase()
    {
        Id = Guid.NewGuid();
        _connections = new HashSet<IElectricComponent>();
    }
    
    public virtual bool Equals(IElectricComponent? other)
    {
        return other is not null && other.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public virtual void Connect(IElectricComponent component)
    {
        _connections.Add(component);
    }

    public abstract double SendSignal(double inputSignal);
    
    private bool CheckIsGrounded()
    {
        if (this is Ground)
        {
            return true;
        }

        if (Connections.Count == 0)
        {
            return false;
        }

        return CheckIsGrounded(_connections, [this]);
    }
    
    private static bool CheckIsGrounded(HashSet<IElectricComponent> check, HashSet<IElectricComponent> alreadyChecked)
    {
        if (check.Any(c => c is Ground))
        {
            return true;
        }

        bool needContinue = false;
        
        foreach (var node in check)
        {
            if (alreadyChecked.Add(node))
            {
                needContinue = true;
            }
        }

        if (!needContinue)
        {
            return false;
        }

        HashSet<IElectricComponent> nextCheck =
            check
                .SelectMany(c => c.Connections ?? new HashSet<IElectricComponent>())
                .ToHashSet();

        return CheckIsGrounded(nextCheck, alreadyChecked);
    }
}