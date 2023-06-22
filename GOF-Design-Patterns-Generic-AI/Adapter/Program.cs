// Target interface that the client expects
interface ITarget
{
	void Request();
}

// Adaptee class with incompatible interface
class Adaptee
{
	public void SpecificRequest()
	{
		Console.WriteLine("Adaptee's SpecificRequest method is called.");
	}
}

// Adapter class that adapts the Adaptee to the Target interface
class Adapter : ITarget
{
	private Adaptee adaptee;

	public Adapter(Adaptee adaptee)
	{
		this.adaptee = adaptee;
	}

	public void Request()
	{
		// Perform necessary operations to adapt the interface
		// Call the specific method of the Adaptee
		adaptee.SpecificRequest();
	}
}

// Client code
class Client
{
	static void Main(string[] args)
	{
		// Create an instance of the Adaptee
		Adaptee adaptee = new Adaptee();

		// Create an instance of the Adapter and pass the Adaptee to its constructor
		ITarget target = new Adapter(adaptee);

		// Call the Request method on the Adapter
		target.Request();
	}
}

/* 
 * In this example, the ITarget interface represents the expected interface by the client. 
 * The Adaptee class has a specific method called SpecificRequest which has an incompatible 
 * interface with the ITarget interface. The Adapter class implements the ITarget interface 
 * and internally uses an instance of Adaptee to perform the necessary adaptations. 
 * The Adapter class's Request method adapts the call to the SpecificRequest method of the Adaptee. 
 * Finally, the client creates an instance of the Adaptee, creates an instance of the Adapter by 
 * passing the Adaptee to its constructor, and calls the Request method on the Adapter.
 * 
 * When executed, the client will be able to use the Adapter to make requests to the Adaptee 
 * through the common ITarget interface, even though the interfaces of Adaptee and ITarget are 
 * incompatible.
 */