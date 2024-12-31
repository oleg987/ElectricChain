namespace ElectricChainSim.Models;

public class ElectricChain
{
    private readonly Ground _rootGround;

    public ElectricChain()
    {
        _rootGround = new Ground();
    }

    public IElectricComponent Connect(IElectricComponent component)
    {
        _rootGround.Connect(component);

        return component;
    }

    public IElectricComponent ConnectTo(IElectricComponent component, IElectricComponent to)
    {
        if (IsConnected(to))
        {
            to.Connect(component);

            return component;
        }

        throw new Exception("not in chain.");
    }

    public IElectricComponent ConnectToGround(IElectricComponent component)
    {
        component.Connect(_rootGround);

        return _rootGround;
    }

    private bool IsConnected(IElectricComponent component)
    {
        return true;
    }

    public void Test()
    {
        foreach (var rootGroundConnection in _rootGround.Connections)
        {
            rootGroundConnection.SendSignal(0);
        }
    }
}