using System;

// Context class
class Context
{
	private State currentState;

	public Context()
	{
		// Set an initial state
		currentState = new StateA();
	}

	public void SetState(State state)
	{
		currentState = state;
	}

	public void Request()
	{
		currentState.Handle(this);
	}
}

// State interface
interface State
{
	void Handle(Context context);
}

// Concrete state class A
class StateA : State
{
	public void Handle(Context context)
	{
		Console.WriteLine("Handling request in State A.");
		// Transition to another state if necessary
		context.SetState(new StateB());
	}
}

// Concrete state class B
class StateB : State
{
	public void Handle(Context context)
	{
		Console.WriteLine("Handling request in State B.");
		// Transition to another state if necessary
		context.SetState(new StateA());
	}
}

// Client code
class Program
{
	static void Main(string[] args)
	{
		Context context = new Context();

		// Request 1
		context.Request();

		// Request 2
		context.Request();

		// Request 3
		context.Request();
	}
}

/*
In this example, we have a Context class that maintains an instance of the current state. 
The Context class also provides a method called Request which delegates the handling of the 
request to the current state object.

The State interface defines the Handle method, which each concrete state class must implement.
In this example, we have two concrete state classes, StateA and StateB. Each of these classes 
implements the Handle method to provide the specific behavior associated with that state.

In the Main method of the client code, we create an instance of the Context class and make 
multiple requests. The output will show how the state transitions between StateA and StateB as 
each request is handled.

Note that this is a simplified example to illustrate the State pattern. 
In a real-world scenario, the state transition logic and behavior would likely be more complex.
*/

/*
The State pattern is a behavioral design pattern that enables an object to change its behavior 
dynamically when its internal state changes. It encapsulates different states as separate classes, 
each representing a specific behavior or set of operations associated with a particular state. 
By utilizing polymorphism, the object delegates tasks to the current state object, allowing it to 
vary its behavior based on its state. This approach promotes loose coupling and modular design, 
as new states can be easily added without modifying the existing code.

At its core, the State pattern revolves around the concept of encapsulating state-specific behavior 
in individual state classes. This separation allows for a clear and modular representation of the 
various states and their associated operations. The context object, which holds the state, can 
interact with the current state object without being concerned about the specific behavior or
transition logic. The state objects themselves handle the task execution and can also trigger state 
transitions, dynamically altering the behavior of the context object.

By applying the State pattern, the complexity of managing state and state-dependent behavior is 
reduced. It promotes flexibility, extensibility, and maintainability in systems where objects
exhibit different behaviors based on their internal state. The pattern can be particularly useful in 
scenarios such as workflow management, game development, user interface handling, and any application 
where behavior changes dynamically based on state transitions.
*/