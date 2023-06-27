/* Let's consider a hypothetical e-commerce application that allows users to place orders. 
 * In this scenario, we can use the Command pattern to implement a command-based order processing 
 * system. Each command represents a specific operation on an order, such as creating an order,
 * updating the shipping address, or canceling the order.
 */

using System;
using System.Collections.Generic;

// The Command interface declares the Execute() method.
interface ICommand
{
	void Execute();
}

// Concrete command classes implementing the ICommand interface.

class CreateOrderCommand : ICommand
{
	private readonly Order _order;

	public CreateOrderCommand(Order order)
	{
		_order = order;
	}

	public void Execute()
	{
		Console.WriteLine("Creating order: " + _order.Id);
		// Logic to create the order
	}
}

class UpdateShippingAddressCommand : ICommand
{
	private readonly Order _order;
	private readonly string _newAddress;

	public UpdateShippingAddressCommand(Order order, string newAddress)
	{
		_order = order;
		_newAddress = newAddress;
	}

	public void Execute()
	{
		Console.WriteLine("Updating shipping address for order: " + _order.Id);
		_order.ShippingAddress = _newAddress;
		// Logic to update the shipping address
	}
}

class CancelOrderCommand : ICommand
{
	private readonly Order _order;

	public CancelOrderCommand(Order order)
	{
		_order = order;
	}

	public void Execute()
	{
		Console.WriteLine("Canceling order: " + _order.Id);
		// Logic to cancel the order
	}
}

// The Invoker class receives and executes commands.

class OrderProcessor
{
	private readonly Queue<ICommand> _commandQueue = new Queue<ICommand>();

	public void AddCommand(ICommand command)
	{
		_commandQueue.Enqueue(command);
	}

	public void ProcessCommands()
	{
		while (_commandQueue.Count > 0)
		{
			var command = _commandQueue.Dequeue();
			command.Execute();
		}
	}
}

// Order class representing an order in the e-commerce application.

class Order
{
	public string Id { get; set; }
	public string ShippingAddress { get; set; }
}

// Client code

class Program
{
	static void Main(string[] args)
	{
		var orderProcessor = new OrderProcessor();

		var order = new Order { Id = "123", ShippingAddress = "123 Main St" };

		// Creating commands
		var createOrderCommand = new CreateOrderCommand(order);
		var updateAddressCommand = new UpdateShippingAddressCommand(order, "456 Elm St");
		var cancelOrderCommand = new CancelOrderCommand(order);

		// Adding commands to the order processor
		orderProcessor.AddCommand(createOrderCommand);
		orderProcessor.AddCommand(updateAddressCommand);
		orderProcessor.AddCommand(cancelOrderCommand);

		// Processing commands
		orderProcessor.ProcessCommands();
	}
}

/* In this example, the ICommand interface declares the Execute() method, which is implemented by 
 * concrete command classes like CreateOrderCommand, UpdateShippingAddressCommand, and 
 * CancelOrderCommand. The OrderProcessor class acts as the invoker, receiving and executing 
 * commands from a queue.
 * 
 * When the program runs, the client code creates an order and instantiates the corresponding 
 * commands to create the order, update the shipping address, and cancel the order. 
 * The commands are then added to the OrderProcessor queue, and the ProcessCommands() method is 
 * invoked to execute each command in sequence.
 * 
 * This example demonstrates how the Command pattern can be utilized in a .NET 6
*/

/* The essence of the Command pattern lies in encapsulating method invocations as objects. 
 * It provides a way to decouple senders of requests from the receivers, enabling flexibility 
 * and extensibility in an application. By encapsulating a request as a command object, the pattern 
 * allows for parameterizing clients with different requests, queuing or logging requests, 
 * supporting undo/redo operations, and implementing transactions. The Command pattern promotes 
 * loose coupling, separation of concerns, and the ability to dynamically configure and execute 
 * commands, resulting in a more maintainable and modular codebase.
 * 
 * In summary, the Command pattern treats commands as first-class objects, providing a powerful 
 * mechanism to encapsulate, parameterize, and execute operations in a flexible and decoupled manner. 
 * It enhances the modularity and extensibility of an application by allowing commands to be treated 
 * as standalone entities that can be composed, queued, logged, undone, and executed dynamically.
 */