using System;

// Abstract base class defining the template method and the abstract steps
abstract class PizzaMaker
{
	// The template method defines the algorithm skeleton
	public void MakePizza()
	{
		PrepareDough();
		AddSauce();
		AddToppings();
		BakePizza();
		SlicePizza();
		ServePizza();
	}

	protected void PrepareDough()
	{
		Console.WriteLine("Preparing the pizza dough");
	}

	protected abstract void AddSauce();

	protected abstract void AddToppings();

	protected void BakePizza()
	{
		Console.WriteLine("Baking the pizza");
	}

	protected virtual void SlicePizza()
	{
		Console.WriteLine("Slicing the pizza");
	}

	protected virtual void ServePizza()
	{
		Console.WriteLine("Serving the pizza");
	}
}

// Concrete implementation of the PizzaMaker
class MargheritaPizzaMaker : PizzaMaker
{
	protected override void AddSauce()
	{
		Console.WriteLine("Adding tomato sauce");
	}

	protected override void AddToppings()
	{
		Console.WriteLine("Adding mozzarella cheese and fresh basil leaves");
	}
}

// Another concrete implementation of the PizzaMaker
class PepperoniPizzaMaker : PizzaMaker
{
	protected override void AddSauce()
	{
		Console.WriteLine("Adding tomato sauce");
	}

	protected override void AddToppings()
	{
		Console.WriteLine("Adding mozzarella cheese and pepperoni slices");
	}

	protected override void SlicePizza()
	{
		Console.WriteLine("Slicing the pepperoni pizza into squares");
	}

	protected override void ServePizza()
	{
		Console.WriteLine("Serving the pepperoni pizza with a side of marinara sauce");
	}
}

// Client code
class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Making a Margherita Pizza:");
		PizzaMaker margheritaMaker = new MargheritaPizzaMaker();
		margheritaMaker.MakePizza();

		Console.WriteLine();

		Console.WriteLine("Making a Pepperoni Pizza:");
		PizzaMaker pepperoniMaker = new PepperoniPizzaMaker();
		pepperoniMaker.MakePizza();
	}
}

/*
 * In this example, we have a PizzaMaker abstract class that represents the template for making pizzas.
 * It defines the MakePizza template method, which outlines the steps involved in making a pizza.
 * 
 * The PizzaMaker class provides a default implementation for some steps like PrepareDough, 
 * BakePizza, SlicePizza, and ServePizza. It also declares abstract methods AddSauce and AddToppings, 
 * which must be implemented by the concrete pizza makers.
 * 
 * The MargheritaPizzaMaker and PepperoniPizzaMaker are concrete implementations of the PizzaMaker 
 * class. They override the abstract methods to provide specific sauce and toppings for their 
 * respective pizzas. Additionally, the PepperoniPizzaMaker overrides the SlicePizza and ServePizza 
 * methods to customize the slicing and serving behavior.
 * 
 * In the client code, we create instances of MargheritaPizzaMaker and PepperoniPizzaMaker and call 
 * the MakePizza method on them. This triggers the execution of the template method, which follows 
 * the defined steps for making the pizzas.
 * 
 * When you run the program, you will see the output that demonstrates the execution of the template 
 * method and the specific steps implemented by each pizza maker.
 * 
 * This example shows how the Template Method pattern can be used to define a common algorithm for 
 * a series of related objects while allowing subclasses to provide their own implementations for 
 * specific steps.
 */