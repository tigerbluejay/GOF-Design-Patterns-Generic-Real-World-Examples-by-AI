// Step 1: Define the strategy interface
public interface IShippingStrategy
{
	decimal CalculateShippingCost(decimal orderTotal);
}

// Step 2: Implement concrete strategies
public class StandardShippingStrategy : IShippingStrategy
{
	public decimal CalculateShippingCost(decimal orderTotal)
	{
		// Implementation for standard shipping calculation
		return orderTotal * 0.05m;
	}
}

public class ExpressShippingStrategy : IShippingStrategy
{
	public decimal CalculateShippingCost(decimal orderTotal)
	{
		// Implementation for express shipping calculation
		return orderTotal * 0.1m;
	}
}

// Step 3: Define the context that uses the strategy
public class ShoppingCart
{
	private readonly IShippingStrategy _shippingStrategy;

	public ShoppingCart(IShippingStrategy shippingStrategy)
	{
		_shippingStrategy = shippingStrategy;
	}

	public decimal CalculateTotalWithShippingCost(decimal orderTotal)
	{
		decimal shippingCost = _shippingStrategy.CalculateShippingCost(orderTotal);
		return orderTotal + shippingCost;
	}
}

// Step 4: Client code
class Program
{
	static void Main(string[] args)
	{
		// Create strategies
		IShippingStrategy standardShipping = new StandardShippingStrategy();
		IShippingStrategy expressShipping = new ExpressShippingStrategy();

		// Create context with standard shipping strategy
		ShoppingCart cart = new ShoppingCart(standardShipping);
		decimal orderTotal = 100.00m;

		decimal totalWithStandardShipping = cart.CalculateTotalWithShippingCost(orderTotal);
		Console.WriteLine($"Total with standard shipping: {totalWithStandardShipping:C}");

		// Change strategy to express shipping
		cart = new ShoppingCart(expressShipping);
		decimal totalWithExpressShipping = cart.CalculateTotalWithShippingCost(orderTotal);
		Console.WriteLine($"Total with express shipping: {totalWithExpressShipping:C}");

		Console.ReadLine();
	}
}

/* In this example, we have a IShippingStrategy interface representing the strategy. 
 * We implement two concrete strategies: StandardShippingStrategy and ExpressShippingStrategy. 
 * The ShoppingCart class represents the context and uses the strategy interface to calculate 
 * the total cost with shipping.
 * 
 * At runtime, you can dynamically change the strategy by passing different implementations of 
 * the IShippingStrategy to the ShoppingCart constructor, allowing you to switch between standard 
 * and express shipping strategies.
 * 
 * This demonstrates how the Strategy pattern helps encapsulate different algorithms and 
 * allows you to interchange them based on the desired behavior.
 */

/* 
 * In the example, we have an interface called IShippingStrategy, which defines the contract for 
 * different shipping strategies. Concrete strategies like StandardShippingStrategy and 
 * ExpressShippingStrategy implement this interface and provide their own logic for calculating the 
 * shipping cost based on the order total. The ShoppingCart class represents the context that uses 
 * the selected shipping strategy. It takes a strategy instance through its constructor and provides
 * a method, CalculateTotalWithShippingCost, which calculates the total cost of the shopping cart, 
 * including the shipping cost, based on the strategy in use.
 * 
 * By employing the Strategy pattern, the client code can switch between different shipping 
 * strategies by providing the appropriate strategy object to the ShoppingCart constructor. 
 * This decouples the client code from the specific shipping calculations and allows for easy 
 * modification or extension of the shipping strategies in the future.
 */