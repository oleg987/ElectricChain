namespace ElectricChainSim.Models;

public interface IElectricComponent : IEquatable<IElectricComponent>
{
    public Guid Id { get; }
    public IReadOnlySet<IElectricComponent>? Connections { get; }
    public bool IsGrounded { get; }
    void Connect(IElectricComponent component);
    double SendSignal(double inputSignal);
}