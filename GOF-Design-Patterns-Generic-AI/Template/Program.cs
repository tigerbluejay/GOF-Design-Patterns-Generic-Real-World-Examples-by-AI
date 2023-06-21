// Abstract base class defining the template method and the abstract steps
using System.Dynamic;

abstract class AbstractClass
{
	// The template method defines the algorithm skeleton
	public void TemplateMethod()
	{
		// Call the common step
		CommonStep();

		// Call the abstract steps, which will be implemented by the derived classes
		SpecificStep1();
		SpecificStep2();

		// Call the hook method (optional)
		HookMethod();
	}

	// Common step implemented by the base class
	private void CommonStep()
	{
		Console.WriteLine("Executing common step...");
	}

	// Abstract step 1 (to be implemented by derived classes)
	protected abstract void SpecificStep1();

	// Abstract step 2 (to be implemented by derived classes)
	protected abstract void SpecificStep2();

	// Hook method (optional) that can be overridden by derived classes
	protected virtual void HookMethod()
	{
		// Default implementation (empty)
	}
}

// Concrete implementation of the AbstractClass
class ConcreteClass : AbstractClass
{
	protected override void SpecificStep1()
	{
		Console.WriteLine("Executing specific step 1 for ConcreteClass...");
	}

	protected override void SpecificStep2()
	{
		Console.WriteLine("Executing specific step 2 for ConcreteClass...");
	}

	protected override void HookMethod()
	{
		Console.WriteLine("Executing hook method for ConcreteClass...");
	}
}

// Another concrete implementation of the AbstractClass
class AnotherConcreteClass : AbstractClass
{
	protected override void SpecificStep1()
	{
		Console.WriteLine("Executing specific step 1 for AnotherConcreteClass...");
	}

	protected override void SpecificStep2()
	{
		Console.WriteLine("Executing specific step 2 for AnotherConcreteClass...");
	}
}

// Client code
class Program
{
	static void Main(string[] args)
	{
		// Create an instance of ConcreteClass and execute the template method
		AbstractClass concrete = new ConcreteClass();
		concrete.TemplateMethod();

		Console.WriteLine();

		// Create an instance of AnotherConcreteClass and execute the template method
		AbstractClass anotherConcrete = new AnotherConcreteClass();
		anotherConcrete.TemplateMethod();
	}
}


/* 
 * In this example, the AbstractClass represents the abstract base class that defines the template 
 * method and the abstract steps.The TemplateMethod is the main algorithm skeleton that calls the 
 * common step (CommonStep), the abstract steps(SpecificStep1 and SpecificStep2), and the optional 
 * hook method (HookMethod).
 * 
 * The ConcreteClass and AnotherConcreteClass are concrete implementations of the AbstractClass. 
 * They provide the implementation for the abstract steps specific to each class. ConcreteClass 
 * also overrides the optional hook method.
 * 
 * In the client code, we create instances of both concrete classes and execute the template method, 
 * which automatically invokes the defined steps in the proper order.
 * 
 * When you run the program, you will see the output that demonstrates the execution of the 
 * template method and the corresponding steps for each concrete class.
 * 
 * Note: This example illustrates the structure and concept of the Template Method pattern. 
 * In practice, the pattern can be used for more complex scenarios and with various design 
 * considerations.
 */

/*
Abstract methods:
An abstract method is a method declared in an abstract class or an interface.
Abstract methods do not have an implementation in the base class or interface; 
they only provide a method signature.
Any class inheriting from the abstract class or implementing the interface 
must provide an implementation for all the abstract methods, otherwise, 
it must be declared as abstract itself.
Abstract methods must be overridden in derived classes or implemented in classes 
that implement the interface.

Virtual methods:
A virtual method is a method declared in a class using the virtual keyword.
Virtual methods have an implementation in the base class, but they can be 
overridden in derived classes.
Derived classes have the option to override a virtual method with their own 
implementation, but it's not mandatory.
If a derived class does not override a virtual method, the base class 
implementation is used when calling the method on an instance of the derived class.
*/