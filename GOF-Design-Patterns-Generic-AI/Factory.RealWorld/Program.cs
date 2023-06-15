using System;

// Product interface
public interface IProduct
{
	void Process();
}

// Concrete product 1
public class ConcreteProduct1 : IProduct
{
	public void Process()
	{
		Console.WriteLine("Processing using ConcreteProduct1");
	}
}

// Concrete product 2
public class ConcreteProduct2 : IProduct
{
	public void Process()
	{
		Console.WriteLine("Processing using ConcreteProduct2");
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
		product.Process();

		Console.ReadLine();
	}
}