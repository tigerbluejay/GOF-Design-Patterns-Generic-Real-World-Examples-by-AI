
/* 
 * In this example, we have an interface called IProduct which represents the product that our 
 * factory will create. The concrete product classes ConcreteProduct1 and ConcreteProduct2 
 * both implement the IProduct interface.
 * 
 * The ProductFactory class is responsible for creating the appropriate product based on the 
 * input provided.It contains a CreateProduct method that takes a productType parameter and 
 * uses a switch statement to determine which concrete product to instantiate.
 * 
 * In the Main method of the Program class (acting as the client), the user is prompted to enter 
 * a product type (either "1" or "2"). The ProductFactory is then used to create the corresponding 
 * product, and the Operation method of the product is called to perform some action.
 * 
 * This example demonstrates how the Factory design pattern encapsulates the object creation logic, 
 * allowing the client to create objects without needing to know the specific implementation details.
 */

using System;

// Product interface
public interface IProduct
{
	void Operation();
}

// Concrete product 1
public class ConcreteProduct1 : IProduct
{
	public void Operation()
	{
		Console.WriteLine("ConcreteProduct1 operation");
	}
}

// Concrete product 2
public class ConcreteProduct2 : IProduct
{
	public void Operation()
	{
		Console.WriteLine("ConcreteProduct2 operation");
	}
}

// Factory class
public class ProductFactory
{
	public IProduct CreateProduct(string productType)
	{
		switch (productType)
		{
			case "1":
				return new ConcreteProduct1();
			case "2":
				return new ConcreteProduct2();
			default:
				throw new ArgumentException("Invalid product type");
		}
	}
}

// Client code
public class Program
{
	public static void Main(string[] args)
	{
		Console.WriteLine("Enter product type (1 or 2):");
		string productType = Console.ReadLine();

		ProductFactory factory = new ProductFactory();
		IProduct product = factory.CreateProduct(productType);
		product.Operation();

		Console.ReadLine();
	}
}