using System;
using System.Reflection.PortableExecutable;

// Complex subsystems
class Subsystem1
{
	public void Operation1()
	{
		Console.WriteLine("Subsystem1: Operation1");
	}

	public void Operation2()
	{
		Console.WriteLine("Subsystem1: Operation2");
	}
}

class Subsystem2
{
	public void Operation1()
	{
		Console.WriteLine("Subsystem2: Operation1");
	}

	public void Operation2()
	{
		Console.WriteLine("Subsystem2: Operation2");
	}
}

// Facade
class Facade
{
	private Subsystem1 subsystem1;
	private Subsystem2 subsystem2;

	public Facade()
	{
		subsystem1 = new Subsystem1();
		subsystem2 = new Subsystem2();
	}

	public void Operation()
	{
		Console.WriteLine("Facade: Operation");
		subsystem1.Operation1();
		subsystem2.Operation1();
	}
}

// Client code
class Program
{
	static void Main(string[] args)
	{
		Facade facade = new Facade();
		facade.Operation();
	}
}

/*
In this example, we have two complex subsystems (Subsystem1 and Subsystem2) that perform various 
operations. The Facade class provides a simplified interface to the client code by encapsulating 
the interactions with the subsystems.

The Facade class initializes instances of the subsystems (Subsystem1 and Subsystem2) in its 
constructor. The Operation method of the Facade class then performs a simplified operation, 
internally invoking the relevant methods from the subsystems.

The client code interacts with the system through the Facade class, which shields the client from 
the complexity of the subsystems. This allows the client to perform operations easily without 
directly accessing or understanding the subsystems.

Here, the Facade is responsible for coordinating the actions of the subsystems, simplifying 
their usage for the client code.
*/