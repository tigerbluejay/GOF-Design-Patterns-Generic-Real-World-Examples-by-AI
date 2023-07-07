using System;

// Abstraction
abstract class Abstraction
{
	protected Implementor implementor;

	protected Abstraction(Implementor implementor)
	{
		this.implementor = implementor;
	}

	public abstract void Operation();
}

// Refined Abstraction
class RefinedAbstraction : Abstraction
{
	public RefinedAbstraction(Implementor implementor) : base(implementor)
	{
	}

	public override void Operation()
	{
		implementor.OperationImp();
	}
}

// Implementor
interface Implementor
{
	void OperationImp();
}

// Concrete Implementor A
class ConcreteImplementorA : Implementor
{
	public void OperationImp()
	{
		Console.WriteLine("ConcreteImplementorA: OperationImp");
	}
}

// Concrete Implementor B
class ConcreteImplementorB : Implementor
{
	public void OperationImp()
	{
		Console.WriteLine("ConcreteImplementorB: OperationImp");
	}
}

// Client
class Program
{
	static void Main(string[] args)
	{
		Abstraction abstractionA = new RefinedAbstraction(new ConcreteImplementorA());
		abstractionA.Operation();

		Abstraction abstractionB = new RefinedAbstraction(new ConcreteImplementorB());
		abstractionB.Operation();
	}
}
/*
 In this generic example, we have an abstraction Abstraction that defines the interface for different 
operations. The RefinedAbstraction class is a refined abstraction that inherits from Abstraction and 
implements the Operation() method.

The Implementor interface serves as the implementor, defining the contract for the operation. 
The ConcreteImplementorA and ConcreteImplementorB classes are concrete implementations that 
provide different implementations of the operation.

In the client code, we create instances of RefinedAbstraction with different implementations of 
Implementor and call the Operation() method on each abstraction. The appropriate implementation 
of the operation is invoked based on the implementor associated with each abstraction.

This generic example demonstrates how the Bridge pattern allows the abstraction and implementation 
to vary independently, enabling different combinations of abstractions and implementations at runtime.
*/

/*

The Bridge design pattern aims to decouple an abstraction from its implementation, allowing both to 
vary independently. It provides a way to separate the abstraction's interface from its implementation 
details. The main points and benefits of using the Bridge design pattern are:

Decoupling of Abstraction and Implementation: The pattern allows the abstraction and implementation 
to evolve independently. They can be modified, extended, or replaced without affecting each other. 
Changes to the implementation do not require changes to the abstraction and vice versa.

Improved Extensibility: By separating the abstraction and implementation, new abstractions or 
implementations can be added without modifying the existing code. It promotes an open-closed principle,
making it easier to introduce new variants without impacting the rest of the codebase.

Hiding Complexity: The Bridge pattern hides the complexity of the implementation details from the client
code. The client interacts only with the abstraction, without being aware of the specific implementation 
being used. This simplifies the client code and improves its understandability.

Runtime Binding: The Bridge pattern allows the selection of different implementations at runtime. 
It provides flexibility in choosing the appropriate implementation based on dynamic conditions or 
user preferences, without the need for compile-time dependencies.

Separation of Interface and Implementation Hierarchies: The Bridge pattern enables the creation of 
separate hierarchies for the abstraction and implementation. This is especially useful when there are 
multiple dimensions of variation, as it avoids the combinatorial explosion of classes that would occur 
in a single hierarchy.

Overall, the Bridge design pattern promotes loose coupling, flexibility, and maintainability in the 
system by separating the abstraction from its implementation and allowing them to vary independently. 
It is particularly useful in scenarios where there are multiple implementations and when changes or 
extensions to both the abstraction and implementation are anticipated.
*/