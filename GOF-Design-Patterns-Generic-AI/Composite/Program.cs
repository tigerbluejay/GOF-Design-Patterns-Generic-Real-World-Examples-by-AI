/*
 * The Composite pattern is a structural design pattern that allows you to treat individual objects 
 * and groups of objects uniformly. 
*/

using System;
using System.Collections.Generic;
using System.Xml.Linq;

// Component interface
interface IComponent
{
	void Operation();
}

// Leaf class
class Leaf : IComponent
{
	public void Operation()
	{
		Console.WriteLine("Leaf operation");
	}
}

// Composite class
class Composite : IComponent
{
	private List<IComponent> components = new List<IComponent>();

	public void AddComponent(IComponent component)
	{
		components.Add(component);
	}

	public void RemoveComponent(IComponent component)
	{
		components.Remove(component);
	}

	public void Operation()
	{
		Console.WriteLine("Composite operation");
		foreach (IComponent component in components)
		{
			component.Operation(); // a sort of recursive operation happens here
		}
	}
}
class Program
{
	static void Main(string[] args)
	{
		// Creating leaf objects
		Leaf leaf1 = new Leaf();
		Leaf leaf2 = new Leaf();
		Leaf leaf3 = new Leaf();

		// Creating composite objects
		Composite composite1 = new Composite();
		Composite composite2 = new Composite();

		// Adding leaf objects to composite object 1
		composite1.AddComponent(leaf1);
		composite1.AddComponent(leaf2);

		// Adding leaf and composite objects to composite object 2
		composite2.AddComponent(leaf3);
		composite2.AddComponent(composite1);

		// Performing operations
		composite2.Operation();

		Console.ReadKey();
	}
}

/*
 * In this example, we have two types of objects: Leaf and Composite.Leaf represents the individual
 * objects, while Composite represents a group of objects, which can include both leaf objects and 
 * other composite objects. The IComponent interface defines the common operations that both leaf and 
 * composite objects must implement.

The Main method demonstrates the usage of the Composite pattern. We create instances of leaf objects
(leaf1, leaf2, leaf3) and composite objects (composite1, composite2). We add leaf objects to 
composite1 and composite2, and we also add composite1 to composite2, forming a hierarchical structure.

By calling the Operation method on composite2, the operation is performed on the composite object,
which, in turn, delegates the operation to its child components (leaf objects and the nested composite
object). The result is a recursive operation that is applied uniformly to all elements in the composite
structure.

This demonstrates that the composite object (composite2) performs its operation and delegates it to 
its child components (leaf3 and composite1), which further delegate it to their child components 
(leaf1 and leaf2).
*/