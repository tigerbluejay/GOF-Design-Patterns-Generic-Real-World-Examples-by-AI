// The Product class represents a pizza.
public class Pizza
{
	public string Dough { get; set; }
	public string Sauce { get; set; }
	public List<string> Toppings { get; set; }
	public Pizza()
	{
		Toppings = new List<string>();
	}

	public void Display()
	{
		Console.WriteLine($"Dough: {Dough}");
		Console.WriteLine($"Sauce: {Sauce}");
		Console.WriteLine("Toppings:");
		foreach (var topping in Toppings)
		{
			Console.WriteLine($"- {topping}");
		}
	}
}

// The Builder interface defines the steps required to build a pizza.
public interface IPizzaBuilder
{
	void SetDough(string dough);
	void SetSauce(string sauce);
	void AddTopping(string topping);
	Pizza GetPizza();
}

// The ConcreteBuilder class implements the Builder interface and provides the specific implementation for building a pizza.
public class PizzaBuilder : IPizzaBuilder
{
	private Pizza pizza = new Pizza();

	public void SetDough(string dough)
	{
		pizza.Dough = dough;
	}

	public void SetSauce(string sauce)
	{
		pizza.Sauce = sauce;
	}

	public void AddTopping(string topping)
	{
		pizza.Toppings.Add(topping);
	}

	public Pizza GetPizza()
	{
		return pizza;
	}
}

// The Director class controls the construction process by using the Builder interface.
public class PizzaDirector
{
	private IPizzaBuilder builder;

	public PizzaDirector(IPizzaBuilder builder)
	{
		this.builder = builder;
	}

	public void Construct()
	{
		builder.SetDough("Thin crust");
		builder.SetSauce("Tomato sauce");
		builder.AddTopping("Cheese");
		builder.AddTopping("Mushrooms");
		builder.AddTopping("Pepperoni");
	}
}

// Example usage
class Program
{
	static void Main(string[] args)
	{
		// Create a builder instance
		IPizzaBuilder builder = new PizzaBuilder();

		// Create a director instance and set the builder
		PizzaDirector director = new PizzaDirector(builder);

		// Construct the pizza using the director
		director.Construct();

		// Get the final pizza from the builder
		Pizza pizza = builder.GetPizza();

		// Display the pizza
		pizza.Display();
	//}
}

/*
In this example, we have a Pizza class that represents a pizza. The IPizzaBuilder interface 
defines the steps required to build a pizza, and the PizzaBuilder class implements the builder
interface and provides the specific implementation for building the pizza. The PizzaDirector 
class controls the construction process by using the builder interface. In the Main method, 
we create a builder, set it in the director, construct the pizza, and display the final pizza.

This example demonstrates how the Builder pattern can be used in a .NET application to construct 
complex objects like pizzas. The pattern allows you to create pizzas step by step, setting the 
dough, sauce, and adding various toppings, while keeping the construction logic separate from the 
product itself.
*/