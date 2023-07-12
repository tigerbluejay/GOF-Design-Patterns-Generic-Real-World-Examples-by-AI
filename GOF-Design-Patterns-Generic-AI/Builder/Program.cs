/* 
 * The Builder design pattern is a creational pattern that allows you to create complex objects step 
 * by step. Here's a generic example of the Builder design pattern implemented in C#:
*/

// The product class represents the complex object that you want to build.
public class Product
{
	public string PartA { get; set; }
	public string PartB { get; set; }
	public string PartC { get; set; }

	public void Display()
	{
		Console.WriteLine($"Part A: {PartA}");
		Console.WriteLine($"Part B: {PartB}");
		Console.WriteLine($"Part C: {PartC}");
	}
}

// The builder interface defines the steps required to build the product.
public interface IBuilder
{
	void BuildPartA();
	void BuildPartB();
	void BuildPartC();
	Product GetResult();
}

// The concrete builder class implements the builder interface and provides the specific implementation for building the product.
public class ConcreteBuilder : IBuilder
{
	private Product product = new Product();

	public void BuildPartA()
	{
		product.PartA = "Part A";
	}

	public void BuildPartB()
	{
		product.PartB = "Part B";
	}

	public void BuildPartC()
	{
		product.PartC = "Part C";
	}

	public Product GetResult()
	{
		return product;
	}
}

// The director class controls the construction process by using the builder interface.
public class Director
{
	private IBuilder builder;

	public void SetBuilder(IBuilder builder)
	{
		this.builder = builder;
	}

	public void Construct()
	{
		builder.BuildPartA();
		builder.BuildPartB();
		builder.BuildPartC();
	}
}

// Example usage
class Program
{
	static void Main(string[] args)
	{
		// Create a builder instance
		IBuilder builder = new ConcreteBuilder();

		// Create a director instance and set the builder
		Director director = new Director();
		director.SetBuilder(builder);

		// Construct the product using the director
		director.Construct();

		// Get the final product from the builder
		Product product = builder.GetResult();

		// Display the product
		product.Display();
	}
}
/* 
In this example, we have a Product class that represents the complex object we want to build. 
The IBuilder interface defines the steps required to build the product, and the ConcreteBuilder 
class implements the builder interface and provides the specific implementation for building the 
product. The Director class controls the construction process by using the builder interface. 
Finally, in the Main method, we create a builder, set it in the director, construct the product, 
and display the final product.

Note that this is a simplified example to illustrate the basic concept of the Builder design pattern.
In real-world scenarios, the builder pattern is useful for creating objects with many optional 
parameters or complex construction processes.
*/