/*
Imagine a scenario where you have a complex UI with multiple user interface components that need 
to communicate with each other. The Mediator pattern can be used to handle the interactions 
between these components in a centralized and decoupled manner. Let's consider a simplified 
example of a flight booking application where the mediator handles communication between a flight 
search component, a passenger information component, and a payment component.
*/

using System;

// Mediator interface
public interface IFlightBookingMediator
{
	void SearchFlights(string origin, string destination, DateTime date);
	void SelectFlight(string flightNumber);
	void BookFlight(string passengerName, string flightNumber);
	void ProcessPayment(string passengerName, string flightNumber, decimal amount);
}

// Concrete Mediator
public class FlightBookingMediator : IFlightBookingMediator
{
	private FlightSearchComponent flightSearchComponent;
	private PassengerInfoComponent passengerInfoComponent;
	private PaymentComponent paymentComponent;

	public FlightBookingMediator(FlightSearchComponent flightSearchComponent,
								 PassengerInfoComponent passengerInfoComponent,
								 PaymentComponent paymentComponent)
	{
		this.flightSearchComponent = flightSearchComponent;
		this.passengerInfoComponent = passengerInfoComponent;
		this.paymentComponent = paymentComponent;
	}

	public void SearchFlights(string origin, string destination, DateTime date)
	{
		// Perform flight search logic and update UI components
		// ...
		Console.WriteLine("Mediator: Flight search completed.");
		flightSearchComponent.DisplaySearchResults();
	}

	public void SelectFlight(string flightNumber)
	{
		// Perform flight selection logic and update UI components
		// ...
		Console.WriteLine("Mediator: Flight selected.");
		passengerInfoComponent.EnablePassengerInfoForm();
	}

	public void BookFlight(string passengerName, string flightNumber)
	{
		// Perform flight booking logic and update UI components
		// ...
		Console.WriteLine("Mediator: Flight booked.");
		paymentComponent.EnablePaymentForm();
	}

	public void ProcessPayment(string passengerName, string flightNumber, decimal amount)
	{
		// Perform payment processing logic and update UI components
		// ...
		Console.WriteLine("Mediator: Payment processed.");
		flightSearchComponent.Reset();
		passengerInfoComponent.Reset();
		paymentComponent.Reset();
	}
}

// Flight Search Component
public class FlightSearchComponent
{
	private IFlightBookingMediator mediator;

	public FlightSearchComponent(IFlightBookingMediator mediator)
	{
		this.mediator = mediator;
	}

	public void Search(string origin, string destination, DateTime date)
	{
		Console.WriteLine($"Flight search: {origin} to {destination}, Date: {date}");
		mediator.SearchFlights(origin, destination, date);
	}

	public void DisplaySearchResults()
	{
		Console.WriteLine("Displaying flight search results...");
	}

	public void Reset()
	{
		Console.WriteLine("Flight search component reset.");
	}
}

// Passenger Information Component
public class PassengerInfoComponent
{
	private IFlightBookingMediator mediator;

	public PassengerInfoComponent(IFlightBookingMediator mediator)
	{
		this.mediator = mediator;
	}

	public void EnablePassengerInfoForm()
	{
		Console.WriteLine("Passenger information form enabled.");
	}

	public void BookFlight(string passengerName, string flightNumber)
	{
		Console.WriteLine($"Passenger: {passengerName}, Flight: {flightNumber}");
		mediator.BookFlight(passengerName, flightNumber);
	}

	public void Reset()
	{
		Console.WriteLine("Passenger info component reset.");
	}
}

// Payment Component
public class PaymentComponent
{
	private IFlightBookingMediator mediator;

	public PaymentComponent(IFlightBookingMediator mediator)
	{
		this.mediator = mediator;
	}

	public void EnablePaymentForm()
	{
		Console.WriteLine("Payment form enabled.");
	}

	public void ProcessPayment(string passengerName, string flightNumber, decimal amount)
	{
		Console.WriteLine($"Payment for Passenger: {passengerName}, Flight: {flightNumber}, Amount: {amount}");
		mediator.ProcessPayment(passengerName, flightNumber, amount);
	}

	public void Reset()
	{
		Console.WriteLine("Payment component reset.");
	}
}

// Usage
public class Program
{
	public static void Main(string[] args)
	{
		// Create UI components
		var flightSearchComponent = new FlightSearchComponent(null);
		var passengerInfoComponent = new PassengerInfoComponent(null);
		var paymentComponent = new PaymentComponent(null);

		// Create mediator and associate with UI components
		var mediator = new FlightBookingMediator(flightSearchComponent,
												 passengerInfoComponent,
												 paymentComponent);
		flightSearchComponent = new FlightSearchComponent(mediator);
		passengerInfoComponent = new PassengerInfoComponent(mediator);
		paymentComponent = new PaymentComponent(mediator);

		// Simulate user actions
		flightSearchComponent.Search("New York", "London", DateTime.Now);
		// flightSearchComponent.DisplaySearchResults(); this method is invoked from the mediator
		flightSearchComponent.Reset();

		flightSearchComponent.Search("Los Angeles", "Tokyo", DateTime.Now);
		// flightSearchComponent.DisplaySearchResults();
		passengerInfoComponent.BookFlight("John Doe", "12345");
		paymentComponent.ProcessPayment("John Doe", "12345", 1000);
	}
}
/*
In this example, we have a FlightBookingMediator class that implements the IFlightBookingMediator 
interface. It acts as the mediator and handles communication between the UI components 
(FlightSearchComponent, PassengerInfoComponent, PaymentComponent). Each UI component holds a 
reference to the mediator.

The mediator encapsulates the complex logic for flight search, flight selection, flight booking, 
and payment processing. When a user performs an action, such as searching for flights or booking 
a flight, the respective UI component invokes the appropriate method on the mediator, which 
then handles the communication and updates the other components as needed.

In the Main method, we create instances of the UI components and associate them with the mediator. 
We then simulate user actions such as searching for flights, displaying search results, 
booking a flight, and processing payment.

When you run the program, you'll see the output that demonstrates the communication between 
the UI components through the mediator, as well as the updates and resets performed by the mediator.
*/