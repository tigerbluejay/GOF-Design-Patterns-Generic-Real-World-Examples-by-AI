using System;
using System.Collections.Generic;

// Generic Flyweight interface
public interface IFlyweight<T>
{
    void Operation(T externalState);
}

// Generic Flyweight class
public class ConcreteFlyweight<T> : IFlyweight<T>
{
    private T intrinsicState;

    public ConcreteFlyweight(T intrinsicState)
    {
        this.intrinsicState = intrinsicState;
    }

    public void Operation(T externalState)
    {
        Console.WriteLine($"Intrinsic State: {intrinsicState}, External State: {externalState}");
    }
}

// Flyweight Factory
public class FlyweightFactory<T>
{
    private Dictionary<string, IFlyweight<T>> flyweights;

    public FlyweightFactory()
    {
        flyweights = new Dictionary<string, IFlyweight<T>>();
    }

    public IFlyweight<T> GetFlyweight(string key, T intrinsicState)
    {
        if (!flyweights.TryGetValue(key, out IFlyweight<T> flyweight))
        {
            flyweight = new ConcreteFlyweight<T>(intrinsicState);
            flyweights[key] = flyweight;
        }

        return flyweight;
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        FlyweightFactory<string> flyweightFactory = new FlyweightFactory<string>();

        // Client code requesting flyweights
        IFlyweight<string> flyweight1 = flyweightFactory.GetFlyweight("Flyweight1", "IntrinsicState1");
        IFlyweight<string> flyweight2 = flyweightFactory.GetFlyweight("Flyweight2", "IntrinsicState2");
        IFlyweight<string> flyweight3 = flyweightFactory.GetFlyweight("Flyweight1", "IntrinsicState1"); // Reusing the same intrinsic state

        // Using flyweights with different external states
        flyweight1.Operation("ExternalState1");
        flyweight2.Operation("ExternalState2");
        flyweight3.Operation("ExternalState3");
    }
}
/*
In this generic example, we've replaced the concrete class names with generic names like IFlyweight<T> 
and ConcreteFlyweight<T> to demonstrate the structure of a more generic Flyweight pattern implementation. 
The intrinsic state of the flyweight is represented using the generic type T, which can be any type of data 
that needs to be shared among multiple instances.

The FlyweightFactory<T> is responsible for managing the creation and sharing of flyweight instances based on 
their intrinsic states.The client code requests flyweight instances from the factory and operates on them using 
external states represented by the generic type T.

Remember that this is a simplified generic example, and in a real-world scenario, you would tailor the 
implementation to match your specific use case and data requirements.
*/