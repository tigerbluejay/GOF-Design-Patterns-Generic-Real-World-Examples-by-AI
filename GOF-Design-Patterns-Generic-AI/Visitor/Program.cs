using System;
using System.Collections.Generic;
using System.Xml.Linq;

// Element interface
interface IElement
{
	void Accept(IVisitor visitor);
}

// Concrete Element A
class ConcreteElementA : IElement
{
	public void Accept(IVisitor visitor)
	{
		visitor.Visit(this);
	}

	public void OperationA()
	{
		Console.WriteLine("Operation A of ConcreteElementA");
	}
}

// Concrete Element B
class ConcreteElementB : IElement
{
	public void Accept(IVisitor visitor)
	{
		visitor.Visit(this);
	}

	public void OperationB()
	{
		Console.WriteLine("Operation B of ConcreteElementB");
	}
}

// Visitor interface
interface IVisitor
{
	void Visit(ConcreteElementA element);
	void Visit(ConcreteElementB element);
}

// Concrete Visitor
class ConcreteVisitor : IVisitor
{
	public void Visit(ConcreteElementA element)
	{
		Console.WriteLine("ConcreteVisitor is visiting ConcreteElementA");
		element.OperationA();
	}

	public void Visit(ConcreteElementB element)
	{
		Console.WriteLine("ConcreteVisitor is visiting ConcreteElementB");
		element.OperationB();
	}
}

// Object Structure
class ObjectStructure
{
	private List<IElement> elements = new List<IElement>();

	public void Attach(IElement element)
	{
		elements.Add(element);
	}

	public void Detach(IElement element)
	{
		elements.Remove(element);
	}

	public void Accept(IVisitor visitor)
	{
		foreach (var element in elements)
		{
			element.Accept(visitor);
		}
	}
}

// Client
class Client
{
	static void Main(string[] args)
	{
		var objectStructure = new ObjectStructure();
		objectStructure.Attach(new ConcreteElementA());
		objectStructure.Attach(new ConcreteElementB());

		var visitor = new ConcreteVisitor();
		objectStructure.Accept(visitor);
	}
}
/* 
In this example, we have an object structure that contains elements (ConcreteElementA and 
ConcreteElementB). The IElement interface declares an Accept method that accepts a visitor object. 
Each concrete element implements the Accept method, which calls the appropriate visitor method 
based on the element's type.

The IVisitor interface declares separate Visit methods for each type of element. 
The ConcreteVisitor class implements the IVisitor interface and provides the implementation for 
each Visit method. When the visitor visits an element, it performs the necessary operations 
specific to that element.

The Client class demonstrates how to use the visitor pattern. It creates an ObjectStructure 
and attaches concrete elements to it. It also creates a ConcreteVisitor object. Finally, 
it calls the Accept method on the ObjectStructure, passing the visitor, which triggers the 
visitation process.

When you run the example, you'll see the output that indicates the visitor visiting each 
element and performing the appropriate operations based on the element's type.
*/