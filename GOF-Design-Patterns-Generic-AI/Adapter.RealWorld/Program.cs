/* 
 * In this example, the IPaymentGateway interface represents the expected interface by the client 
 * for processing payments. The ThirdPartyPaymentGateway class is a third - party payment gateway
 * with its own method MakePayment, which has an incompatible interface with IPaymentGateway.
 * The ThirdPartyPaymentGatewayAdapter class implements the IPaymentGateway interface and internally 
 * uses an instance of ThirdPartyPaymentGateway to adapt the interface. The 
 * ThirdPartyPaymentGatewayAdapter's ProcessPayment method adapts the call to the MakePayment 
 * method of the ThirdPartyPaymentGateway. The PaymentProcessor class represents a payment 
 * processing system that uses the adapted payment gateway.
 * 
 * When executed, the client creates an instance of the ThirdPartyPaymentGateway, creates an 
 * instance of the ThirdPartyPaymentGatewayAdapter by passing the ThirdPartyPaymentGateway to 
 * its constructor, creates an instance of the PaymentProcessor by passing the adapted payment 
 * gateway to its constructor, and then processes a payment request using the PaymentProcessor. 
 * The adapted payment gateway allows the client to work with different payment gateways through 
 * the common IPaymentGateway interface, providing compatibility and flexibility in the payment 
 * processing system.
 */

// Target interface that the client expects
interface IPaymentGateway
{
	void ProcessPayment(decimal amount);
}

// Adaptee class with incompatible interface
class ThirdPartyPaymentGateway
{
	public void MakePayment(decimal amount)
	{
		Console.WriteLine("Processing payment of amount: $" + amount + " via ThirdPartyPaymentGateway");
	}
}

// Adapter class that adapts the ThirdPartyPaymentGateway to the IPaymentGateway interface
class ThirdPartyPaymentGatewayAdapter : IPaymentGateway
{
	private ThirdPartyPaymentGateway paymentGateway;

	public ThirdPartyPaymentGatewayAdapter(ThirdPartyPaymentGateway paymentGateway)
	{
		this.paymentGateway = paymentGateway;
	}

	public void ProcessPayment(decimal amount)
	{
		// Perform necessary operations to adapt the interface
		// Call the specific method of the ThirdPartyPaymentGateway
		paymentGateway.MakePayment(amount);
	}
}

// Client code
class PaymentProcessor
{
	private IPaymentGateway paymentGateway;

	public PaymentProcessor(IPaymentGateway paymentGateway)
	{
		this.paymentGateway = paymentGateway;
	}

	public void ProcessPaymentRequest(decimal amount)
	{
		paymentGateway.ProcessPayment(amount);
	}
}

// Usage
class Program
{
	static void Main(string[] args)
	{
		// Create an instance of the ThirdPartyPaymentGateway
		ThirdPartyPaymentGateway paymentGateway = new ThirdPartyPaymentGateway();

		// Create an instance of the ThirdPartyPaymentGatewayAdapter and pass the ThirdPartyPaymentGateway to its constructor
		IPaymentGateway adaptedPaymentGateway = new ThirdPartyPaymentGatewayAdapter(paymentGateway);

		// Create an instance of the PaymentProcessor and pass the adaptedPaymentGateway to its constructor
		PaymentProcessor paymentProcessor = new PaymentProcessor(adaptedPaymentGateway);

		// Process payment request
		decimal paymentAmount = 100.50m;
		paymentProcessor.ProcessPaymentRequest(paymentAmount);
	}
}