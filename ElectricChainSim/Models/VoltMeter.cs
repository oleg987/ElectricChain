namespace ElectricChainSim.Models;

public class VoltMeterEventArgs : EventArgs
{
    public VoltMeterEventArgs(double voltage)
    {
        Voltage = voltage;
    }

    public double Voltage { get; }
    
}

public class VoltMeter : ElectricComponentBase
{
    public event EventHandler<VoltMeterEventArgs> OnSignalReceived; 

    public override double SendSignal(double inputSignal)
    {
        if (IsGrounded)
        {
            OnSignalReceived?.Invoke(this, new VoltMeterEventArgs(inputSignal));

            foreach (var component in _connections)
            {
                component.SendSignal(inputSignal);
            }
        }
        else
        {
            OnSignalReceived?.Invoke(this, new VoltMeterEventArgs(0));
            
            foreach (var component in _connections)
            {
                component.SendSignal(0);
            }
        }

        return inputSignal;
    }
}