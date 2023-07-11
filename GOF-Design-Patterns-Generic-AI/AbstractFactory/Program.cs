using System;

// Abstract Product A
public interface IProductA
{
	void OperationA();
}

// Concrete Product A1
public class ConcreteProductA1 : IProductA
{
	public void OperationA()
	{
		Console.WriteLine("ConcreteProductA1.OperationA");
	}
}

// Concrete Product A2
public class ConcreteProductA2 : IProductA
{
	public void OperationA()
	{
		Console.WriteLine("ConcreteProductA2.OperationA");
	}
}

// Abstract Product B
public interface IProductB
{
	void OperationB();
}

// Concrete Product B1
public class ConcreteProductB1 : IProductB
{
	public void OperationB()
	{
		Console.WriteLine("ConcreteProductB1.OperationB");
	}
}

// Concrete Product B2
public class ConcreteProductB2 : IProductB
{
	public void OperationB()
	{
		Console.WriteLine("ConcreteProductB2.OperationB");
	}
}

// Abstract Factory
public interface IAbstractFactory
{
	IProductA CreateProductA();
	IProductB CreateProductB();
}

// Concrete Factory 1
public class ConcreteFactory1 : IAbstractFactory
{
	public IProductA CreateProductA()
	{
		return new ConcreteProductA1();
	}

	public IProductB CreateProductB()
	{
		return new ConcreteProductB1();
	}
}

// Concrete Factory 2
public class ConcreteFactory2 : IAbstractFactory
{
	public IProductA CreateProductA()
	{
		return new ConcreteProductA2();
	}

	public IProductB CreateProductB()
	{
		return new ConcreteProductB2();
	}
}

// Client
public class Client
{
	private IProductA productA;
	private IProductB productB;

	public Client(IAbstractFactory factory)
	{
		productA = factory.CreateProductA();
		productB = factory.CreateProductB();
	}

	public void Run()
	{
		productA.OperationA();
		productB.OperationB();
	}
}

// Usage
public class Program
{
	public static void Main()
	{
		// Create a client with Factory 1
		IAbstractFactory factory1 = new ConcreteFactory1();
		Client client1 = new Client(factory1);
		client1.Run();

		// Create a client with Factory 2
		IAbstractFactory factory2 = new ConcreteFactory2();
		Client client2 = new Client(factory2);
		client2.Run();
	}
}

/*
In this example, we have two families of related products: Product A and Product B. 
The IProductA and IProductB interfaces define the common operations for their respective 
product families.

The ConcreteProductA1 and ConcreteProductA2 classes are two different implementations of IProductA, 
and the ConcreteProductB1 and ConcreteProductB2 classes are two different implementations of 
IProductB.

The IAbstractFactory interface declares the abstract factory methods CreateProductA() and
CreateProductB(). The ConcreteFactory1 and ConcreteFactory2 classes implement this interface 
to provide concrete implementations of the factory methods, creating specific product 
instances for their respective families.

The Client class represents the client code that utilizes the abstract factory and the 
products it creates. The client takes an instance of the abstract factory in its constructor 
and uses it to create the required product instances. The Run() method demonstrates how the 
client can operate on the products by invoking their common operations.

In the Main method, we create two clients, each with a different concrete factory 
(ConcreteFactory1 and ConcreteFactory2). The clients then invoke the Run() method to demonstrate 
the usage of the abstract factory pattern with different product families.
*/

