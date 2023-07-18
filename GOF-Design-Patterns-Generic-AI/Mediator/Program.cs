using System;
using System.Collections.Generic;

// Mediator interface
public interface IMediator
{
	void SendMessage(string message, Colleague colleague);
}

// Concrete Mediator
public class ConcreteMediator : IMediator
{
	private List<Colleague> colleagues = new List<Colleague>();

	public void RegisterColleague(Colleague colleague)
	{
		colleagues.Add(colleague);
	}

	public void SendMessage(string message, Colleague colleague)
	{
		foreach (var col in colleagues)
		{
			if (col != colleague)
			{
				col.ReceiveMessage(message);
			}
		}
	}
}

// Colleague abstract class
public abstract class Colleague
{
	protected IMediator mediator;

	public Colleague(IMediator mediator)
	{
		this.mediator = mediator;
	}

	public abstract void Send(string message);

	public abstract void ReceiveMessage(string message);
}

// Concrete Colleague
public class ConcreteColleagueA : Colleague
{
	public ConcreteColleagueA(IMediator mediator) : base(mediator)
	{
	}

	public override void Send(string message)
	{
		Console.WriteLine("Colleague A sends message: " + message);
		mediator.SendMessage(message, this);
	}

	public override void ReceiveMessage(string message)
	{
		Console.WriteLine("Colleague A receives message: " + message);
	}
}

// Concrete Colleague
public class ConcreteColleagueB : Colleague
{
	public ConcreteColleagueB(IMediator mediator) : base(mediator)
	{
	}

	public override void Send(string message)
	{
		Console.WriteLine("Colleague B sends message: " + message);
		mediator.SendMessage(message, this);
	}

	public override void ReceiveMessage(string message)
	{
		Console.WriteLine("Colleague B receives message: " + message);
	}
}

// Usage
public class Program
{
	public static void Main(string[] args)
	{
		// Create mediator
		var mediator = new ConcreteMediator();

		// Create colleagues and register them with the mediator
		var colleagueA = new ConcreteColleagueA(mediator);
		var colleagueB = new ConcreteColleagueB(mediator);
		mediator.RegisterColleague(colleagueA);
		mediator.RegisterColleague(colleagueB);

		// Communication between colleagues happens through the mediator
		colleagueA.Send("Hello from Colleague A!");
		colleagueB.Send("Hello from Colleague B!");
	}
}
/*
In this example, we have a ConcreteMediator class that implements the IMediator interface. 
It keeps track of a list of colleagues and provides the SendMessage method to send messages 
to all colleagues except the sender.

The Colleague class is an abstract class that represents the colleagues participating in 
the communication. It holds a reference to the mediator and defines the abstract 
methods Send and ReceiveMessage.

The ConcreteColleagueA and ConcreteColleagueB classes are concrete implementations of the 
Colleague class. They implement the Send method to send a message using the mediator 
and the ReceiveMessage method to receive messages from other colleagues.

In the Main method, we create a mediator and colleagues, register the colleagues with the 
mediator, and demonstrate the communication between the colleagues through the mediator.

When you run the program, you'll see the output that shows the messages being sent and 
received by the colleagues.
*/
