/* The essence of the Gang of Four (GOF) Proxy pattern is to provide a surrogate or placeholder for 
 * another object to control access to it. The Proxy pattern allows us to create a level of indirection 
 * between the client and the actual object, enabling additional functionality to be added without the 
 * client being aware of it.
 * 
 * Here are the key aspects of the Proxy pattern:
 * 
 * Subject: The Subject defines the common interface that both the RealSubject and Proxy implement. 
 * It specifies the operations that the client can perform on the real or proxy object.
 * 
 * RealSubject: The RealSubject is the actual object that the client wants to interact with. 
 * It implements the operations defined in the Subject interface. The RealSubject represents the 
 * core functionality or resource that the client wants to access.
 * 
 * Proxy: The Proxy acts as a surrogate for the RealSubject and implements the same Subject interface. 
 * It controls access to the RealSubject and may perform additional tasks before or after delegating the 
 * request to the RealSubject. The Proxy can add functionality such as caching, lazy initialization, 
 * access control, or logging without modifying the RealSubject or impacting the client's interaction.
 * 
 * Indirection: The Proxy introduces indirection between the client and the RealSubject. Instead of 
 * directly accessing the RealSubject, the client interacts with the Proxy, which internally manages 
 * the RealSubject and provides the same interface. The Proxy forwards the client's requests to the 
 * RealSubject as necessary.
 * 
 * The Proxy pattern allows us to achieve various goals, such as enhancing security, optimizing 
 * performance, or providing a simplified interface to a complex subsystem. It provides a flexible 
 * way to control the behavior of an object by intercepting and augmenting its operations.
 * 
 * Overall, the Proxy pattern enables the client to work with a proxy object that behaves like the 
 * real object, while adding additional features or controlling access to the real object behind the 
 * scenes.
*/

using System;

// Subject interface
public interface ISubject
{
	void Request();
}

// RealSubject class
public class RealSubject : ISubject
{
	public void Request()
	{
		Console.WriteLine("RealSubject: Handling request.");
	}
}

// Proxy class
public class Proxy : ISubject
{
	private RealSubject _realSubject;

	public void Request()
	{
		// Lazy initialization of the RealSubject
		if (_realSubject == null)
		{
			_realSubject = new RealSubject();
		}

		PreRequest();

		// Delegate the request to the RealSubject
		_realSubject.Request();

		PostRequest();
	}

	private void PreRequest()
	{
		Console.WriteLine("Proxy: Preparing for the request.");
	}

	private void PostRequest()
	{
		Console.WriteLine("Proxy: Finishing the request.");
	}
}

// Client code
public class Client
{
	static void Main(string[] args)
	{
		// Create a Proxy
		ISubject proxy = new Proxy();

		// Call the Request method through the Proxy
		proxy.Request();
	}
}

/*
 * In this more generic example, we have the ISubject interface, which serves as the subject. 
 * The RealSubject class is the real implementation of the subject and contains the actual logic for 
 * handling the request.
 * The Proxy class acts as a proxy for the RealSubject and provides additional functionality or 
 * behavior before and after the real subject's request handling. It lazy-initializes the RealSubject 
 * and delegates the Request method to it.
 * 
 * In the client code, we create an instance of the Proxy and call the Request method through the proxy.
 * The proxy performs any necessary preparations before the request, delegates the request to the real 
 * subject, and performs any finishing tasks after the request.
 * 
 * This generic example showcases the Proxy pattern without relying on specific domains or technologies. 
 * It demonstrates how the Proxy pattern can be used to add extra functionality, control access, 
 * or implement caching or synchronization mechanisms around the real subject's operations.
*/