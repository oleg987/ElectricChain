namespace ElectricChainSim.Models;

public class Ground : ElectricComponentBase
{
    public override double SendSignal(double inputSignal)
    {
        return 0;
    }
}