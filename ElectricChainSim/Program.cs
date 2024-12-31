using ElectricChainSim.Models;

namespace ElectricChainSim;

class Program
{
    static void Main(string[] args)
    {
        var chain = new ElectricChain();

        var battery = new Battery(12);

        var battery2 = new Battery(12);

        var last = chain.Connect(battery);

        last = chain.ConnectTo(battery2, last);

        var voltMeter = new VoltMeter();

        chain.ConnectTo(voltMeter, last);

        chain.ConnectToGround(voltMeter);

        #region Secret

        voltMeter.OnSignalReceived += VoltMeterOnOnSignalReceived;

        #endregion
        
        chain.Test();
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    

    private static void VoltMeterOnOnSignalReceived(object? sender, VoltMeterEventArgs e)
    {
        Console.WriteLine($"VoltMeter: {e.Voltage}V");
    }
}