/*
 * In this example, we have the IComponent interface that defines the common operations that can 
 * be altered by decorators. The ConcreteComponent class implements the IComponent interface and 
 * provides the basic implementation of the component.
 * 
 * The BaseDecorator class is an abstract class that serves as the base for concrete decorators. 
 * It has a reference to the IComponent interface and implements it as well. It acts as a wrapper 
 * around the component object and provides the default implementation of the interface by 
 * delegating the call to the wrapped object.
 * 
 * The ConcreteDecoratorA and ConcreteDecoratorB classes are concrete decorators that add 
 * additional behavior before or after calling the wrapped object's operation. 
 * They inherit from the BaseDecorator class and override the Operation() method to add 
 * their specific behavior.
 * 
 * In the Main method, we create a concrete component and then wrap it with decorators. 
 * We create an instance of ConcreteDecoratorA by passing the component as a parameter, 
 * and then we create an instance of ConcreteDecoratorB by passing the decorator A as a 
 * parameter. Finally, we call the Operation() method on the decorator B, which triggers 
 * the execution of the operation on the entire decorator chain, including the component 
 * and the decorators.
 */

using System;
using System.Diagnostics.Metrics;

// The component interface defines the common operations that can be altered by decorators.
public interface IComponent
{
	void Operation();
}

// The concrete component class provides the basic implementation of the component interface.
public class ConcreteComponent : IComponent
{
	public void Operation()
	{
		Console.WriteLine("ConcreteComponent.Operation()");
	}
}

// The base decorator class has a reference to the component interface and implements it as well.
// It acts as a base for concrete decorators and provides the default implementation of the
// interface.
public abstract class BaseDecorator : IComponent
{
	private readonly IComponent component;

	public BaseDecorator(IComponent component)
	{
		this.component = component;
	}

	public virtual void Operation()
	{
		component.Operation();
	}
}

// Concrete decorators add additional behavior before or after calling the wrapped object's
// operation.
public class ConcreteDecoratorA : BaseDecorator
{
	public ConcreteDecoratorA(IComponent component) : base(component)
	{
	}

	public override void Operation()
	{
		Console.WriteLine("ConcreteDecoratorA.Operation() - Before");
		base.Operation();
		Console.WriteLine("ConcreteDecoratorA.Operation() - After");
	}
}

public class ConcreteDecoratorB : BaseDecorator
{
	public ConcreteDecoratorB(IComponent component) : base(component)
	{
	}

	public override void Operation()
	{
		Console.WriteLine("ConcreteDecoratorB.Operation() - Before");
		base.Operation();
		Console.WriteLine("ConcreteDecoratorB.Operation() - After");
	}
}

class Program
{
	static void Main(string[] args)
	{
		// Creating a concrete component
		IComponent component = new ConcreteComponent();

		// Wrapping the component with decorators
		IComponent decoratorA = new ConcreteDecoratorA(component);
		IComponent decoratorB = new ConcreteDecoratorB(decoratorA);

		// Calling the operation on the decorator chain
		decoratorB.Operation();
	}
}

