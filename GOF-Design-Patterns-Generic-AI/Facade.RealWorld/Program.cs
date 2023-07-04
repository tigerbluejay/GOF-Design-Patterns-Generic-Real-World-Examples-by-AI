/*
In this example, we have a simplified representation of an online ordering system. 
The complex subsystems (InventorySystem, PaymentSystem, and ShippingSystem) handle inventory checks, 
payment processing, and product shipping, respectively.

The OrderFacade class acts as a facade, providing a simplified interface for placing an order.
It encapsulates the interactions with the subsystems, coordinating the necessary operations to 
place an order.The PlaceOrder method of the OrderFacade class performs the following steps:

Checks the availability of the product in the desired quantity using the InventorySystem.
Processes the payment using the specified payment method through the PaymentSystem.
Ships the product to the specified address using the ShippingSystem.
The client code interacts with the system through the OrderFacade class. It calls the PlaceOrder 
method, providing the necessary parameters for the order. 
The facade shields the client from the complexity of the subsystems, making it easier to place an 
order without directly interacting with or understanding the inner workings of the subsystems.

When you run the above example, it will simulate the order placement process, including checking 
product availability, processing payment, and shipping the product. The console output will show 
the progress and final result of the order placement process.

This real-world example demonstrates how the Facade design pattern simplifies the usage of complex 
subsystems by providing a unified and simplified interface to the client code.
*/

using System;

// Complex subsystems
class InventorySystem
{
	public bool IsProductAvailable(int productId, int quantity)
	{
		// Check if the product is available in the inventory
		Console.WriteLine($"Checking availability of product {productId}...");

		// Simulating inventory check
		bool isAvailable = new Random().Next(2) == 0;

		return isAvailable;
	}
}

class PaymentSystem
{
	public bool ProcessPayment(string paymentMethod, decimal amount)
	{
		// Process payment using the specified payment method
		Console.WriteLine($"Processing payment of {amount} using {paymentMethod}...");

		// Simulating payment processing
		bool isPaymentSuccessful = new Random().Next(2) == 0;

		return isPaymentSuccessful;
	}
}

class ShippingSystem
{
	public string ShipProduct(int productId, int quantity, string address)
	{
		// Ship the product to the specified address
		Console.WriteLine($"Shipping {quantity} units of product {productId} to {address}...");

		// Simulating shipping process
		string trackingNumber = Guid.NewGuid().ToString();

		return trackingNumber;
	}
}

// Facade
class OrderFacade
{
	private InventorySystem inventorySystem;
	private PaymentSystem paymentSystem;
	private ShippingSystem shippingSystem;

	public OrderFacade()
	{
		inventorySystem = new InventorySystem();
		paymentSystem = new PaymentSystem();
		shippingSystem = new ShippingSystem();
	}

	public bool PlaceOrder(int productId, int quantity, string paymentMethod, string address)
	{
		// Check product availability
		bool isAvailable = inventorySystem.IsProductAvailable(productId, quantity);

		if (!isAvailable)
		{
			Console.WriteLine("Product is not available in the desired quantity.");
			return false;
		}

		// Process payment
		bool isPaymentSuccessful = paymentSystem.ProcessPayment(paymentMethod, quantity * 10);

		if (!isPaymentSuccessful)
		{
			Console.WriteLine("Payment processing failed.");
			return false;
		}

		// Ship product
		string trackingNumber = shippingSystem.ShipProduct(productId, quantity, address);

		Console.WriteLine($"Order placed successfully. Tracking number: {trackingNumber}");
		return true;
	}
}

// Client code
class Program
{
	static void Main(string[] args)
	{
		OrderFacade orderFacade = new OrderFacade();
		bool isOrderPlaced = orderFacade.PlaceOrder(123, 2, "Credit Card", "123 Main St, City");

		if (isOrderPlaced)
		{
			// Continue with additional logic or UI updates
		}
		else
		{
			// Handle order placement failure
		}
	}
}