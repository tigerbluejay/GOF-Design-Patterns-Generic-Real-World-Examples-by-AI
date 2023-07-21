/*
The Chain of Responsibility pattern is a behavioral design pattern that allows multiple objects to handle a 
request without explicitly specifying the receiver. Instead, each handler in the chain has the ability to 
process the request or pass it along to the next handler in the chain until the request is handled.
*/

using System;

// Request class representing the request to be processed
class Request
{
	public string Content { get; }

	public Request(string content)
	{
		Content = content;
	}
}

// Abstract handler class
abstract class Handler
{
	protected Handler _nextHandler;

	public void SetNextHandler(Handler nextHandler)
	{
		_nextHandler = nextHandler;
	}

	public abstract void HandleRequest(Request request);
}

// Concrete handler 1
class ConcreteHandler1 : Handler
{
	public override void HandleRequest(Request request)
	{
		if (request.Content.Contains("Handler1"))
		{
			Console.WriteLine("ConcreteHandler1 handling the request: " + request.Content);
		}
		else if (_nextHandler != null)
		{
			_nextHandler.HandleRequest(request);
		}
		else
		{
			Console.WriteLine("Request cannot be handled.");
		}
	}
}

// Concrete handler 2
class ConcreteHandler2 : Handler
{
	public override void HandleRequest(Request request)
	{
		if (request.Content.Contains("Handler2"))
		{
			Console.WriteLine("ConcreteHandler2 handling the request: " + request.Content);
		}
		else if (_nextHandler != null)
		{
			_nextHandler.HandleRequest(request);
		}
		else
		{
			Console.WriteLine("Request cannot be handled.");
		}
	}
}

// Client class
class Client
{
	public static void Main(string[] args)
	{
		// Create the handlers
		Handler handler1 = new ConcreteHandler1();
		Handler handler2 = new ConcreteHandler2();

		// Set up the chain of responsibility
		handler1.SetNextHandler(handler2);

		// Process requests
		Request request1 = new Request("This is a Handler1 request.");
		handler1.HandleRequest(request1);

		Request request2 = new Request("This is a Handler2 request.");
		handler1.HandleRequest(request2);

		Request request3 = new Request("This is an unknown request.");
		handler1.HandleRequest(request3);
	}
}
/*
In this example, we have two concrete handlers, ConcreteHandler1 and ConcreteHandler2, 
each capable of handling specific types of requests. The client creates the handlers and sets up the chain of 
responsibility by linking them together using the SetNextHandler method.When a request is sent to the first 
handler in the chain using HandleRequest, it will either handle the request or pass it to the next handler 
in the chain. If there is no handler capable of handling the request, an appropriate message will be displayed.
*/
