using System;

// Abstract Product: Car
public interface ICar
{
	void Assemble();
}

// Concrete Products: Sedan and SUV
public class Sedan : ICar
{
	public void Assemble()
	{
		Console.WriteLine("Assembling Sedan");
	}
}

public class SUV : ICar
{
	public void Assemble()
	{
		Console.WriteLine("Assembling SUV");
	}
}

// Abstract Factory: Car Factory
public interface ICarFactory
{
	ICar CreateCar();
}

// Concrete Factories: Sedan Factory and SUV Factory
public class SedanFactory : ICarFactory
{
	public ICar CreateCar()
	{
		return new Sedan();
	}
}

public class SUVFactory : ICarFactory
{
	public ICar CreateCar()
	{
		return new SUV();
	}
}

// Client
public class Client
{
	private ICar car;

	public Client(ICarFactory factory)
	{
		car = factory.CreateCar();
	}

	public void BuildCar()
	{
		Console.WriteLine("Building car...");
		car.Assemble();
		Console.WriteLine("Car built successfully.");
	}
}

// Usage
public class Program
{
	public static void Main()
	{
		// Create a client with Sedan Factory
		ICarFactory sedanFactory = new SedanFactory();
		Client sedanClient = new Client(sedanFactory);
		sedanClient.BuildCar();

		// Create a client with SUV Factory
		ICarFactory suvFactory = new SUVFactory();
		Client suvClient = new Client(suvFactory);
		suvClient.BuildCar();
	}
}

/*
In this example, we have a car manufacturing scenario. We have two types of cars: Sedan and SUV. 
The ICar interface defines the common operations that all cars must implement.

The Sedan and SUV classes are concrete implementations of the ICar interface, representing 
specific types of cars.

The ICarFactory interface declares the abstract factory method CreateCar(). The SedanFactory and 
SUVFactory classes implement this interface to provide concrete implementations of the factory 
method, creating instances of Sedan and SUV respectively.

The Client class represents a client that wants to build a car. The client takes an instance of 
the abstract factory in its constructor and uses it to create the desired car instance. 
The BuildCar() method demonstrates how the client can assemble the car by invoking its Assemble() 
method.

In the Main method, we create two clients, each with a different concrete factory 
(SedanFactory and SUVFactory). The clients then invoke the BuildCar() method to demonstrate 
the usage of the abstract factory pattern for building different types of cars.

This example demonstrates how the Abstract Factory pattern can be used to encapsulate the creation 
of related objects (cars) without exposing the concrete implementation details to the client code.

Overall, the Abstract Factory pattern provides a way to create families of related objects in a 
flexible, decoupled, and extensible manner. It promotes modular and reusable code by 
encapsulating object creation logic and abstracting away the specific classes involved in the 
process.
*/