/* We define the IComponent interface, which declares the Operation() method.
 * 
 * We implement the ConcreteComponent class, which implements the IComponent interface and 
 * provides the basic implementation of the Operation() method.
 * 
 * We define the BaseDecorator class, an abstract class that implements the IComponent 
 * interface and serves as the base for concrete decorators. It has a reference to the 
 * IComponent interface and provides a default implementation of the Operation() method, 
 * which delegates the call to the wrapped object.
 * 
 * We implement the ConcreteDecoratorA class, which inherits from BaseDecorator. 
 * It overrides the Operation() method to add its specific behavior before and after 
 * calling the wrapped object's operation.
 * 
 * We implement the ConcreteDecoratorB class, which also inherits from BaseDecorator. 
 * It overrides the Operation() method to add its specific behavior before and after 
 * calling the wrapped object's operation.
 * 
 * In the Main method, we create a concrete component instance using ConcreteComponent.
 * 
 * We then create a ConcreteDecoratorA instance by passing the component as a parameter 
 * to its constructor. This wraps the component with ConcreteDecoratorA behavior.
 * 
 * Next, we create a ConcreteDecoratorB instance by passing the ConcreteDecoratorA as 
 * a parameter to its constructor. This wraps the ConcreteDecoratorA with ConcreteDecoratorB 
 * behavior.
 * 
 * Finally, we call the Operation() method on the decoratorB object, which triggers the 
 * execution of the operation on the entire decorator chain, including the component and 
 * the decorators.
 * 
 * Now, let's break down the output sequence:
 * 
 * ConcreteDecoratorB.Operation() -Before: This line is outputted by the Operation() method 
 * of ConcreteDecoratorB before calling the wrapped object's operation.
 * 
 * ConcreteDecoratorA.Operation() -Before: This line is outputted by the Operation() method 
 * of ConcreteDecoratorA before calling the wrapped object's operation. It is called because 
 * ConcreteDecoratorB wraps ConcreteDecoratorA, and ConcreteDecoratorB calls base.Operation(), 
 * which triggers the execution of ConcreteDecoratorA's Operation() method.
 * 
 * ConcreteComponent.Operation(): This line is outputted by the Operation() method of the 
 * ConcreteComponent class. It represents the actual operation being performed by the component.
 * 
 * ConcreteDecoratorA.Operation() -After: This line is outputted by the Operation() method of 
 * ConcreteDecoratorA after calling the wrapped object's operation. It is called because 
 * ConcreteDecoratorB wraps ConcreteDecoratorA, and after the execution of ConcreteComponent's 
 * Operation(), the control is returned to ConcreteDecoratorA.
 * 
 * ConcreteDecoratorB.Operation() -After: This line is outputted by the Operation() method of 
 * ConcreteDecoratorB after calling the wrapped object's operation. It is the last line executed 
 * in the Operation() method of ConcreteDecoratorB.
 */

/*
To summarize, base.Operation() is used within a decorator's Operation() method to delegate 
the call to the wrapped object's Operation() method, whether it's the wrapped component 
or a decorator further down the chain. It allows decorators to add their specific behavior 
before and after calling the wrapped object's operation.
*/

/*
 * So, in the code example, the base object is the ConcreteComponent instance created at the 
 * beginning. The decorators (ConcreteDecoratorA and ConcreteDecoratorB) wrap this base object 
 * to extend or modify its behavior.The base.Operation() call within the decorators refers to 
 * the Operation() method of the wrapped object, which can be the base object itself or another 
 * decorator in the chain.
 */

/* Yes, that's correct. By the time the last line of code in the Main method is executed, 
 * the BaseDecorator component property holds a chain of nested decorator objects.
 * 
 * In the given code example, we start with a ConcreteComponent object as the base object. 
 * Then, we wrap it with decorators ConcreteDecoratorA and ConcreteDecoratorB in sequence. 
 * Each decorator holds a reference to the previous decorator or the base object.
 * 
 * So, in the line IComponent decoratorB = new ConcreteDecoratorB(decoratorA);, the decoratorA
 * object, which is an instance of ConcreteDecoratorA, becomes the wrapped object for 
 * ConcreteDecoratorB. The component property of BaseDecorator holds the reference to the 
 * wrapped object.
 * 
 * Therefore, in the chain decoratorB -> decoratorA -> ConcreteComponent, the component 
 * property of decoratorB points to decoratorA, and the component property of decoratorA 
 * points to ConcreteComponent.
 * 
 * When the Operation() method is called on decoratorB, it triggers the execution of the 
 * operation on the entire decorator chain, starting from decoratorB and cascading down to 
 * the base object (ConcreteComponent). Each decorator in the chain calls base.Operation() 
 * to invoke the operation on the wrapped object, which leads to the execution of the 
 * subsequent decorator's Operation() method or the base object's Operation() method.
 * 
 * So, the component property in the BaseDecorator class holds the nested decorator objects, 
 * allowing the decorators to form a chain and modify the behavior of the wrapped object.
 */