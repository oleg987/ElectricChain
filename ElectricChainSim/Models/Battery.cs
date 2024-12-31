namespace ElectricChainSim.Models;

public class Battery : ElectricComponentBase
{
    public double Voltage { get; }

    public Battery(double voltage)
    {
        Voltage = voltage;
    }

    public override double SendSignal(double inputSignal)
    {
        inputSignal += Voltage;
        
        foreach (var electricComponent in Connections)
        {
            electricComponent.SendSignal(inputSignal);
        }
        
        return inputSignal;
    }
}