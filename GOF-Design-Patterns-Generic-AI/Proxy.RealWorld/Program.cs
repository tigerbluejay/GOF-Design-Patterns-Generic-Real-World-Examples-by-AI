using System;

// Subject interface
public interface IInternet
{
	void ConnectTo(string serverHost);
}

// RealSubject class
public class RealInternet : IInternet
{
	public void ConnectTo(string serverHost)
	{
		Console.WriteLine("Connecting to " + serverHost);
	}
}

// Proxy class
public class InternetProxy : IInternet
{
	private IInternet _realInternet;
	private string _restrictedSite;

	public InternetProxy(string restrictedSite)
	{
		_restrictedSite = restrictedSite;
	}

	public void ConnectTo(string serverHost)
	{
		if (_restrictedSite == serverHost)
		{
			Console.WriteLine("Access to " + serverHost + " is denied.");
		}
		else
		{
			if (_realInternet == null)
			{
				_realInternet = new RealInternet();
			}
			_realInternet.ConnectTo(serverHost);
		}
	}
}

// Client code
public class Client
{
	static void Main(string[] args)
	{
		// Create an internet proxy
		IInternet internet = new InternetProxy("facebook.com");

		// Access a restricted site
		internet.ConnectTo("facebook.com");

		// Access a non-restricted site
		internet.ConnectTo("google.com");
	}
}

/*
 * In this example, we have the IInternet interface, which serves as the subject. 
 * The RealInternet class is the real implementation of the subject, and it represents the actual 
 * internet connection.
 * 
 * The InternetProxy class acts as a proxy for the RealInternet and provides additional functionality, 
 * such as access control. It takes a restricted site as a parameter in its constructor. When the 
 * ConnectTo method is called on the proxy, it checks if the requested server host is the restricted site.
 * If it is, access is denied. Otherwise, it creates an instance of RealInternet and delegates the 
 * connection to it.
 * 
 * In the client code, we create an InternetProxy and call the ConnectTo method to connect to different 
 * server hosts. When we try to connect to the restricted site, "facebook.com" in this case, the proxy 
 * denies access. However, when we connect to a non-restricted site like "google.com", the proxy allows 
 * the connection by delegating it to the RealInternet object.
 * 
 * This example demonstrates how the Proxy pattern can be used to control access to resources or 
 * services, such as an internet connection, by adding additional behavior or restrictions around 
 * the actual object's functionality.
 */