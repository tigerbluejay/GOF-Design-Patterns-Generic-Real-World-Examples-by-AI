using System;

// The Command interface declares a method for executing a command.
interface ICommand
{
	void Execute();
}

// The Receiver class contains some business logic.
class Receiver
{
	public void Action()
	{
		Console.WriteLine("Receiver: Performing an action.");
	}
}

// Concrete commands implement the Command interface and are associated with a Receiver.
class ConcreteCommand : ICommand
{
	private readonly Receiver _receiver;

	public ConcreteCommand(Receiver receiver)
	{
		_receiver = receiver;
	}

	public void Execute()
	{
		Console.WriteLine("ConcreteCommand: Delegating the action to the Receiver.");
		_receiver.Action();
	}
}

// The Invoker class is associated with one or several commands. It sends a request to the command.
class Invoker
{
	private ICommand _command;

	public void SetCommand(ICommand command)
	{
		_command = command;
	}

	public void ExecuteCommand()
	{
		Console.WriteLine("Invoker: Executing the command.");
		_command.Execute();
	}
}

class Program
{
	static void Main(string[] args)
	{
		// Creating the receiver
		var receiver = new Receiver();

		// Creating the command with the receiver
		var command = new ConcreteCommand(receiver);

		// Creating the invoker and associating the command with it
		var invoker = new Invoker();
		invoker.SetCommand(command);

		// Invoking the command
		invoker.ExecuteCommand();
	}
}

/*
 * In this example, we have four main components:
 * 
 * ICommand interface: Declares the Execute() method that concrete commands must implement.
 * Receiver class: Contains the actual business logic and defines the Action() method that 
 * will be called by the concrete command.
 * ConcreteCommand class: Implements the ICommand interface and delegates the execution to 
 * the receiver by calling its Action() method.
 * Invoker class: Stores a reference to a command object and provides a method to execute 
 * the command by calling its Execute() method.
 * When the program runs, the Main method creates an instance of the Receiver, the ConcreteCommand
 * with the receiver, and the Invoker associated with the command. Finally, the ExecuteCommand() 
 * method of the Invoker is called, which invokes the command and triggers the execution of the 
 * receiver's action.
 * 
 * This example demonstrates the basic structure and flow of the Command design pattern, 
 * where commands are encapsulated as objects and can be executed by different invokers 
 * without knowing the specific implementation details of the commands.
 */

/*
 * The Command design pattern is useful in several scenarios:
 * 
 * Decoupling the sender and receiver: The pattern helps to decouple the object that invokes an 
 * operation (the sender) from the object that performs the actual work (the receiver). The sender 
 * doesn't need to know the details of how the operation is implemented, allowing for a more flexible 
 * and loosely coupled architecture.
 * 
 * Encapsulating requests: The pattern encapsulates a request as an object, allowing you to 
 * parameterize clients with different requests, queue or log requests, and support undoable 
 * operations. This encapsulation enables the separation of concerns and provides a way to represent 
 * and manipulate requests as objects.
 * 
 * Supporting undo/redo operations: By encapsulating commands as objects, the Command pattern 
 * allows you to implement undo and redo functionality easily. You can store a history of executed 
 * commands and their parameters, making it possible to reverse or replay them as needed.
 * 
 * Supporting transactions: Commands can be grouped into composite commands, also known as macros or 
 * transactions. This allows you to treat a sequence of commands as a single unit of work. If any 
 * of the commands fail, the entire transaction can be rolled back, ensuring consistency.
 * 
 * Dynamic behavior: The Command pattern allows for dynamic binding between the sender and receiver. 
 * You can dynamically configure a sender with different commands at runtime, providing great 
 * flexibility in controlling the behavior of an application.
 * 
 * Overall, the Command pattern provides a way to encapsulate and parameterize method invocations, 
 * making them first-class objects. This enables loose coupling, separation of concerns, 
 * and additional features like undo/redo and transactions, ultimately enhancing the flexibility, 
 * maintainability, and extensibility of the codebase.
 */
