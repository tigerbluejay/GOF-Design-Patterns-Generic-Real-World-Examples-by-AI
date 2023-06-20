/* 
 * In simple terms, the Observer pattern allows multiple objects to be notified automatically when 
 * the state of another object changes. It establishes a "one-to-many" relationship between the object
 * being observed (known as the subject) and the objects observing it (known as observers).
 * 
 * Think of a real-life scenario where you have a weather station that measures temperature, 
 * humidity, and pressure. You want different displays, such as a mobile app and a website, to 
 * show the updated weather information whenever there is a change. Instead of constantly polling 
 * the weather station for updates, the Observer pattern comes into play. The weather station becomes
 * the subject, and the mobile app and website become the observers. The observers register themselves
 * with the weather station, and whenever the weather station's measurements change, it automatically 
 * notifies all the registered observers. This way, the observers can update their displays with the
 * latest weather information without needing to constantly check for updates.
 * 
 * In summary, the Observer pattern enables a decoupled and flexible communication mechanism 
 * between objects. It allows one object (the subject) to inform a group of other objects 
 * (the observers) about any state changes, ensuring that they stay synchronized and respond 
 * accordingly. It promotes loose coupling, extensibility, and maintainability in software design 
 * by separating the subject and observers, making it easier to add or remove observers without 
 * impacting the subject's implementation.
*/



// Subject (Observable)
interface ISubject
{
	void Attach(IObserver observer);
	void Detach(IObserver observer);
	void Notify();
}

// Concrete Subject
class ConcreteSubject : ISubject
{
	private List<IObserver> observers = new List<IObserver>();
	private string state;

	public string State
	{
		get { return state; }
		set
		{
			state = value;
			Notify();
		}
	}

	public void Attach(IObserver observer)
	{
		observers.Add(observer);
	}

	public void Detach(IObserver observer)
	{
		observers.Remove(observer);
	}

	public void Notify()
	{
		foreach (var observer in observers)
		{
			observer.Update();
		}
	}
}

// Observer
interface IObserver
{
	void Update();
}

// Concrete Observer
class ConcreteObserver : IObserver
{
	private string name;
	private ConcreteSubject subject;

	public ConcreteObserver(string name, ConcreteSubject subject)
	{
		this.name = name;
		this.subject = subject;
	}

	public void Update()
	{
		Console.WriteLine($"Observer {name} received an update. New state: {subject.State}");
	}
}

// Program (Client)
class Program
{
	static void Main(string[] args)
	{
		// Create subject and observers
		var subject = new ConcreteSubject();
		var observer1 = new ConcreteObserver("Observer 1", subject);
		var observer2 = new ConcreteObserver("Observer 2", subject);

		// Attach observers to the subject
		subject.Attach(observer1);
		subject.Attach(observer2);

		// Change subject's state
		subject.State = "State 1";

		// Detach observer1 from the subject
		subject.Detach(observer1);

		// Change subject's state again
		subject.State = "State 2";

		Console.ReadLine();
	}
}


/* 
 * In this example, the ISubject interface represents the subject(observable) which maintains a list of 
 * observers and provides methods to attach, detach, and notify the observers. The ConcreteSubject class 
 * implements the ISubject interface and manages the state. When the state changes, it notifies all 
 * attached observers.
 * 
 * The IObserver interface represents the observer, and the ConcreteObserver class implements the 
 * IObserver interface. The observers register themselves with the subject to receive updates. 
 * The Update method is called by the subject when there is a state change, and the observers react 
 * to the change.
 * 
 * In the Program class, we create a ConcreteSubject object and two ConcreteObserver objects. 
 * We attach the observers to the subject, change the subject's state, detach one of the observers, 
 * and change the state again. The observers receive updates and display the new state in the console 
 * output.
 * 
 * This example demonstrates the basic implementation of the Observer design pattern in a .NET MVC 6 
 * Console App using C#. You can expand upon it and customize it according to 
 * your specific requirements.
 */

