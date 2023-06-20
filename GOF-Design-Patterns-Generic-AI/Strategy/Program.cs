
/* Certainly! The last example provided demonstrates the implementation of the Strategy design 
 * pattern in a more generic form. The Strategy pattern allows you to define a family of algorithms 
 * (strategies) and encapsulate each one as a separate class, making them interchangeable at runtime. 
 * The purpose of the Strategy pattern is to enable the selection of an algorithm dynamically based 
 * on specific conditions or requirements, without tightly coupling the client code to a particular 
 * implementation.
 * 
 * In the example, we have an interface called IStrategy<T>, which defines the contract for different 
 * strategies. Concrete strategies, such as AddOneStrategy and MultiplyByTwoStrategy, implement this
 * interface and provide their own implementations for executing the algorithm on the given input. 
 * The Context<T> class acts as the context that utilizes the strategy. It takes in a strategy 
 * instance through its constructor and provides a method, ExecuteStrategy, which allows the 
 * client code to execute the strategy on a given input.
 * 
 * By using the Strategy pattern, the client code can easily switch between different strategies 
 * by instantiating the appropriate strategy and passing it to the context. This approach promotes 
 * code flexibility, modularity, and extensibility. It also adheres to the principle of "composition 
 * over inheritance," as it favors object composition by delegating behavior to separate strategy 
 * classes rather than relying on inheritance to define variations of behavior.
*/


// Step 1: Define the strategy interface
public interface IStrategy<T>
{
	T Execute(T input);
}

// Step 2: Implement concrete strategies
public class AddOneStrategy : IStrategy<int>
{
	public int Execute(int input)
	{
		return input + 1;
	}
}

public class MultiplyByTwoStrategy : IStrategy<int>
{
	public int Execute(int input)
	{
		return input * 2;
	}
}

// Step 3: Define the context that uses the strategy
public class Context<T>
{
	private readonly IStrategy<T> _strategy;

	public Context(IStrategy<T> strategy)
	{
		_strategy = strategy;
	}

	public T ExecuteStrategy(T input)
	{
		return _strategy.Execute(input);
	}
}

// Step 4: Client code
class Program
{
	static void Main(string[] args)
	{
		// Create strategies
		IStrategy<int> addOneStrategy = new AddOneStrategy();
		IStrategy<int> multiplyByTwoStrategy = new MultiplyByTwoStrategy();

		// Create context with addOneStrategy
		Context<int> context = new Context<int>(addOneStrategy);
		int input = 5;

		int result = context.ExecuteStrategy(input);
		Console.WriteLine($"Result with addOneStrategy: {result}");

		// Change strategy to multiplyByTwoStrategy
		context = new Context<int>(multiplyByTwoStrategy);
		result = context.ExecuteStrategy(input);
		Console.WriteLine($"Result with multiplyByTwoStrategy: {result}");

		Console.ReadLine();
	}
}